using System.Linq.Expressions;

namespace RBACSystem.Core.Interfaces
{
    /// <summary>
    /// Generic repository interface for performing basic CRUD operations.
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all entities of type T.
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Finds entities matching the specified predicate.
        /// </summary>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adds a new entity to the data store.
        /// </summary>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity in the data store.
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Removes an entity from the data store.
        /// </summary>
        void Remove(T entity);
    }
}
