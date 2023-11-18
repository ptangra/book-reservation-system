using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_reservation_system.Core.Models.ReservedBook
{
    public abstract class BaseReservedBookDTO
    {
        [Required]
        public int BookId { get; set; }
        public string Comment { get; set; }
    }
}
