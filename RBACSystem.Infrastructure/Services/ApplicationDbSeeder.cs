using Microsoft.EntityFrameworkCore;
using RBACSystem.Core.Entities;
using RBACSystem.Core.Enums;
using RBACSystem.Core.Interfaces;
using RBACSystem.Infrastructure.Data;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RBACSystem.Infrastructure.Services
{
    /// <summary>
    /// Seeds initial roles and a default admin user.
    /// </summary>
    public class ApplicationDbSeeder(ApplicationDbContext context) : IApplicationDbSeeder
    {
        private readonly ApplicationDbContext _context = context;

        /// <summary>
        /// Seeds all roles defined in UserRoleType enum and creates a default Admin user with assigned role.
        /// </summary>
        public async Task SeedAsync()
        {
            // Seed roles based on Enum values
            if (!await _context.Roles.AnyAsync())
            {
                foreach (UserRoleType roleType in Enum.GetValues(typeof(UserRoleType)))
                {
                    var roleName = roleType.ToString(); // Admin, Editor, Manager, Viewer, Others

                    _context.Roles.Add(new Role
                    {
                        Name = roleName,
                        RoleType = roleType,
                        Description = $"System role: {roleName}"
                    });
                }

                await _context.SaveChangesAsync();
            }

            // Seed default admin user (only if Users table is empty)
            if (!await _context.Users.AnyAsync())
            {
                var adminRole = await _context.Roles.FirstAsync(r => r.RoleType == UserRoleType.Admin);
                var editorRole = await _context.Roles.FirstAsync(r => r.Name == "Editor");
                var viewerRole = await _context.Roles.FirstAsync(r => r.Name == "Viewer");

                var adminUser = new User
                {
                    Username = "admin",
                    Email = "admin@rbac.com",
                    PasswordHash = HashPassword("Admin@123"),
                };
                adminUser.UserRoles =
                [
                        new UserRole
                        {
                            User = adminUser, // required prop in UserRole.User
                            Role = adminRole, // required prop in UserRole.Role
                            RoleId = adminRole.Id,
                            AssignedDate = DateTime.UtcNow,
                            IsActive = true
                        }
                ];

                // Seed default editor user 
                var editorUser = new User
                {
                    Username = "editor",
                    Email = "editor@rbac.com",
                    PasswordHash = HashPassword("Editor@123")
                };
                editorUser.UserRoles = [
                        new UserRole
                        {
                            User = editorUser,
                            Role = editorRole,
                            RoleId = editorRole.Id,
                            AssignedDate = DateTime.UtcNow,
                            IsActive = true
                        }
                ];

                // Seed default viewer user 

                var viewerUser = new User
                {
                    Username = "viewer",
                    Email = "viewer@rbac.com",
                    PasswordHash = HashPassword("Viewer@123")
                };
                viewerUser.UserRoles = [
                        new UserRole
                        {
                            User = viewerUser,
                            Role = viewerRole,
                            RoleId = viewerRole.Id,
                            AssignedDate = DateTime.UtcNow,
                            IsActive = true
                        }
                ];

                _context.Users.AddRange(adminUser, editorUser, viewerUser);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Utility method to hash password using SHA256.
        /// </summary>
        private static string HashPassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
