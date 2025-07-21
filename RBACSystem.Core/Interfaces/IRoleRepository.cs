using RBACSystem.Core.Entities;

namespace RBACSystem.Core.Interfaces
{
    /// <summary>
    /// Repository contract for managing roles in the system.
    /// </summary>
    public interface IRoleRepository
    {
        /// <summary>
        /// Retrieves a role by its name.
        /// </summary>
        Task<Role?> GetByNameAsync(string roleName);

        /// <summary>
        /// Retrieves a role by its unique identifier.
        /// </summary>
        Task<Role?> GetByIdAsync(Guid roleId);

        /// <summary>
        /// Retrieves all available roles.
        /// </summary>
        Task<List<Role>> GetAllRolesAsync();
    }
}
