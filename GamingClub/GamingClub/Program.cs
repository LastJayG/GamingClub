using Microsoft.EntityFrameworkCore;
using GamingClub.Data.Context;
using GamingClub.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDbContext<GamingClubContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "GamingClub API",
        Version = "v1",
        Description = "API для управления GamingClub",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Ваше имя",
            Email = "ваш.email@example.com"
        }
    });
});

builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();

//Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GamingClub API V1");
    });
}

app.UseRouting();

app.MapGet("/", () => "Welcome to GamingClub API! Please visit /swagger for API documentation.");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();