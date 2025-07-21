using RBACSystem.Core.DTOs.Roles;

namespace RBACSystem.Core.Interfaces
{
    /// <summary>
    /// Provides role-related business logic such as listing roles for registration.
    /// </summary>
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllRolesAsync();
    }
}
