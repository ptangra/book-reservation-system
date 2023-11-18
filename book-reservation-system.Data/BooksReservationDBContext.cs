using System.IO;
using book_reservation_system.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace book_reservation_system.Data
{
    public class BooksReservationDbContext : DbContext
    {
        public BooksReservationDbContext(DbContextOptions options)
            : base(options)
        {
            // Ensure DB is craeted - we use this so our configuration is applied to the DB on startup
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<ReservedBook> ReservedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set up cascade deletion on ReservedBook table if FK is deleted from Book
            modelBuilder.Entity<Book>()
              .HasOne(b => b.ReservedBook)
              .WithOne(r => r.Book)
              .HasForeignKey<ReservedBook>(b => b.BookId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }

    public class BooksReservationDbContextFactory
        : IDesignTimeDbContextFactory<BooksReservationDbContext>
    {
        public BooksReservationDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BooksReservationDbContext>();

            var conn = configuration.GetConnectionString("BooksReservationDbConnectionString");
            optionsBuilder.UseInMemoryDatabase(conn);
            return new BooksReservationDbContext(optionsBuilder.Options);
        }
    }
}
