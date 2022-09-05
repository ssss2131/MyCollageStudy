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
        Description = "ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�",
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
#pragma warning disable CS8604 // �������Ͳ�������Ϊ null��
builder.Services.AddDbContext<AppDbContext>(config => { config.UseSqlServer(connectionString.ToString()); });
#pragma warning restore CS8604 // �������Ͳ�������Ϊ null��
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
#region ������ݿ��������
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
builder.Services.Configure<Audience>(builder.Configuration.GetSection("Audience"));//ѡ��ģʽ

var audienceConfig = builder.Configuration.GetSection("Audience");
//��ȡ��Կ
var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
//������֤����
var validationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidIssuer = audienceConfig["Iss"],

    ValidateAudience = true,
    ValidAudience = audienceConfig["Aud"],

    ValidateIssuerSigningKey = true,
    IssuerSigningKey = key,
    ValidateLifetime = true,//�Ƿ���֤Token��Ч�ڣ�ʹ�õ�ǰʱ����Token��Claims�е�NotBefore��Expires�Ա�
    ClockSkew = TimeSpan.Zero,//����ķ�����ʱ��ƫ����
    RequireExpirationTime = true,//�Ƿ�Ҫ��Token��Claims�б������Expires
};
//������֤
//��ӷ�����֤������ΪTestKey
builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = "TestKey";
})
.AddJwtBearer("TestKey", x =>
{
    x.RequireHttpsMetadata = true;
    //��JwtBearerOptions�����У�IssuerSigningKey(ǩ����Կ)��ValidIssuer(Token�䷢����)��ValidAudience(�䷢��˭)���������Ǳ���ġ�
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
