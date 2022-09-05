var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("In");
    await next.Invoke();
    await context.Response.WriteAsync("Out");
});
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("In");
    await next();
    await context.Response.WriteAsync("Out");
});
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("In");
    await next();
    await context.Response.WriteAsync("Out");
});

app.Map("/hello", async appbuilder =>
{
    await appbuilder.Response.WriteAsync("helolo");
});
app.Run("http://localhost:8080");