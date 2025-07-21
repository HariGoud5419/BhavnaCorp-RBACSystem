using Microsoft.EntityFrameworkCore;
using RBACSystem.Core.DTOs.Users;
using RBACSystem.Core.Entities;
using RBACSystem.Core.Interfaces;
using RBACSystem.Infrastructure.Data;

namespace RBACSystem.Infrastructure.Services
{
    /// <summary>
    /// Provides business logic for user operations including profile retrieval and admin access to user data.
    /// </summary>
    public class UserService(ApplicationDbContext context) : IUserService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<UserProfileDto?> GetUserProfileByEmailAsync(string email)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);

            if (user == null)
                return null;

            return new UserProfileDto
            {
                Username = user.Username,
                Email = user.Email,
                Roles = user.UserRoles?.Select(ur => ur.Role.Name).ToList() ?? []
            };
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await _context.Users
                .Where(u => !u.IsDeleted)
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Roles = user.UserRoles!.Select(ur => ur.Role.Name).ToList()
                })
                .ToListAsync();
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Roles = user.UserRoles!.Select(ur => ur.Role.Name).ToList()
            };
        }

        public async Task<bool> SoftDeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

            if (user == null) return false;

            user.IsDeleted = true;
            user.ModifiedAt = DateTime.UtcNow;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
