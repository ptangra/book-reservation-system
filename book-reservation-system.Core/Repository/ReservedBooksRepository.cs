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
    /// <summary>
    /// Repository class for handling database operations related to the 'ReservedBook' entity.
    /// Implements the <see cref="IGenericRepository{T}"/> and <see cref="IReservedBooksRepository"/> interfaces.
    /// </summary>
    public class ReservedBooksRepository : GenericRepository<ReservedBook>, IReservedBooksRepository
    {
        #region Fields
        // The database context for reserved book-related operations.
        private readonly BooksReservationDbContext _context;

        // The mapper for mapping between entities and DTOs.
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservedBooksRepository"/> class.
        /// </summary>
        /// <param name="context">The database context for reserved book-related operations.</param>
        /// <param name="mapper">The mapper for mapping between entities and DTOs.</param>
        public ReservedBooksRepository(BooksReservationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        // here we can add implementation for all specific methods for the reserved books repository

        /// <summary>
        /// Checks if a book is reserved by ID.
        /// </summary>
        /// <param name="id">The ID of the book to check.</param>
        /// <returns>A task representing the asynchronous operation with a boolean indicating whether the book is reserved.</returns>
        public async Task<bool> IsBookReserved(int? id)
        {
            // If the provided ID is null, return false.
            if (id is null)
            {
                return false;
            }

            // Check if a book with the specified ID is reserved.
            return await _context.Set<ReservedBook>().AnyAsync(x => x.BookId == id);
        }

        /// <summary>
        /// Deletes a reservation of a book by Book ID.
        /// </summary>
        /// <param name="id">The ID of the reserved book to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteReservedBook(int id)
        {
            // Find the reservation of book entity by Book ID.
            var entity = await _context.Set<ReservedBook>().FirstAsync(x => x.BookId == id);

            // If the entity is not found, throw a NotFoundException.
            if (entity == null)
            {
                throw new NotFoundException(typeof(ReservedBook).Name, id);
            }

            // Remove the reservation of book entity and save changes to the database.
            _context.Set<ReservedBook>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
