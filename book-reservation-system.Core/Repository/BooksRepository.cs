using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using book_reservation_system.Core.Contracts;
using book_reservation_system.Data;
using Microsoft.EntityFrameworkCore;

namespace book_reservation_system.Core.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksReservationDbContext _context;

        public BooksRepository(BooksReservationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddAsync(Book entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            // Get the DbSet of type T
            return await _context.Set<Book>().ToListAsync();
        }
    }
}
