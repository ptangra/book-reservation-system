using System.Collections.Generic;
using System.Threading.Tasks;
using book_reservation_system.Core.Contracts;
using book_reservation_system.Core.Exceptions;
using book_reservation_system.Core.Models.ReservedBook;
using Microsoft.AspNetCore.Mvc;

namespace book_reservation_system.Controllers
{
    /// <summary>
    /// Controller responsible for handling HTTP requests related to reserving of books in the book reservation system.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveBooksController : ControllerBase
    {
        #region Fields
        // The repository responsible for reserved book-related operations.
        private readonly IReservedBooksRepository _reserveBooksRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ReserveBooksController"/> class.
        /// </summary>
        /// <param name="reserveBooksRepository">The repository for reserved book-related operations.</param>
        public ReserveBooksController(IReservedBooksRepository reserveBooksRepository)
        {
            _reserveBooksRepository = reserveBooksRepository;
        }
        #endregion

        #region GET Methods
        /// <summary>
        /// Retrieves detailed information about reserved books.
        /// GET: api/ReserveBooks/GetReserveDetails
        /// </summary>
        [HttpGet("GetReserveDetails")]
        public async Task<ActionResult<IEnumerable<GetReservedBookDTO>>> GetReserveBooksDetails()
        {
            // Retrieve detailed information about reserved books using the repository.
            var reservedBooks = await _reserveBooksRepository.GetAllAsync<GetReservedBookDTO>();

            // Return the detailed information as an Ok response.
            return Ok(reservedBooks);
        }
        #endregion

        #region POST Methods
        /// <summary>
        /// Reserves a book.
        /// POST: api/ReserveBooks/Reserve
        /// </summary>
        [HttpPost("Reserve")]
        public async Task<ActionResult<ReservedBookDTO>> PostReservedBook(CreateReservedBookDTO createReservedBookDTO)
        {
            // Check if the book is already reserved.
            if (await _reserveBooksRepository.IsBookReserved(createReservedBookDTO.BookId))
            {
                throw new BadRequestException($"{nameof(PostReservedBook)} Book with id ({createReservedBookDTO.BookId}) was already reserved");
            }

            // Reserve the book using the repository.
            var reservedBook = await _reserveBooksRepository.AddAsync<CreateReservedBookDTO, GetReservedBookDTO>(createReservedBookDTO);

            // Return the newly reserved book as a CreatedAtAction response.
            return CreatedAtAction(nameof(PostReservedBook), new { id = reservedBook.BookId }, reservedBook);
        }
        #endregion

        #region DELETE Methods
        /// <summary>
        /// Deletes a reserved book by ID.
        /// DELETE: api/ReserveBooks/5
        /// </summary>
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            await _reserveBooksRepository.DeleteReservedBook(bookId);

            return NoContent();
        }
        #endregion
    }
}
