using TableDemo.Goods;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors((e) =>
{

    e.AddPolicy("default", config =>
    {
        config.AllowAnyHeader().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//using (ServiceProvider sp = builder.Services.BuildServiceProvider())
//{ 
//}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("default");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
