var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    //app.UseHsts();
}
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


//app.MapDefaultControllerRoute();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "blog",
    pattern: "blog/{*par}",
    defaults: new { controller = "Home", action = "Index" });
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//    endpoints.MapAreaControllerRoute(name: "test", areaName: "Products",
//        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
//});
app.Run("http://localhost:8081");