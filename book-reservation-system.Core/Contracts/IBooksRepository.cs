using System.Collections.Generic;
using System.Threading.Tasks;
using book_reservation_system.Core.Models.Book;
using book_reservation_system.Data;

namespace book_reservation_system.Core.Contracts
{
    /// <summary>
    /// Represents a repository interface specifically for the 'Book' entity,
    /// extending the generic repository interface for CRUD operations on books.
    /// </summary>
    public interface IBooksRepository : IGenericRepository<Book>
    {
        // here we can add specific methods for the booksrepository

        /// <summary>
        /// Retrieves detailed information about a book by its ID.
        /// </summary>
        Task<BookDTO> GetDetails(int id);

        /// <summary>
        /// Retrieves detailed information about all books in the database.
        /// </summary>
        Task<List<BookDTO>> GetDetails();

        /// <summary>
        /// Retrieves a list of available books in the database.
        /// </summary>
        Task<List<GetBookDTO>> GetAvailableBooks();

        /// <summary>
        /// Retrieves a list of reserved books in the database.
        /// </summary>
        Task<List<BookDTO>> GetReservedBooks();
    }
}
