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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }

    // If moved to seperate project
    // Requires Microsoft.Extensions.Configuration & Microsoft.Extensions.Configuration.Json packages
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
