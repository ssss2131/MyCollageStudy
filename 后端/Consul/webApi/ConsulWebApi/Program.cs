using Consul;
using ConsulWebApi.Options;

var builder = WebApplication.CreateBuilder(args);


var consul = builder.Configuration.GetSection("ConsulConfig").Get<MyConsul>();
// Add services to the container.
builder.Services.AddControllers();

//ʹ��consul���з�����
builder.Configuration.RegisterConsul();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
