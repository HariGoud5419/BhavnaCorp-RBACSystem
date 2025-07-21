using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using RBACSystem.Core.Entities;
using RBACSystem.Core.Interfaces;
using RBACSystem.Infrastructure.Data;
using System.Security.Cryptography;
using System.Text;

namespace RBACSystem.Infrastructure.Services
{
    /// <summary>
    /// Implements authentication business logic including user validation and token issuance.
    /// </summary>
    public class AuthService(ApplicationDbContext context, IJwtTokenService jwtTokenService) : IAuthService
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IJwtTokenService _jwtTokenService = jwtTokenService;

        /// <summary>
        /// Validates the user credentials against stored hash.
        /// </summary>
        public async Task<User?> ValidateUserAsync(string email, string password)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) return null;

            return VerifyPassword(password, user.PasswordHash) ? user : null;
        }

        /// <summary>
        /// Generates a signed JWT token for the user.
        /// </summary>
        public Task<string> GenerateJwtTokenAsync(User user)
        {
            return Task.FromResult(_jwtTokenService.GenerateToken(user));
        }

        /// <summary>
        /// Registers a new user and assigns roles.
        /// </summary>
        public async Task RegisterUserAsync(User user, List<string> roles)
        {
            user.PasswordHash = HashPassword(user.PasswordHash);

            user.UserRoles = [.. roles.Select(roleName =>
            {
                var role = _context.Roles.First(r => r.Name == roleName); // Get Role entity

                return new UserRole
                {
                    RoleId = role.Id,
                    Role = role,               // Set required Role navigation
                    AssignedDate = DateTime.UtcNow,
                    IsActive = true,
                    User = user                // Set required User navigation
                };
            })];

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Hashes a plain-text password using SHA256.
        /// </summary>
        private static string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Compares a plain-text password to a stored hash.
        /// </summary>
        private static bool VerifyPassword(string password, string storedHash)
        {
            return HashPassword(password) == storedHash;
        }
    }
}
