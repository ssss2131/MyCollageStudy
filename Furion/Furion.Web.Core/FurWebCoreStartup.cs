using Furion.EntitFramework.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Furion.Web.Core
{
    /// <summary>
    /// 
    /// </summary>
    [AppStartup(800)]
    public sealed class FurWebCoreStartup : AppStartup
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddCorsAccessor();//添加跨域资源请求 --一定要在addcontrollers之前使用
            services.AddControllersWithViews().AddInject();
            services.AddAuthorization();
     
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseInject();
            app.UseCorsAccessor();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
