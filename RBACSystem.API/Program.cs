using RBACSystem.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services from Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// Add controllers
builder.Services.AddControllers();

// Add Swagger/OpenAPI generation
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Bhavna Corp RBAC System API",
        Version = "v1",
        Description = "A role-based access control system using .NET 8 Web API"
    });

    // If you add JWT security later:
    // options.AddSecurityDefinition(...)
    // options.AddSecurityRequirement(...)
});

// Add API Explorer for Swagger
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Use Swagger only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Bhavna Corp RBAC System API v1");
        options.RoutePrefix = string.Empty; // sets Swagger UI to root
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
