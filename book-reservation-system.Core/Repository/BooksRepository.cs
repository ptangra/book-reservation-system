using AutoMapper;
using book_reservation_system.Core.Contracts;
using book_reservation_system.Data;

namespace book_reservation_system.Core.Repository
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        #region Fields
        private readonly BooksReservationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public BooksRepository(BooksReservationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        // here we can add implementation for all specific methods for the books repository
        #endregion
    }
}
