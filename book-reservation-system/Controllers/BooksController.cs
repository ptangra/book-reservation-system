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
    /// <summary>
    /// Controller responsible for handling HTTP requests related to books in the book reservation system.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        #region Fields
        // The repository responsible for book-related operations.
        private readonly IBooksRepository _booksRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="booksRepository">The repository for book-related operations.</param>
        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        #endregion

        #region GET Methods
        /// <summary>
        /// Retrieves a list of books.
        /// GET: api/Books/GetBooks
        /// </summary>
        [HttpGet("GetBooks")]
        public async Task<ActionResult<IEnumerable<GetBookDTO>>> GetBooks()
        {
            // Retrieve a list of books using the repository
            var books = await _booksRepository.GetAllAsync<GetBookDTO>();

            // Return the list of books as an Ok response
            return Ok(books);
        }

        /// <summary>
        /// Retrieves detailed information about books.
        /// GET: api/Books/GetBooksDetails
        /// </summary>
        [HttpGet("GetBooksDetails")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooksDetails()
        {
            // Retrieve detailed information about books using the repository
            var books = await _booksRepository.GetDetails();

            // Return the detailed information as an Ok response
            return Ok(books);
        }

        /// <summary>
        /// Retrieves detailed information about a specific book by ID.
        /// GET: api/Books/5
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            // Retrieve detailed information about a specific book by ID using the repository
            var book = await _booksRepository.GetDetails(id);

            // Return the detailed information as an Ok response
            return Ok(book);
        }

        /// <summary>
        /// Retrieves a list of available books.
        /// GET: api/Books/GetAvailableBooks
        /// </summary>
        [HttpGet("GetAvailableBooks")]
        public async Task<ActionResult<IEnumerable<GetBookDTO>>> GetAvailableBooks()
        {
            // Retrieve a list of available books using the repository
            var books = await _booksRepository.GetAvailableBooks();

            // Return the list of available books as an Ok response
            return Ok(books);
        }

        /// <summary>
        /// Retrieves detailed information about reserved books.
        /// GET: api/Books/GetReservedBooksDetails
        /// </summary>
        [HttpGet("GetReservedBooksDetails")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetReservedBooksDetails()
        {
            // Retrieve detailed information about reserved books using the repository
            var books = await _booksRepository.GetReservedBooks();

            // Return the detailed information as an Ok response
            return Ok(books);
        }
        #endregion

        #region POST Methods
        /// <summary>
        /// Adds a new book to the system.
        /// POST: api/Books
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook(CreateBookDTO createBookDTO)
        {
            // Add a new book to the system using the repository
            var book = await _booksRepository.AddAsync<CreateBookDTO, GetBookDTO>(createBookDTO);

            // Return the newly created book as a CreatedAtAction response
            return CreatedAtAction(nameof(PostBook), new { id = book.Id }, book);
        }
        #endregion

        #region PUT Methods
        /// <summary>
        /// Updates details of an existing book.
        /// PUT: api/Books/5
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, UpdateBookDTO updateBookDTO)
        {
            // Check if the provided ID matches the ID in the update DTO
            if (id != updateBookDTO.Id)
            {
                throw new BadRequestException("Invalid Record Id");
            }

            try
            {
                // Update the details of an existing book using the repository
                await _booksRepository.UpdateAsync(id, updateBookDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exceptions
                if (!await _booksRepository.Exists(id))
                {
                    // Throw a not found exception if the book does not exist
                    throw new NotFoundException(nameof(PutBook), id);
                }
                else
                {
                    // Re-throw the exception if it's not related to existence
                    throw;
                }
            }

            // Return a NoContent response
            return NoContent();
        }
        #endregion

        #region DELETE Methods
        /// <summary>
        /// Deletes a book by ID.
        /// DELETE: api/Books/5
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            // Delete a book by ID using the repository
            await _booksRepository.DeleteAsync(id);

            // Return a NoContent response
            return NoContent();
        }
        #endregion
    }
}
