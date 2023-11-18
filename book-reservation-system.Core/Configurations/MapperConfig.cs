using AutoMapper;
using book_reservation_system.Core.Models.Book;
using book_reservation_system.Data;

namespace book_reservation_system.Core.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Book, CreateBookDTO>().ReverseMap();

            CreateMap<Book, GetBookDTO>().ReverseMap();

            CreateMap<Book, BookDTO>().ReverseMap();

            CreateMap<Book, UpdateBookDTO>().ReverseMap();
        }
    }
}
