namespace RBACSystem.Core.Interfaces
{
    /// <summary>
    /// Coordinates the work of multiple repositories using a shared DbContext.
    /// Ensures all operations are committed as a single transaction.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the user repository.
        /// </summary>
        IUserRepository Users { get; }

        /// <summary>
        /// Gets the role repository.
        /// </summary>
        IRoleRepository Roles { get; }

        /// <summary>
        /// Saves all changes made through repositories to the database.
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}
