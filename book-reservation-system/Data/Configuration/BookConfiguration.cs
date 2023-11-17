using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace book_reservation_system.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "ABSALOM!ABSALOM!",
                    Author = "William Faulkner"
                },
                new Book
                {
                    Id = 2,
                    Title = "A TIME TO KILL",
                    Author = "John Grisham"
                },
                new Book
                {
                    Id = 3,
                    Title = "THE HOUSE OF MIRTH",
                    Author = "Edith Wharton"
                },
                new Book
                {
                    Id = 4,
                    Title = "EAST OF EDEN",
                    Author = "John Steinbeck"
                }
            );
        }
    }
}
