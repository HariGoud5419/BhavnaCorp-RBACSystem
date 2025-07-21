using RBACSystem.Core.Entities;

namespace RBACSystem.Core.Interfaces
{
    /// <summary>
    /// Provides authentication-related operations such as login, registration, and token creation.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Validates the user credentials for login.
        /// </summary>
        Task<User?> ValidateUserAsync(string email, string password);

        /// <summary>
        /// Generates a JWT token for the authenticated user.
        /// </summary>
        Task<string> GenerateJwtTokenAsync(User user);

        /// <summary>
        /// Registers a new user with specified roles.
        /// </summary>
        Task RegisterUserAsync(User user, List<string> roles);
    }
}
