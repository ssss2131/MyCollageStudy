using StartMyNetCore.LifeTime;
using StartMyNetCore.LifeTime.MyMiddleware;
var builder = WebApplication.CreateBuilder(args);

//项目的启动
//·1服务注册
//·2管道中间件注册 AOP
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddTransient<IOperationTransient,Operation>();
builder.Services.AddScoped<IOperationScoped,Operation>();
builder.Services.AddSingleton<IOperationSingleton,Operation>();


var app = builder.Build();

//四大过滤器
//1、授权过滤器
//2、异常过滤器
//3、动作过滤器
//4、结果过滤器
//他们的实现方式

//1、通过服务注册 filter
//2、特性
//3、接口(furion特有的)
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapGet("/helloRazor",()=>{return "helloRazor!";});
app.UseMyMiddleware();
// app.MapDefaultControllerRoute();
app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// app.MapControllerRoute( 
//     name: "HelloMvc",
//     pattern: "{controller=Hello}/{action=Mvc}/{id?}",()=>{return "hello MvC";});
app.Map("/hello",()=>"hello");
app.Use(async (context, next) =>
{
    var currentEndpoint = context.GetEndpoint();

    if (currentEndpoint is null)
    {
        await next(context);
        return;
    }

    Console.WriteLine($"Endpoint: {currentEndpoint.DisplayName}");

    if (currentEndpoint is RouteEndpoint routeEndpoint)
    {
        Console.WriteLine($"  - Route Pattern: {routeEndpoint.RoutePattern}");
    }

    foreach (var endpointMetadata in currentEndpoint.Metadata)
    {
        Console.WriteLine($"  - Metadata: {endpointMetadata}");
    }

    await next(context);
});

app.MapRazorPages();

app.Run("https://localhost:8080");


