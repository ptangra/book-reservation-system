using book_reservation_system.Data;

namespace book_reservation_system.Core.Contracts
{
    public interface IBooksRepository : IGenericRepository<Book>
    {
        // here we can add specific methods for the booksrepository
    }
}
