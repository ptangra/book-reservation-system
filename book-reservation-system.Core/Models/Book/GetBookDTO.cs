using System.ComponentModel.DataAnnotations.Schema;
using book_reservation_system.Core.Models.ReservedBook;

namespace book_reservation_system.Core.Models.Book
{
    /// <summary>
    /// Represents a data transfer object (DTO) for retrieving basic information about a book.
    /// Inherits from the <see cref="BaseBookDTO"/> class, providing common book properties.
    /// </summary>
    public class GetBookDTO : BaseBookDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the book.
        /// </summary>
        public int Id { get; set; }
    }
}
