using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using book_reservation_system.Core.Contracts;
using book_reservation_system.Core.Exceptions;
using book_reservation_system.Data;
using Microsoft.EntityFrameworkCore;

namespace book_reservation_system.Core.Repository
{
    public class ReservedBooksRepository : GenericRepository<ReservedBook>, IReservedBooksRepository
    {
        #region Fields
        private readonly BooksReservationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ReservedBooksRepository(BooksReservationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        // here we can add implementation for all specific methods for the reserved books repository
        public async Task<bool> IsBookReserved(int? id)
        {
            if (id is null)
            {
                return false;
            }

            return await _context.Set<ReservedBook>().AnyAsync(x => x.BookId == id);
        }

        public async Task DeleteReservedBook(int id)
        {
            var entity = await _context.Set<ReservedBook>().FirstAsync(x => x.BookId == id);

            if (entity == null)
            {
                throw new NotFoundException(typeof(ReservedBook).Name, id);
            }

            _context.Set<ReservedBook>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
