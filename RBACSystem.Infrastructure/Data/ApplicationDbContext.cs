using Microsoft.EntityFrameworkCore;
using RBACSystem.Core.Entities;

namespace RBACSystem.Infrastructure.Data
{
    /// <summary>
    /// Application database context for EF Core using MySQL.
    /// Defines DbSets and relationships for the RBAC system.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the ApplicationDbContext with specified options.
    /// </remarks>
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {

        // === DbSets ===
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();

        /// <summary>
        /// Configures entity relationships and schema constraints.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for UserRole join table
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // UserRole → User
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            // UserRole → Role
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
