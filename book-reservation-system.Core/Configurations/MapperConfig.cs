using AutoMapper;
using book_reservation_system.Core.Models.Book;
using book_reservation_system.Core.Models.ReservedBook;
using book_reservation_system.Data;

namespace book_reservation_system.Core.Configurations
{
    /// <summary>
    /// Configuration class for AutoMapper mappings between entities and their Data Transfer Objects (DTOs).
    /// </summary>
    public class MapperConfig : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperConfig"/> class.
        /// </summary>
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
