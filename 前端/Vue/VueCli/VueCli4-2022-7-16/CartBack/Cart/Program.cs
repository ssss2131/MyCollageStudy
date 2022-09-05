var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(setup => {
    setup.AddPolicy("policy1", builder =>
    {
        builder.WithOrigins("http://localhost:8080").
        AllowAnyMethod().
        AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("policy1");
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
