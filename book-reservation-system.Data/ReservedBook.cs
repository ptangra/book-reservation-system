using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace book_reservation_system.Data
{
    public class ReservedBook
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
