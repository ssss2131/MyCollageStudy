using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VoteSystem.Application.VoteService.IService;
using VoteSystem.Application.VoteService.Service;

namespace VoteSystem.Web.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                        .AddInject();
            services.AddAuthentication("MyAuth").AddCookie("MyAuth", options =>
            {
                options.Cookie.Name = "MyCookie";
                options.LoginPath = "/Common/Login";
            });
            services.AddCors(setup =>
            {
                setup.AddPolicy(name: "policy1", builder =>
                {
                    builder.WithOrigins("http://localhost:8080", "http://localhost:5500")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
         
 
            services.AddTransient<IUserService, UserServiceImp>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseCors("policy1");
        
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseInject();
  
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();
            });
        }
    }
}