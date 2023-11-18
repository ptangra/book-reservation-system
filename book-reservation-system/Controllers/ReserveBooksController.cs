using System.Collections.Generic;
using System.Threading.Tasks;
using book_reservation_system.Core.Contracts;
using book_reservation_system.Core.Exceptions;
using book_reservation_system.Core.Models.ReservedBook;
using Microsoft.AspNetCore.Mvc;

namespace book_reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveBooksController : ControllerBase
    {
        #region Fields
        private readonly IReservedBooksRepository _reserveBooksRepository;
        #endregion

        #region Constructor
        public ReserveBooksController(IReservedBooksRepository reserveBooksRepository)
        {
            _reserveBooksRepository = reserveBooksRepository;
        }
        #endregion

        #region GET Methods
        // GET: api/Books/
        [HttpGet("GetReserveDetails")]
        public async Task<ActionResult<IEnumerable<GetReservedBookDTO>>> GetReserveBooksDetails()
        {
            var reservedBooks = await _reserveBooksRepository.GetAllAsync<GetReservedBookDTO>();
            return Ok(reservedBooks);
        }
        #endregion

        #region POST Methods
        // POST: api/Books/Reserve
        [HttpPost("Reserve")]
        public async Task<ActionResult<ReservedBookDTO>> PostReservedBook(CreateReservedBookDTO createReservedBookDTO)
        {
            if (await _reserveBooksRepository.IsBookReserved(createReservedBookDTO.BookId))
            {
                throw new BadRequestException($"{nameof(PostReservedBook)} Book with id ({createReservedBookDTO.BookId}) was already reserved");
            }
            var reservedBook = await _reserveBooksRepository.AddAsync<CreateReservedBookDTO, GetReservedBookDTO>(createReservedBookDTO);

            return CreatedAtAction(nameof(PostReservedBook), new { id = reservedBook.BookId }, reservedBook);
        }
        #endregion

        #region DELETE Methods
        // DELETE: api/Books/5
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            await _reserveBooksRepository.DeleteReservedBook(bookId);

            return NoContent();
        }
        #endregion
    }
}
