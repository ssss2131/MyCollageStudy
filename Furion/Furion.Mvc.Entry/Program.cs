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
//    ,"https://localhost:8080");
//Serve.Run(RunOptions.Default, "https://localhost:8080");//最佳实践 保证web启动层 startup为空
//第一个参数
//RunOptions.Default在构造一个RunOptions对象为WebApplication制造原料 如必要的服务添加到IServiceCollection 
//中间件添加到IApplicationBuilder 中 通过委托的方式
//第二个参数 
//为其webAppliocation webHost宿主机配置 url UseUrl (ip地址和端口号)

//当原料准备好了 调用Furion提供的Run()方法 将主机运行起来
//Run()做的事
//Run() 检查用户是否自定义了服务与中间件　没有就直接创建一个WebApplication　有就通过Inject()最小注入的方式注入必要的服务
//Run() 如果只添加地址 则会默认帮你注入好比如跨域 swagger 认证 授权 等一系列的服务 以及中间件

using Furion.Web.Core;

MyProgram.url = "https://localhost:8081";
MyProgram.Main();
