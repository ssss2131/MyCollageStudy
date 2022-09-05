using System;
using System.Linq;
using System.Net.Http;
using Consul;

namespace ServiceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var consul = new ConsulClient(c =>
            {
                c.Address = new Uri("http://127.0.01:8500");
            }))
            {
                // // 显示所有的服务
                //var services=consul.Agent.Services().Result.Response;
                //foreach (var s in services.Values)
                //{                    
                //    Console.WriteLine($"id={s.ID},service={s.Service},address={s.Address},port={s.Port}");
                //}
                //随机选择
                //客户端负载均衡
                var services = consul.Agent.Services().Result.Response.Values;
                Random rand = new Random();
                int index = rand.Next(services.Count());
                var s = services.ElementAt(index);
                Console.WriteLine($"index={index}, id={s.ID},service={s.Service},address={s.Address},port={s.Port}");
                // 向服务发请求
                using (HttpClient http = new HttpClient())
                using (var httpContent = new StringContent("{PhoneNum:'111',Msg:'test message!'}", System.Text.Encoding.UTF8, "application/json"))
                {
                    var r = http.PostAsync($"http://{s.Address}:{s.Port}/api/SMS/Send_LX", httpContent).Result;
                    Console.WriteLine(r.StatusCode);
                }


            }


                Console.ReadKey();

        }
    }
}
