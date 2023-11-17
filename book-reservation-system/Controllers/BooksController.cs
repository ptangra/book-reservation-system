using System.Threading.Tasks;
using book_reservation_system.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace book_reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksReservationDBContext _context;

        public BooksController(BooksReservationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Book>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book createBookDTO)
        {
            var book = await _context.AddAsync(createBookDTO);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
