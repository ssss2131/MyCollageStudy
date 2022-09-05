using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
#region
//Serve.Run(RunOptions.Default
//        .ConfigureBuilder(builder =>
//        {
//            builder.Services.AddControllers().AddInject();
//        })
//        .Configure(app =>
//        {
//            app.UseRouting();
//            app.UseInject(string.Empty);
//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });

//        })
//    , "https://localhost:8080");
#endregion

namespace Furion.Web.Core;
[AppStartup(800)]
public class MyProgram: AppStartup
{
    public static string url;
    public static void Main()
    {    
        var builder = WebApplication.CreateBuilder().Inject();

        builder.Services.AddCorsAccessor();//添加跨域资源请求 --一定要在addcontrollers之前使用
        builder.Services.AddControllersWithViews().AddInject();
        builder.Services.AddAuthorization();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
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

        app.Run(url);
    }
}
//Serve.Run(RunOptions.Default);