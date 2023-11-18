using AutoMapper;
using book_reservation_system.Core.Models.Book;
using book_reservation_system.Core.Models.ReservedBook;
using book_reservation_system.Data;

namespace book_reservation_system.Core.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            // Map for Book Entity and its DTOs
            CreateMap<Book, CreateBookDTO>().ReverseMap();

            CreateMap<Book, GetBookDTO>().ReverseMap();

            CreateMap<Book, BookDTO>().ReverseMap();

            CreateMap<Book, UpdateBookDTO>().ReverseMap();

            // Map for ReservedBook Entity and its DTOs
            CreateMap<ReservedBook, CreateReservedBookDTO>().ReverseMap();
            CreateMap<ReservedBook, GetReservedBookDTO>().ReverseMap();
            CreateMap<ReservedBook, ReservedBookDTO>().ReverseMap();
        }
    }
}
