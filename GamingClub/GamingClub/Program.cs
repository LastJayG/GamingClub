using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Views", "Resources")),
    RequestPath = "/Views/Resources" 
});

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
