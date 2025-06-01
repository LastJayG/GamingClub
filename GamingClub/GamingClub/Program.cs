using Microsoft.OpenApi.Models;
using GamingClub.Domain.Interfaces;
using GamingClub.Application.Interfaces;
using GamingClub.Application.Services;
using GamingClub.Data.Context;
using GamingClub.Data.Repositories;
using FluentValidation;
using GamingClub.Application.DTOs.User;
using GamingClub.Application.Validation.User;
using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.Validation.Reservation;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

//builder.Services.AddMemoryCache();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IGamingStationRepository, GamingStationRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddScoped<IValidator<UserDTO>, UserDTOValidator>();
builder.Services.AddScoped<IValidator<UserUpdateDTO>, UserUpdateDTOValidator>();
builder.Services.AddScoped<IValidator<ReservationRequestDTO>, ReservationDTOValidator>();

builder.Services.AddDbContext<GamingClubContext>();

//Redis
builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetConnectionString("Cache"));

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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapFallbackToFile("index.html");
});

if (app.Environment.IsDevelopment())
{
    app.Run(async (context) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
        }
        else
        {
            await context.Response.WriteAsync("Hello from GamingClub API!");
        }
    });
}

app.Run();