using Microsoft.OpenApi.Models;
using GamingClub.Domain.Interfaces;
using GamingClub.Application.Interfaces;
using GamingClub.Application.Services;
using GamingClub.Data.Context;
using GamingClub.Data.Repositories;
using GamingClub.Application.Converters;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IGamingStationRepository, GamingStationRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IUserSerializer, UserSerializer>();

builder.Services.AddDbContext<GamingClubContext>();

// Настройка JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GamingClub API",
        Version = "v1",
        Description = "API для GamingClub",
    });

    // Настройка JWT в Swagger
    //var securityScheme = new OpenApiSecurityScheme
    //{
    //    Name = HeaderNames.Authorization,
    //    Type = SecuritySchemeType.ApiKey,
    //    Scheme = "Bearer",
    //    BearerFormat = "JWT",
    //    In = ParameterLocation.Header,
    //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
    //};

    //c.AddSecurityDefinition("Bearer", securityScheme);

    //var securityRequirement = new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            }
    //        },
    //        Array.Empty<string>()
    //    }
    //};

    //c.AddSecurityRequirement(securityRequirement);
});

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "GamingClub API V1");
        options.RoutePrefix = "swagger"; 
    });
}

app.UseStaticFiles();

// Обработка SPA маршрутов
app.MapWhen(ctx => !ctx.Request.Path.StartsWithSegments("/api") &&
                   !ctx.Request.Path.StartsWithSegments("/swagger"), appBuilder =>
                   {
                       appBuilder.Use(async (context, next) =>
                       {
                           await next();

                           // Если маршрут не найден и это GET-запрос
                           if (context.Response.StatusCode == 404 &&
                               !Path.HasExtension(context.Request.Path.Value) &&
                               context.Request.Method == "GET")
                           {
                               context.Request.Path = "/index.html";
                               await next();
                           }
                       });

                       appBuilder.UseStaticFiles();
                   });

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html");
});

app.Run();