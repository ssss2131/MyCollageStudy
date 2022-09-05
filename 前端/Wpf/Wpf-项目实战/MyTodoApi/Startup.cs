using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyTodoApi.Context;
using MyTodoApi.Context.Repository;
using MyTodoApi.Context.UnitOfWork;
using MyTodoApi.Extension;
using MyTodoApi.Extension.Token;
using MyTodoApi.Service;
using MyTodoApi.Service.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApi
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
          
            services.AddDbContext<ToDoDbContext>(opt =>
            {
                var connection = Configuration.GetConnectionString("ToDoConnect");
                opt.UseSqlite(connection);
            }).AddUnitOfWork<ToDoDbContext>()
            .AddCustomRepository<User,UserRepository>()
            .AddCustomRepository<Memo, MemoRepository>()
            .AddCustomRepository<ToDo, TodoRepository>();
            var token = Configuration.GetSection("tokenConfig").Get<TokenManagement>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                //Token Validation Parameters
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //��ȡ������Ҫʹ�õ�Microsoft.IdentityModel.Tokens.SecurityKey����ǩ����֤��
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.
                    GetBytes(token.Secret)),
                    //��ȡ������һ��System.String������ʾ��ʹ�õ���Ч�����߼����ҵķ����ߡ�
                    ValidIssuer = token.Issuer,
                    //��ȡ������һ���ַ��������ַ�����ʾ�����ڼ�����Ч���ڷ������ƵĹ��ڡ�
                    ValidAudience = token.Audience,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddControllers();
            services.AddTransient<ITodoService, TodoService>();
            services.AddTransient<IMemoService, MemoService>();
            services.AddTransient<ILoginService, LoginService>();
            var autoMapperConfig = new MapperConfiguration(config => {
                config.AddProfile(new AutoMapperProFile());
            });
            //services.AddAuthentication();
            services.AddSingleton(autoMapperConfig.CreateMapper());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyTodoApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyTodoApi v1"));
            }

            app.UseRouting();
  
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
