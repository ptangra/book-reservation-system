using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using book_reservation_system.Core.Contracts;
using book_reservation_system.Core.Exceptions;
using book_reservation_system.Core.Models.Book;
using book_reservation_system.Core.Models.ReservedBook;
using book_reservation_system.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        // GET: api/Books/GetBooks
        [HttpGet("GetBooks")]
        public async Task<ActionResult<IEnumerable<GetBookDTO>>> GetBooks()
        {
            var books = await _booksRepository.GetAllAsync<GetBookDTO>();
            return Ok(books);
        }

        // GET: api/Books/GetBooksDetails
        [HttpGet("GetBooksDetails")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooksDetails()
        {
            var books = await _booksRepository.GetDetails();
            return Ok(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var book = await _booksRepository.GetDetails(id);

            return Ok(book);
        }

        // GET: api/Books/GetAvailableBooks
        [HttpGet("GetAvailableBooks")]
        public async Task<ActionResult<IEnumerable<GetBookDTO>>> GetAvailableBooks()
        {
            var books = await _booksRepository.GetAvailableBooks();
            return Ok(books);
        }
        // GET: api/Books/GetReservedBooksDetails
        [HttpGet("GetReservedBooksDetails")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetReservedBooksDetails()
        {
            var books = await _booksRepository.GetReservedBooks();
            return Ok(books);
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
        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, UpdateBookDTO updateBookDTO)
        {
            if (id != updateBookDTO.Id)
            {
                throw new BadRequestException("Invalid Record Id");
            }

            try
            {
                await _booksRepository.UpdateAsync(id, updateBookDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _booksRepository.Exists(id))
                {
                    throw new NotFoundException(nameof(PutBook), id);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        #endregion

        #region DELETE Methods
        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _booksRepository.DeleteAsync(id);

            return NoContent();
        }
        #endregion
    }
}
