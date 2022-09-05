using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //    webBuilder.UseStartup<Startup>();
        //});
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
            string ip = config["ip"];
            string port = config["port"];
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls($"http://{ip}:{port}");
        }
        //{
        //    var config = new ConfigurationBuilder()
        //        .AddCommandLine(args)
        //        .Build();
        //    string ip = config["ip"];
        //    string port = config["port"];
        //    Console.WriteLine($"ip={ip},port={port}");
        //    return (IHostBuilder)WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .UseUrls($"http://{ip}:{port}")
        //        .Build();
        //}
    }
}
