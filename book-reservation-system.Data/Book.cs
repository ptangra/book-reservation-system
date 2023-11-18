using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace book_reservation_system.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsReserved => ReservedBook != null;
        public string? ReserveComment => ReservedBook != null ? ReservedBook.Comment : null;
        public ReservedBook? ReservedBook { get; set; }
    }
}
