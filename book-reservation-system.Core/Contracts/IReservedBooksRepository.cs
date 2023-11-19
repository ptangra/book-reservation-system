using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_reservation_system.Data;

namespace book_reservation_system.Core.Contracts
{
    /// <summary>
    /// Represents a repository interface specifically for the 'ReservedBook' entity,
    /// extending the generic repository interface for CRUD operations on reserved books.
    /// </summary>
    public interface IReservedBooksRepository : IGenericRepository<ReservedBook>
    {
        // here we can add specific methods for the reservedbooksrepository

        /// <summary>
        /// Checks if a book with the specified ID is reserved.
        /// </summary>
        /// <param name="id">The ID of the book to check.</param>
        Task<bool> IsBookReserved(int? id);

        /// <summary>
        /// Deletes a reservation of book from the database by Book ID.
        /// </summary>
        /// <param name="id">The ID of the reservation of the book to delete.</param>
        Task DeleteReservedBook(int id);
    }
}
