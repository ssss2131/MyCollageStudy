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

            //ע��Swagger������������һ���Ͷ��Swagger �ĵ�
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
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//����ֹͣ��ú�ע�ᣨע����
                Interval = TimeSpan.FromSeconds(10),//�������ʱ���������߳�Ϊ�������
                HTTP = $"http://{ip}:{port}/api/Health",//��������ַ
                Timeout = TimeSpan.FromSeconds(5)
            };
            AgentServiceRegistration asr = new AgentServiceRegistration()
            {
                ID = serviceId,//�����ţ������ظ�
                Name = serviceName,
                Address = ip,//�����ṩ���ܱ����������߷��ʵ�IP��ַ
                Port = port,
                Check = check
            };
            //var client = new ConsulClient(ConsulConfig);
            //client.Agent.ServiceRegister(asr).Wait();
            //���������˳���ʱ���Consulע������
            //Ҫͨ����������ע��IApplicationLiftTime
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                using (var client = new ConsulClient(ConsulConfig))
                {
                    Console.WriteLine("Ӧ���˳�����ʼ��consulע��");
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
