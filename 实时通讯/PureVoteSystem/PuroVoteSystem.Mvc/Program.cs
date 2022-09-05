using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSignalR();
builder.Services.AddAuthentication("MyCookies").AddCookie("MyCookies", options => {
    options.Cookie.Name = "Cookies";   
    options.LoginPath = "/Door/Login";
    options.AccessDeniedPath = "/Deined/Index";
});

builder.Services.AddFluentEmail(defaultFromEmail: "1824782123@qq.com", defaultFromName: "王的在线投票系统")
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient() { 
                    Host= "smtp.qq.com", 
                    EnableSsl=true, 
                    UseDefaultCredentials=false,
                    DeliveryMethod=SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("1824782123@qq.com", "sfyfpxyvxcazbbbd")
                });


//private string host = "smtp.qq.com";
//private bool enableSsl = true;
//private bool useDefaultCredentials = false;
//private SmtpDeliveryMethod smtp = SmtpDeliveryMethod.Network;
//private string authCode = "sfyfpxyvxcazbbbd";
//public string FromEmail;
//public string ToEmail;

//public SmtpClient CreateAClient()
//{
//    return new SmtpClient()
//    {
//        Host = host,
//        EnableSsl = enableSsl,
//        UseDefaultCredentials = useDefaultCredentials,
//        DeliveryMethod = smtp,
//        Credentials = new NetworkCredential(FromEmail, authCode)
//    };
//}



//builder.Services.AddTransient<IHostedService, JobCommon>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = "test";
    options.Configuration = "localhost";
     
});
//添加全局事物过滤器
builder.Services.Configure<MvcOptions>(opt =>
{
    opt.Filters.Add<TransactionScopeFilter>();
});
var connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.ConfigureApplicationCookie(opt => {
    opt.AccessDeniedPath = "/";
    opt.Cookie.Expiration = TimeSpan.FromDays(1);
   
});
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});
#region 使用AutoMapper
// 参数类型是Assembly类型的数组 表示AutoMapper将在这些程序集数组里面遍历寻找所有继承了Profile类的配置文件
// 在当前作用域的所有程序集里面扫描AutoMapper的配置文件
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Activity}/{action=Index}/{id?}").RequireAuthorization();
app.MapHub<ChatHub>("/chatHub");
app.Run();
