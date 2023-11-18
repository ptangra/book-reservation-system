using System.Collections.Generic;
using System.Threading.Tasks;
using book_reservation_system.Core.Contracts;
using book_reservation_system.Core.Models.ReservedBook;
using Microsoft.AspNetCore.Mvc;

namespace book_reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveBooksController : Controller
    {
        #region Fields
        private readonly IReservedBooksRepository _reserveBooksRepository;
        #endregion

        #region Constructor
        public ReserveBooksController(IReservedBooksRepository reservedBooksRepository)
        {
            _reserveBooksRepository = reservedBooksRepository;
        }
        #endregion

        #region GET Methods
        // GET: api/ReserveBooks/
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetReservedBookDTO>>> GetReservedBooks()
        {
            var reservedBooks = await _reserveBooksRepository.GetAllAsync<GetReservedBookDTO>();
            return Ok(reservedBooks);
        }
        #endregion

        #region POST Methods
        // POST: api/ReserveBooks/
        [HttpPost]
        public async Task<ActionResult<ReservedBookDTO>> PostReservedBook(CreateReservedBookDTO createReservedBookDTO)
        {
            var reservedBook = await _reserveBooksRepository.AddAsync<CreateReservedBookDTO, GetReservedBookDTO>(createReservedBookDTO);

            return CreatedAtAction(nameof(PostReservedBook), new { id = reservedBook.Id }, reservedBook);
        }
        #endregion
    }
}
