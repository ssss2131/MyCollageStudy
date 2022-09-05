using Identity.AppDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("Memory"));
builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => {
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;  
    //登录时需要确认邮件
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "MyCookies";
    options.LoginPath = "/Home/Index";
    options.AccessDeniedPath = "/AccessDenied/Denied";
    
});
builder.Services.AddAuthorization(config =>
{
    var defaultAuthorizationBuilder = new AuthorizationPolicyBuilder();
    var policy = defaultAuthorizationBuilder.RequireAuthenticatedUser().RequireRole("Admin").RequireClaim(ClaimTypes.Country, "China").Build();
    config.DefaultPolicy = policy;
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
