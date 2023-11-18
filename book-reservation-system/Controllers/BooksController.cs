using System.Threading.Tasks;
using book_reservation_system.Core.Contracts;
using book_reservation_system.Core.Models.Book;
using book_reservation_system.Data;
using Microsoft.AspNetCore.Mvc;

namespace book_reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        #region Fields
        private readonly IBooksRepository _booksRepository;
        #endregion

        #region Constructor
        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        #endregion

        #region GET Methods
        [HttpGet]
        public async Task<ActionResult<Book>> GetBooks()
        {
            var books = await _booksRepository.GetAllAsync();
            return Ok(books);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var book = await _booksRepository.GetAsync(id);

            return Ok(book);
        }
        #endregion

        #region POST Methods
        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook(CreateBookDTO createBookDTO)
        {
            var book = await _booksRepository.AddAsync<CreateBookDTO, GetBookDTO>(createBookDTO);

            return CreatedAtAction(nameof(PostBook), new { id = book.Id }, book);
        }
        #endregion

        #region PUT Methods
        #endregion

        #region DELETE Methods
        #endregion
    }
}
