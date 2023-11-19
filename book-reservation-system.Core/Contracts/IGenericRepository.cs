using System.Collections.Generic;
using System.Threading.Tasks;

namespace book_reservation_system.Core.Contracts
{
    /// <summary>
    /// Represents a generic repository interface for performing CRUD operations on entities.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IGenericRepository<T>
        where T : class
    {
        /// <summary>
        /// Retrieves an entity of type T from the database by ID.
        /// </summary>
        Task<T> GetAsync(int? id);

        /// <summary>
        /// Retrieves an entity of type T from the database by ID, mapping it to a specified DTO.
        /// </summary>
        Task<TResult?> GetAsync<TResult>(int? id);

        /// <summary>
        /// Retrieves a list of all entities of type T from the database.
        /// </summary>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Retrieves a list of all entities of type T from the database, mapping them to a specified DTO.
        /// </summary>
        Task<List<TResult>> GetAllAsync<TResult>();

        /// <summary>
        /// Adds an entity of type T to the database.
        /// </summary>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Adds an entity to the database and returns the result after mapping to a specified DTO.
        /// </summary>
        Task<TResult> AddAsync<TSource, TResult>(TSource source);

        /// <summary>
        /// Deletes an entity of type T from the database by ID.
        /// </summary>
        Task DeleteAsync(int id);

        /// <summary>
        /// Updates an entity of type T in the database.
        /// </summary>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Updates an entity of type T in the database by ID, using data from a specified source.
        /// </summary>
        Task UpdateAsync<TSource>(int id, TSource source);

        /// <summary>
        /// Checks if an entity with the specified ID exists in the database.
        /// </summary>
        Task<bool> Exists(int id);
    }
}
