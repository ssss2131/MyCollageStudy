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

builder.Services.AddFluentEmail(defaultFromEmail: "1824782123@qq.com", defaultFromName: "��������ͶƱϵͳ")
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
//���ȫ�����������
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
#region ʹ��AutoMapper
// ����������Assembly���͵����� ��ʾAutoMapper������Щ���������������Ѱ�����м̳���Profile��������ļ�
// �ڵ�ǰ����������г�������ɨ��AutoMapper�������ļ�
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
