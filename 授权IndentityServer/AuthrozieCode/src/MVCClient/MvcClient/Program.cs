using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;//?

builder.Services.AddAuthentication((options)=>{
    options.DefaultScheme = "Cookies";//?使用cookies处理?
    options.DefaultChallengeScheme="oidc";//默认鉴权模式oidc
}).AddCookie("Cookies")
.AddOpenIdConnect("oidc",(options)=>{
    options.Authority = "https://localhost:5001";//授权机构
    options.ClientId = "mvc";//注册在服务器中的Id
    options.ClientSecret ="secret";//注册在服务器中的secret
    options.ResponseType = "code";//使用响应的类型 code
    
    // options.Scope.Clear();
    options.Scope.Add("api1");
    options.Scope.Add("profile");//第三方代表用户去获取授权服务器允许授权的资源IdentitySource
    options.Scope.Add("address");
    options.Scope.Add("email");
    
    options.GetClaimsFromUserInfoEndpoint = true;//从 UserInfo 端点中提取剩余声明 name, family_name, website 等不会出现在返回的令牌中
    
    options.SaveTokens = true;//ASP.NET Core 将自动将结果访问和刷新令牌存储在身份验证会话中
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();

app.Run();
