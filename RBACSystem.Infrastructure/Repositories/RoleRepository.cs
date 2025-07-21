using Microsoft.EntityFrameworkCore;
using RBACSystem.Core.Entities;
using RBACSystem.Core.Interfaces;
using RBACSystem.Infrastructure.Data;

namespace RBACSystem.Infrastructure.Repositories
{
    /// <summary>
    /// Provides data access logic for Role entity.
    /// </summary>
    public class RoleRepository(ApplicationDbContext context) : IRoleRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(Guid roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }

        public async Task<Role?> GetByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }
    }
}
