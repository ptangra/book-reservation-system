using System.ComponentModel.DataAnnotations;

namespace book_reservation_system.Core.Models.Book
{
    public abstract class BaseBookDTO
    {
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
