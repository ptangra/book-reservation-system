using System.ComponentModel.DataAnnotations.Schema;
using book_reservation_system.Core.Models.ReservedBook;

namespace book_reservation_system.Core.Models.Book
{
    /// <summary>
    /// Represents a data transfer object (DTO) for detailed information about a book.
    /// </summary>
    public class BookDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the book is reserved.
        /// </summary>
        public bool IsReserved { get; set; }

        /// <summary>
        /// Gets or sets the comment associated with the book reservation.
        /// </summary>
        public string ReserveComment { get; set; }

        // Additional properties or references for relationships (e.g., M:M, 1:M, M:1, 1:1) can be added here.
    }
}
