using book_reservation_system.Core.Models.ReservedBook;

namespace book_reservation_system.Core.Models.Book
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        // add references for M:M, 1:M, M:1, 1:1 in this class
    }
}
