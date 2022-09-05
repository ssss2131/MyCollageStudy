using ApiService.Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//HttpRequestMessage
builder.Services.AddHttpClient("Test").AddPolicyHandler(
   //request=>request.Method == HttpMethod.Get? new ClientPolicy().TestCircuitBreaker:new ClientPolicy().LinearHttpRetry
   //(requet) => { return new ClientPolicy().TestCircuitBreaker; }
   new ClientPolicy().TestCircuitBreaker

); ;//添加客户端连接池 并在设置一个Test Client 添加polly ==>AOP方式
//Func<HttpRequestMessage, IAsyncPolicy<HttpResponseMessage>> policySelector)

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ClientPolicy>(new ClientPolicy());//提供Polly实例


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

