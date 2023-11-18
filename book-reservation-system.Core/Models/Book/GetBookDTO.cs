using System.ComponentModel.DataAnnotations.Schema;
using book_reservation_system.Core.Models.ReservedBook;

namespace book_reservation_system.Core.Models.Book
{
    public class GetBookDTO : BaseBookDTO
    {
        public int Id { get; set; }
        //public bool IsReserved { get; set; }
        //{
        //    get { return ReservedBook != null; }
        //}
        //public GetReservedBookDTO? ReservedBook { get; set; }
    }
}
