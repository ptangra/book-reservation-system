using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace book_reservation_system.Data
{
    /// <summary>
    /// Represents a book entity in the book reservation system.
    /// </summary>
    public class Book
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
        /// Gets a value indicating whether the book is reserved.
        /// </summary>
        public bool IsReserved => ReservedBook != null;

        /// <summary>
        /// Gets or sets the comment associated with the reservation, if the book is reserved.
        /// </summary>
        public string? ReserveComment => ReservedBook != null ? ReservedBook.Comment : null;

        /// <summary>
        /// Gets or sets the reserved book associated with this book, if any.
        /// </summary>
        public ReservedBook? ReservedBook { get; set; }
    }
}
