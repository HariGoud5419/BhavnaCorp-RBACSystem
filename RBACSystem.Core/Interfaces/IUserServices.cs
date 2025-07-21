using RBACSystem.Core.DTOs.Users;

namespace RBACSystem.Core.Interfaces
{
    /// <summary>
    /// Defines contract for user-related operations like profile retrieval and admin-level user management.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get current user's profile using email (from JWT).
        /// </summary>
        Task<UserProfileDto?> GetUserProfileByEmailAsync(string email);

        /// <summary>
        /// Get all users (Admin or Manager only).
        /// </summary>
        Task<List<UserDto>> GetAllUsersAsync();

        /// <summary>
        /// Get details for a single user by ID.
        /// </summary>
        Task<UserDto?> GetUserByIdAsync(Guid id);

        /// <summary>
        /// Soft delete user (sets IsDeleted flag).
        /// </summary>
        Task<bool> SoftDeleteUserAsync(Guid id);
    }
}
