using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_reservation_system.Core.Models.Book;

namespace book_reservation_system.Core.Models.ReservedBook
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a reserved book with additional information.
    /// Inherits from the <see cref="BaseReservedBookDTO"/> class, providing common reserved book properties.
    /// </summary>
    public class ReservedBookDTO : BaseReservedBookDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the reserved book.
        /// </summary>
        public int Id { get; set; }
    }
}
