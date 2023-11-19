namespace book_reservation_system.Core.Models.Book
{
    /// <summary>
    /// Represents a data transfer object (DTO) for updating information about a book.
    /// Inherits from the <see cref="BaseBookDTO"/> class, providing common book properties.
    /// </summary>
    public class UpdateBookDTO : BaseBookDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the book.
        /// </summary>
        public int Id { get; set; }
    }
}
