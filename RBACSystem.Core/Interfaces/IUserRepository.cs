using RBACSystem.Core.Entities;

namespace RBACSystem.Core.Interfaces
{
    /// <summary>
    /// Repository contract for managing user-related operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        Task<User?> GetByIdAsync(Guid userId);

        /// <summary>
        /// Adds a new user to the data store.
        /// </summary>
        Task AddAsync(User user);

        /// <summary>
        /// Checks if a user exists with the given email.
        /// </summary>
        Task<bool> ExistsByEmailAsync(string email);
    }
}
