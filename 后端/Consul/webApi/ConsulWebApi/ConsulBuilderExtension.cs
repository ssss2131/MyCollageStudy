using Consul;
using ConsulWebApi.Options;
using System;

public static class ConsulBuilderExtensions
{
    
    /// <summary>
    /// 注册WEbAPI服务
    /// </summary>
    /// <param name="configuration"></param>
    public static void RegisterConsul(this IConfiguration configuration)
    {
        var consul = configuration.GetSection("ConsulConfig").Get<MyConsul>();

        //初始化Consul服务信息
        var consulClient = new Consul.ConsulClient(opt =>
        {
            opt.Address = new Uri(consul.ConsulServer);
            opt.Datacenter = consul.DataCenter;
        });

        //2.读取配置信息
        var ip = consul.APIAddress; 
        int port = int.Parse(consul.APIPort);
        var name = consul.ApiName[0];
        var healthCheck = consul.APICheckAddress;
        var healPort = consul.HealthPort;
       
        //public IDictionary<string, ServiceTaggedAddress> TaggedAddresses { get; set; }
        var address = new List<ServiceTaggedAddress>();
        //for(var i=0;i<consul.ApiName.Count();i++)
        //{
        //    address.Add(new ServiceTaggedAddress { Port = int.Parse(consul.APIPort), Address = consul.APIAddress });
        //}



        var registration = new Consul.AgentServiceRegistration()
        {
            ID = $"{name}-{Guid.NewGuid()}",//服务ID编号
            Name = name,//WebAPI的名称
            Address = ip,//WebAPI的IP地址
            Port = port,//WebAPI的端囗           
            Check = new Consul.AgentServiceCheck()//注册健康检测方式
            {
                Interval = TimeSpan.FromSeconds(10),//每隔10S检测一次
                HTTP = $"{healPort}/{healthCheck}",//健康检测地址
                Timeout = TimeSpan.FromSeconds(5),//超时时长5s
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(10)//超时10s后不能连接中心服务则注销本服务
            }           
        };

        //registration.TaggedAddresses.Add("service1", address[0]);
        //registration.TaggedAddresses.Add("service2", address[1]);


        consulClient.Agent.ServiceRegister(registration).Wait();       
    }

    
        
}