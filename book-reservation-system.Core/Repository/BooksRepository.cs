using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using book_reservation_system.Core.Contracts;
using book_reservation_system.Core.Exceptions;
using book_reservation_system.Core.Models.Book;
using book_reservation_system.Data;
using Microsoft.EntityFrameworkCore;

namespace book_reservation_system.Core.Repository
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        #region Fields
        private readonly BooksReservationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public BooksRepository(BooksReservationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        // here we can add implementation for all specific methods for the books repository
        public async Task<BookDTO> GetDetails(int id)
        {
            var book = await _context.Books.Include(q => q.ReservedBook)
                .ProjectTo<BookDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (book == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }

            return book;
        }

        public async Task<List<BookDTO>> GetDetails()
        {
            return await _context.Books.Include(q => q.ReservedBook)
                .ProjectTo<BookDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<GetBookDTO>> GetAvailableBooks()
        {
            var books  = await _context.Books
                .Where(b => !_context.ReservedBooks.Any(rb => rb.BookId == b.Id))
                .Include(q => q.ReservedBook)
                .ProjectTo<GetBookDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            
            return books;
        }

        public async Task<List<BookDTO>> GetReservedBooks()
        {
            var books = await _context.Books
                .Where(b => _context.ReservedBooks.Any(rb => rb.BookId == b.Id))
                .Include(q => q.ReservedBook)
                .ProjectTo<BookDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return books;
        }
        #endregion
    }
}
