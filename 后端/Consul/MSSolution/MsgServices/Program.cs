using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MsgServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)

        //=> WebHost.CreateDefaultBuilder(args)
        //     .UseStartup<Startup>()
        //     .UseUrls("http://127.0.0.1:5000");
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

        //public static IWebHost BuildWebHost(string[] args)
        //{
        //    var config = new ConfigurationBuilder()
        //        .AddCommandLine(args)
        //        .Build();
        //    string ip = config["ip"];
        //    string port = config["port"];
        //    Console.WriteLine($"ip={ip},port={port}");
        //    return WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .UseUrls($"http://{ip}:{port}")
        //        .Build();
        //}
    }
}
