using RBACSystem.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;
using RBACSystem.Core.Interfaces;
using RBACSystem.Core.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Registering Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

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
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    // options.AddSecurityRequirement(...)
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        },
        Array.Empty<string>()
    }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtConfig = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtConfig?.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtConfig?.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// registering JWT Settings 
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings")
);

// Add API Explorer for Swagger
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// use Cors 
app.UseCors("AllowAll");

// Use Swagger only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Bhavna Corp RBAC System API v1");
        options.RoutePrefix = string.Empty; // loads at root: https://localhost:7220/
    });
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IApplicationDbSeeder>();
    await seeder.SeedAsync();
}

app.Run();
