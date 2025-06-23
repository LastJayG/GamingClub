#region usings
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
using Serilog;
#endregion

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IGamingStationRepository, GamingStationRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddScoped<IValidator<UserDTO>, UserDTOValidator>();
builder.Services.AddScoped<IValidator<UserUpdateDTO>, UserUpdateDTOValidator>();
builder.Services.AddScoped<IValidator<ReservationRequestDTO>, ReservationDTOValidator>();

builder.Services.AddDbContext<GamingClubContext>();

//Serilog
builder.Host.UseSerilog((context, configuration)=> 
    configuration.ReadFrom.Configuration(context.Configuration));

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

app.UseSerilogRequestLogging();

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
        if (context.Request.Path == "/") { context.Response.Redirect("/swagger"); }
        else { await context.Response.WriteAsync("Hello from GamingClub API!"); }
    });
}

app.Run();