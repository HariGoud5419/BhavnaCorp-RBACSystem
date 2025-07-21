namespace RBACSystem.Core.DTOs.Auth
{
    /// <summary>
    /// DTO representing the response returned to the client upon successful login.
    /// Contains the JWT token and basic user details.
    /// </summary>
    public class LoginResponseDto
    {
        /// <summary>
        /// The JWT token string generated for the authenticated user.
        /// Used for accessing secured API endpoints.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// The username of the authenticated user.
        /// Useful for UI display or logging.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// The email address of the authenticated user.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The list of role names assigned to the authenticated user.
        /// These roles may be used for role-based access control on the frontend or backend.
        /// </summary>
        public List<string> Roles { get; set; } = [];
    }
}
