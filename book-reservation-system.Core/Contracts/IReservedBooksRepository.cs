using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_reservation_system.Data;

namespace book_reservation_system.Core.Contracts
{
    public interface IReservedBooksRepository : IGenericRepository<ReservedBook>
    {
        // here we can add specific methods for the reservedbooksrepository
        Task<bool> IsBookReserved(int? id);
        Task DeleteReservedBook(int id);
    }
}
