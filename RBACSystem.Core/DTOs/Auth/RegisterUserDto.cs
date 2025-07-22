
using System.ComponentModel.DataAnnotations;

namespace RBACSystem.Core.DTOs.Auth
{
    /// <summary>
    /// Data Transfer Object for registering a new user with roles.
    /// </summary>
    public class RegisterUserDto
    {
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public required string Password { get; set; }

        /// <summary>
        /// List of roles to assign to the user (e.g., Admin, Editor).
        /// </summary>
        public required List<string> Roles { get; set; }
    }
}
