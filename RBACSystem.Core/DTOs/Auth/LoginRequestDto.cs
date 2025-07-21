using System.ComponentModel.DataAnnotations;

namespace RBACSystem.Core.DTOs.Auth
{
    /// <summary>
    /// DTO for capturing user login credentials.
    /// </summary>
    public class LoginRequestDto
    {
        /// <summary>
        /// Email address of the user.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public required string Email { get; set; }

        /// <summary>
        /// Hashed password of the user
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6)]
        public required string Password { get; set; }
    }
}
