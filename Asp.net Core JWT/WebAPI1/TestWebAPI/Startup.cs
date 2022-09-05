using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.Models;
using TestWebAPI.DataAccessor;

namespace TestWebAPI1
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
            services.AddControllers();
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));

            //��ȡappsettings.json�ļ���������֤����Կ��Secret�������ڣ�Aud����Ϣ
            var audienceConfig = Configuration.GetSection("Audience");
            //��ȡ��ȫ��Կ
            var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
            //tokenҪ��֤�Ĳ�������
            var tokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,//������֤��ȫ��Կ
                IssuerSigningKey = signingKey,//��ֵ��ȫ��Կ
                ValidateIssuer = true,//������֤ǩ����
                ValidIssuer = audienceConfig["Iss"],//��ֵǩ����
                ValidateAudience = true,//������֤����
                ValidAudience = audienceConfig["Aud"],//��ֵ����
                ValidateLifetime = true,//�Ƿ���֤Token��Ч�ڣ�ʹ�õ�ǰʱ����Token��Claims�е�NotBefore��Expires�Ա�
                ClockSkew = TimeSpan.Zero,//����ķ�����ʱ��ƫ����
                RequireExpirationTime = true,//�Ƿ�Ҫ��Token��Claims�б������Expires
            };
            //��ӷ�����֤������ΪTestKey
            services.AddAuthentication(o =>
            {
                o.DefaultScheme = "TestKey";
            })
            .AddJwtBearer("TestKey", x =>
            {
                x.RequireHttpsMetadata = false;
                //��JwtBearerOptions�����У�IssuerSigningKey(ǩ����Կ)��ValidIssuer(Token�䷢����)��ValidAudience(�䷢��˭)���������Ǳ���ġ�
                x.TokenValidationParameters = tokenValidationParameters;
            });
            //services.AddControllers();
            services.AddSwaggerGen();
            //services.AddMvc();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();
        

            app.UseAuthentication(); // ��֤
            app.UseAuthorization();  // ��Ȩ

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
