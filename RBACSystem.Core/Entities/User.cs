using System.ComponentModel.DataAnnotations;

namespace RBACSystem.Core.Entities
{
    /// <summary>
    /// Represents a system user with login credentials and assigned roles.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Unique username for the user.
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(50)]
        public required string Username { get; set; }

        /// <summary>
        /// Email address of the user.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; }

        /// <summary>
        /// Hashed password (never store plaintext).
        /// </summary>
        [Required]
        [MaxLength(256)]
        public required string PasswordHash { get; set; }

        /// <summary>
        /// Navigation: Roles assigned to this user.
        /// </summary>
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}
