using System.Threading.Tasks;
using book_reservation_system.Core.Contracts;
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
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Book>> GetBooks()
        {
            var books = await _booksRepository.GetAllAsync();
            return Ok(books);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book createBookDTO)
        {
            var book = await _booksRepository.AddAsync(createBookDTO);

            return Ok();
        }
    }
}
