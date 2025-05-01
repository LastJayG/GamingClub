using GamingClub.Data.Context;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using GamingClub.Data.Interfaces;
using GamingClub.Data.Repositories;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IGamingStationRepository, GamingStationRepository>();

builder.Services.AddDbContext<GamingClubContext>(o => o.UseMySQL());

// JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GamingClub API",
        Version = "v1",
        Description = "API дл€ управлени€ GamingClub",
    });
    var security = new OpenApiSecurityScheme
    {
        Name = HeaderNames.Authorization,
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "JWT Authorization header",
        Reference = new OpenApiReference
        {
        }
    };
});

var app = builder.Build();

app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "GamingClub API V1");
        //„тобы разместить пользовательский интерфейс Swagger в корневом каталоге приложени€
        options.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();