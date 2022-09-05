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
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Authentication.Middleware;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Administration;

namespace WebAPI.Gateway
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
            //��ȡappsettings.json�ļ���������֤����Կ��Secret�������ڣ�Aud����Ϣ
            var audienceConfig = Configuration.GetSection("Audience");
            //��ȡ��ȫ��Կ
            var signingKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
            //tokenҪ��֤�Ĳ�������
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true, //������֤��ȫ��Կ
                IssuerSigningKey = signingKey, //��ֵ��ȫ��Կ
                ValidateIssuer = true, //������֤ǩ����
                ValidIssuer = audienceConfig["Iss"], //��ֵǩ����
                ValidateAudience = true,//������֤����
                ValidAudience = audienceConfig["Aud"],//��ֵ����
                ValidateLifetime = true,//�Ƿ���֤Token��Ч�ڣ�ʹ�õ�ǰʱ����Token��Claims�е�NotBefore��Expires�Ա�
                ClockSkew = TimeSpan.Zero,//����ķ�����ʱ��ƫ����
                RequireExpirationTime = true,//�Ƿ�Ҫ��Token��Claims�б������Expires
            };

            //��ӷ�����֤������ΪTestKey
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "TestKey";
            })
            .AddJwtBearer("TestKey", x =>
            {
                x.RequireHttpsMetadata = false;
                //��JwtBearerOptions�����У�IssuerSigningKey(ǩ����Կ)��ValidIssuer(Token�䷢����)��ValidAudience(�䷢��˭)���������Ǳ���ġ�
                x.TokenValidationParameters = tokenValidationParameters;
            });

            //���Ocelot���ط���ʱ,����Secret��Կ��Issǩ���ˡ�Aud����
            services.AddOcelot(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ʹ����֤����
            app.UseAuthentication();

            // ʹ��Ocelot�м��
            app.UseOcelot().Wait();

        }
    }
}
