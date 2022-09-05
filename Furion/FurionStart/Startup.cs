namespace FurionStart
{
    //这个优先级高于 Service里面
    public class Startup : AppStartup
    {       
        public void ConfigureService(IServiceCollection services)
        {
            services.AddConfigurableOptions<MyBrotherOptions>();

            services.AddControllers().AddInject();
        }
        public void Configure(IApplicationBuilder builder, IWebHostEnvironment env)
        {

            builder.UseInject("Api");
            builder.UseRouting();
            builder.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
            //builder.Use(async (context, next) =>
            //{
            //    Console.WriteLine("方法传入A");
            //    await next();
            //    Console.WriteLine("传出A");
            //});
            //builder.Use(async (context, next) =>
            //{
            //    Console.WriteLine("方法传入B");
            //    await next();
            //    Console.WriteLine("传出B");
            //});

            ////终结中间件
            //builder.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("H ello worl d ");
            //});
        }
    }
}
