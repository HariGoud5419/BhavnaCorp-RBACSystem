using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RBACSystem.Infrastructure.Data;
using RBACSystem.Core.Interfaces;
using RBACSystem.Infrastructure.Repositories;
using RBACSystem.Infrastructure.UnitOfWork;
using RBACSystem.Infrastructure.Services;

namespace RBACSystem.Infrastructure.Extensions
{
    /// <summary>
    /// Registers infrastructure-related services like DbContext and repositories.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext with MySQL connection string
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                                 ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));

            // Register Unit of Work and repositories
            services.AddScoped<IUnitOfWork, RBACSystem.Infrastructure.UnitOfWork.UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IApplicationDbSeeder, ApplicationDbSeeder>();

            return services;
        }
    }
}
