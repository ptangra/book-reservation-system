using System.Collections.Generic;
using System.Threading.Tasks;
using book_reservation_system.Core.Models.Book;
using book_reservation_system.Data;

namespace book_reservation_system.Core.Contracts
{
    public interface IBooksRepository : IGenericRepository<Book>
    {
        // here we can add specific methods for the booksrepository
        Task<BookDTO> GetDetails(int id);
        Task<List<BookDTO>> GetDetails();
        Task<List<GetBookDTO>> GetAvailableBooks();
        Task<List<BookDTO>> GetReservedBooks();
    }
}
