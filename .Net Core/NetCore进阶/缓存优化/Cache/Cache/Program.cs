using Cache.Data;
using CacheTools.MemoCache;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseInMemoryDatabase("MyDb");
});
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = "test";
    options.Configuration = "localhost";
});
builder.Services.AddTransient<ICacheHelper, CacheHelper>();


builder.Services.AddMemoryCache();//内存中的缓存
builder.Services.Configure<MvcOptions>(opt => {
    opt.Filters.Add<MyExceptionFilter>();
    opt.Filters.Add<ActionFilterA>();
    opt.Filters.Add<ActionFilterB>();
    opt.Filters.Add<TransactionScopeFilter>();
    opt.Filters.Add<RateLimitFilter>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
/*app.UseResponseCaching();*///启用服务端缓存 但是会受到限制 比如Cookies Authorization 跨域中间件需要使用在之前
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
