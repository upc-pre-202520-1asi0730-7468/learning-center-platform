using ACME.LearningCenterPlatform.API.Profiles.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Documentation.OpenApi.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

// Open API Configuration
builder.AddOpenApiConfigurationServices();

// Dependency Injection

// Shared Bounded Context
builder.AddSharedContextServices();

// Publishing Bounded Context
builder.AddPublishingContextServices();

// Profiles Bounded Context

builder.AddProfilesContextServices();

// Mediator Configuration
builder.AddCortexConfigurationServices();

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();