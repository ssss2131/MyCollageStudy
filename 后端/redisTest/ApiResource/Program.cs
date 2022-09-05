using HelloRedis.Domain;
using HelloRedis.Repository;
using HelloRedis.RepositoryImp;
using Infrastracture.stratup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = "https://localhost:5001";
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateAudience = false
    };
    options.Audience = "api1";
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api1");
    });
});

//builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
//            builder =>
//            {
//                builder.AllowAnyMethod()
//                    .AllowAnyHeader()
//                    .SetIsOriginAllowed(_ => true) // =AllowAnyOrigin()
//                    .AllowCredentials();
//            }));
//builder.Services.AddScoped<SqlServerDbContext>();
//services.AddScoped<AbsDbcontext,AppDbContext>();
//builder.Services.AddScoped<AbsDbcontext, SqlServerDbContext>();
//builder.Services.AddTransient<IBooklService, BookServiceImp>();
//builder.Services.AddTransient<AppDbContext>();
builder.Services.Myservices();
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
//app.UseCors("CorsPolicy");
app.MapControllers()/*.RequireAuthorization("ApiScope")*/;

app.Run();
