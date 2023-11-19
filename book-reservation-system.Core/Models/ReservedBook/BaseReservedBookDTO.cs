using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_reservation_system.Core.Models.ReservedBook
{
    /// <summary>
    /// Represents a base data transfer object (DTO) for reserved books, containing common properties.
    /// </summary>
    public abstract class BaseReservedBookDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the associated book.
        /// </summary>
        [Required]
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the comment associated with the reserved book.
        /// </summary>
        public string Comment { get; set; }
    }
}
