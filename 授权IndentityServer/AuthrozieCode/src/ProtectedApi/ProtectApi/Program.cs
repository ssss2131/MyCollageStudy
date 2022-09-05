using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization(option=>{
    option.AddPolicy("ApiPolicy",policy=>{
        policy.RequireAuthenticatedUser();
        policy.RequireClaim(claimType:"scope",allowedValues:"api1");
    });
});

builder.Services.AddAuthentication("Bearer").
    AddJwtBearer("Bearer",(options)=>{
        options.Authority ="https://localhost:5001";
        options.TokenValidationParameters =new TokenValidationParameters
            {//包含一组参数，这些参数由 SecurityTokenHandler 在验证 SecurityToken 时使用。
                ValidateAudience = false
            }; 
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("ApiPolicy");

app.Run();
