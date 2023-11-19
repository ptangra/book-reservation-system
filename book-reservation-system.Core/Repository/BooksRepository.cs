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
    /// <summary>
    /// Repository class for handling database operations related to the 'Book' entity.
    /// Implements the <see cref="IGenericRepository{T}"/> and <see cref="IBooksRepository"/> interfaces.
    /// </summary>
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        #region Fields
        // The database context for book-related operations.
        private readonly BooksReservationDbContext _context;

        // The mapper for mapping between entities and DTOs.
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksRepository"/> class.
        /// </summary>
        /// <param name="context">The database context for book-related operations.</param>
        /// <param name="mapper">The mapper for mapping between entities and DTOs.</param>
        public BooksRepository(BooksReservationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        // here we can add implementation for all specific methods for the books repository

        /// <summary>
        /// Gets detailed information about a book by ID.
        /// </summary>
        /// <param name="id">The ID of the book.</param>
        /// <returns>A task representing the asynchronous operation with the detailed information about the book.</returns>
        public async Task<BookDTO> GetDetails(int id)
        {
            // Retrieve a specific book by ID, including its reserved book information, and project it to a DTO.
            var book = await _context.Books.Include(q => q.ReservedBook)
                .ProjectTo<BookDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            // If the book is not found, throw a NotFoundException.
            if (book == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }

            return book;
        }

        /// <summary>
        /// Gets detailed information about all books.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with a list of detailed information about all books.</returns>
        public async Task<List<BookDTO>> GetDetails()
        {
            // Retrieve detailed information about all books, including reserved book information, and project it to DTOs.
            return await _context.Books.Include(q => q.ReservedBook)
                .ProjectTo<BookDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Gets a list of available books.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with a list of available books.</returns>
        public async Task<List<GetBookDTO>> GetAvailableBooks()
        {
            // Retrieve a list of available books, excluding those that are reserved, and project it to DTOs.
            var books  = await _context.Books
                .Where(b => !_context.ReservedBooks.Any(rb => rb.BookId == b.Id))
                .Include(q => q.ReservedBook)
                .ProjectTo<GetBookDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            
            return books;
        }

        /// <summary>
        /// Gets a list of reserved books.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with a list of reserved books.</returns>
        public async Task<List<BookDTO>> GetReservedBooks()
        {
            // Retrieve a list of reserved books, including reserved book information, and project it to DTOs.
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
