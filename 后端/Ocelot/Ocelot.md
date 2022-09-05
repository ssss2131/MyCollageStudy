###Ocelot 配置上游下游
    {
        "Routes": [
        {
            <--无论上下游路由模板都必须以‘/’开头-->
            <--模板路由只是规定了真实Api 用户请求Api的路由方式
            {everthing}这部分是上下游路由共享的上游取出这里带到下游路由模板在通过这个映射到下游服务的路由
            
            类似属性路由
            -->
            "DownstreamPathTemplate": "/{everything}",
            "DownstreamScheme": "http",
            "DownstreamHostAndPorts": [
                {
                    "Host": "localhost",
                    "Port": 5256
                },
                {
                    "Host":"localhost", 
                    "Port":5296    
                }
            ],
            "UpstreamPathTemplate": "/{everything}",
            "UpstreamHttpMethod": [ "Get", "Post" ],
            <--负载均衡配置-->
            "LoadBalancerOptions": {
            "Type": "RoundRobin   
            <--
                LeastConnection : 将请求发往最空闲的那个服务器

                RoundRobin ：轮流发送

                NoLoadBalance ：不启用负载均衡，总是发往第一个请求或者服务发现的那个服务器
            -->
            }
            
        }
        ],
        "GlobalConfiguration": {
            "BaseUrl": "http://localhost:5167",//设置全局的访问地址
            "ServiceDiscoveryProvider": {
                    "Host": "localhost",
                    "Port": 8500,
                    "ConfigurationKey": "Oceolot_A","Type": "Consul"
                } // .AddConsul()
                    // .AddConfigStoredInConsul();
        }
    }
    
#####ocelot 更像是一个代理，consul实现让用户对具体路径透明用户不需要知道具体api路径，但ocelot目前来看需要用户知道具体路径以及ocelot中上游的模板
