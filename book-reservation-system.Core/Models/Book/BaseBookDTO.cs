using System.ComponentModel.DataAnnotations;

namespace book_reservation_system.Core.Models.Book
{
    /// <summary>
    /// Represents the base data transfer object (DTO) for book-related information.
    /// </summary>
    public abstract class BaseBookDTO
    {
        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public string Author { get; set; }
    }
}
