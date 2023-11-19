using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace book_reservation_system.Data
{
    /// <summary>
    /// Represents a reserved book entity in the book reservation system.
    /// </summary>
    public class ReservedBook
    {
        /// <summary>
        /// Gets or sets the unique identifier for the reserved book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the associated book's unique identifier.
        /// </summary>
        [Required]
        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the associated book entity.
        /// </summary>
        public virtual Book Book { get; set; }

        /// <summary>
        /// Gets or sets the comment associated with the reservation.
        /// </summary>
        [Required]
        public string Comment { get; set; }
    }
}
