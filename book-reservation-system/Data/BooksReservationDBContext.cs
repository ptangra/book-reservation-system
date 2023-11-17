using System.IO;
using book_reservation_system.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace book_reservation_system.Data
{
    public class BooksReservationDBContext : DbContext
    {
        public BooksReservationDBContext(DbContextOptions options)
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
    //public class BooksReservationDBContextFactory
    //    : IDesignTimeDbContextFactory<BooksReservationDBContext>
    //{
    //    public BooksReservationDBContext CreateDbContext(string[] args)
    //    {
    //        IConfiguration configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //            .Build();

    //        var optionsBuilder = new DbContextOptionsBuilder<BooksReservationDBContext>();

    //        var conn = configuration.GetConnectionString("BooksReservationDbConnectionString");
    //        optionsBuilder.UseInMemoryDatabase(conn);
    //        return new BooksReservationDBContext(optionsBuilder.Options);
    //    }
    //}
}
