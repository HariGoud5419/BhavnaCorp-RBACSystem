using System.Threading.Tasks;

namespace RBACSystem.Core.Interfaces
{
    /// <summary>
    /// Interface for database seeding service.
    /// Seeds roles, default admin, and role assignments.
    /// </summary>
    public interface IApplicationDbSeeder
    {
        /// <summary>
        /// Seeds initial data into the database.
        /// </summary>
        Task SeedAsync();
    }
}
