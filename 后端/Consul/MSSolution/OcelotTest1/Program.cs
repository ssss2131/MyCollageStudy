using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OcelotTest1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                    //.ConfigureWebHostDefaults(webBuilder =>
                    //{
                    //    webBuilder.UseStartup<Startup>();
                    //    webBuilder.UseUrls("http://127.0.0.1:8888");
                    //    webBuilder.ConfigureAppConfiguration((hostingContext, builder) =>
                    //    {
                    //        builder.AddJsonFile("TestConfig.json", false, true);
                    //    });

                    //}
                    //);
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                            {
                                config
                                    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                                    .AddJsonFile("TestConfig.json")
                                    .AddEnvironmentVariables();
                                ;
                            })
                            .ConfigureServices(services =>
                            {
                                services.AddOcelot();
                                services.AddHttpContextAccessor();

                            })
                            .Configure(app =>
                            {
                                app.UseOcelot().Wait();
                            });
                    });
    }
}
/*  路由规则  配置文件就是做转发
  把地址 http://127.0.0.1/MsgServices/AA/BB?age=1
  转成   http://localhost:5001/api/AA/BB?age=1
 */
