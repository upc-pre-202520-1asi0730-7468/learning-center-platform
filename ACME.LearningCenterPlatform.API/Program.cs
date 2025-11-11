using ACME.LearningCenterPlatform.API.IAM.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using ACME.LearningCenterPlatform.API.Profiles.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Documentation.OpenApi.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Services
builder.AddDatabaseServices();

// Open API Configuration
builder.AddOpenApiDocumentationServices();

// Dependency Injection

// Bounded Context Services Registration
builder.AddSharedContextServices();
builder.AddPublishingContextServices();
builder.AddProfilesContextServices();
builder.AddIamContextServices();

// Mediator Configuration
builder.AddCortexConfigurationServices();

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
app.UseDatabaseCreationAssurance();

// Configure the HTTP request pipeline.
app.UseOpenApiDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRequestAuthorization();
app.MapControllers();
app.Run();