using Microsoft.EntityFrameworkCore;
using RBACSystem.Core.DTOs.Roles;
using RBACSystem.Core.Interfaces;
using RBACSystem.Infrastructure.Data;

namespace RBACSystem.Infrastructure.Services
{
    /// <summary>
    /// Provides implementation for fetching roles from the database.
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<List<RoleDto>> GetAllRolesAsync()
        {
            return await _context.Roles
                .Where(r => !r.IsDeleted && r.IsActive)
                .Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    RoleType = r.RoleType.ToString()
                })
                .ToListAsync();
        }
    }
}
