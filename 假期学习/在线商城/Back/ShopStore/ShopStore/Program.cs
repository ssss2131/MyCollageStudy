using Jwt.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.Base;
using Repository.UserRep;
using ShopStore.tools;
using ShopStoreCore.System;
using ShopStoreCore.System.Provicy;
using StoreEfCore;
using StoreShare;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetSection("Default");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "直接在下框中输入Bearer {token}（注意两者之间是一个空格）",
        Name = "Authorization",
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference=new OpenApiReference
              {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
              }
            },
            new string[] {}
          }
        });
});
#pragma warning disable CS8604 // 引用类型参数可能为 null。
builder.Services.AddDbContext<AppDbContext>(config => { config.UseSqlServer(connectionString.ToString()); });
#pragma warning restore CS8604 // 引用类型参数可能为 null。
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
#region 添加数据库操作服务
builder.Services.AddTransient<IBase<SystemMenu>, BaseImp<SystemMenu>>();
builder.Services.AddTransient<IBase<SystemRole>, BaseImp<SystemRole>>();
builder.Services.AddTransient<IBase<SystemOperation>, BaseImp<SystemOperation>>();
builder.Services.AddTransient<IBase<SystemUser>, BaseImp<SystemUser>>();
builder.Services.AddTransient<IUserRep, UserRepImp>();

#endregion
builder.Services.AddTransient<MyMD5>();
builder.Services.AddCors(config =>
{
    config.AddPolicy("myPolicy", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
#region Token
builder.Services.Configure<Audience>(builder.Configuration.GetSection("Audience"));//选项模式

var audienceConfig = builder.Configuration.GetSection("Audience");
//获取秘钥
var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
//设置验证参数
var validationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidIssuer = audienceConfig["Iss"],

    ValidateAudience = true,
    ValidAudience = audienceConfig["Aud"],

    ValidateIssuerSigningKey = true,
    IssuerSigningKey = key,
    ValidateLifetime = true,//是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
    ClockSkew = TimeSpan.Zero,//允许的服务器时间偏移量
    RequireExpirationTime = true,//是否要求Token的Claims中必须包含Expires
};
//设置认证
//添加服务验证，方案为TestKey
builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = "TestKey";
})
.AddJwtBearer("TestKey", x =>
{
    x.RequireHttpsMetadata = true;
    //在JwtBearerOptions配置中，IssuerSigningKey(签名秘钥)、ValidIssuer(Token颁发机构)、ValidAudience(颁发给谁)三个参数是必须的。
    x.TokenValidationParameters = validationParameters;

});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("myPolicy"); 
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
