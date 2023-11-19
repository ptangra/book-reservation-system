using System.IO;
using book_reservation_system.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace book_reservation_system.Data
{
    /// <summary>
    /// Represents the database context for the book reservation system, providing access to the 'Books' and 'ReservedBooks' tables.
    /// </summary>
    public class BooksReservationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksReservationDbContext"/> class with the specified options.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public BooksReservationDbContext(DbContextOptions options)
            : base(options)
        {
            // Ensure DB is craeted - we use this so our configuration is applied to the DB on startup
            Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets the DbSet for the 'Books' table.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for the 'ReservedBooks' table.
        /// </summary>
        public DbSet<ReservedBook> ReservedBooks { get; set; }

        // <summary>
        /// Configures the relationships and initializes the model for the database context.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model for this context.</param>
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

    /// <summary>
    /// Represents a design-time factory for creating instances of the <see cref="BooksReservationDbContext"/> for use in migrations and tools.
    /// </summary>
    public class BooksReservationDbContextFactory
        : IDesignTimeDbContextFactory<BooksReservationDbContext>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="BooksReservationDbContext"/> class.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>A new instance of the <see cref="BooksReservationDbContext"/> class.</returns>
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
