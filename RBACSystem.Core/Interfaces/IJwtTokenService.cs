using RBACSystem.Core.Entities;

namespace RBACSystem.Core.Interfaces
{
    /// <summary>
    /// Service for generating JWT tokens for authenticated users.
    /// </summary>
    public interface IJwtTokenService
    {
        /// <summary>
        /// Generates a signed JWT token for the specified user with role claims.
        /// </summary>
        /// <param name="user">The user entity to generate the token for.</param>
        /// <returns>Signed JWT token as a string.</returns>
        string GenerateToken(User user);
    }
}
