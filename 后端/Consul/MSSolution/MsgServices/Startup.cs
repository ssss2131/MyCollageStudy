using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using Consul;
using Consul.AspNetCore;

namespace MsgServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddControllers();
            //Swashbuckle.AspNetCore.SwaggerUI.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My SWAGGER DOC");
            });

            string ip = Configuration["ip"];
            int port = Convert.ToInt32(Configuration["port"]);          
            string serviceName = "MsgServices";
            string serviceId = serviceName + Guid.NewGuid().ToString();
            //Consul.AspNetCore.
            var check = new AgentServiceCheck
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务停止多久后反注册（注销）
                Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称为心跳间隔
                HTTP = $"http://{ip}:{port}/api/Health",//健康检查地址
                Timeout = TimeSpan.FromSeconds(5)
            };
            AgentServiceRegistration asr = new AgentServiceRegistration()
            {
                ID = serviceId,//服务编号，不能重复
                Name = serviceName,
                Address = ip,//服务提供者能被服务消费者访问的IP地址
                Port = port,
                Check = check
            };
            //var client = new ConsulClient(ConsulConfig);
            //client.Agent.ServiceRegister(asr).Wait();
            //程序正常退出的时候从Consul注销服务
            //要通过方法参数注入IApplicationLiftTime
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                using (var client = new ConsulClient(ConsulConfig))
                {
                    Console.WriteLine("应用退出，开始从consul注销");
                    client.Agent.ServiceDeregister(serviceId).Wait();
                }
            });
        }


        private void ConsulConfig(ConsulClientConfiguration c)
        {
            c.Address = new Uri("http://127.0.0.1:8500");
            c.Datacenter = "dc1";
        }
    
    
    }
}
