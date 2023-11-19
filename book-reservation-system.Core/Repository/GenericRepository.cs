using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using book_reservation_system.Core.Contracts;
using book_reservation_system.Core.Exceptions;
using book_reservation_system.Data;
using Microsoft.EntityFrameworkCore;

namespace book_reservation_system.Core.Repository
{
    /// <summary>
    /// Generic repository class providing basic CRUD operations for entities of type T.
    /// Implements the <see cref="IGenericRepository{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of entity for which the repository is generic.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        #region Fields
        // The database context for generic repository operations.
        private readonly BooksReservationDbContext _context;

        // The mapper for mapping between entities and DTOs.
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The database context for generic repository operations.</param>
        /// <param name="mapper">The mapper for mapping between entities and DTOs.</param>
        public GenericRepository(BooksReservationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds an entity of type T to the database.
        /// </summary>
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Adds an entity to the database and returns the result after mapping to a specified DTO.
        /// </summary>
        public async Task<TResult> AddAsync<TSource, TResult>(TSource source)
        {
            var entity = _mapper.Map<T>(source);

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TResult>(entity);
        }

        /// <summary>
        /// Deletes an entity of type T from the database by ID.
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);

            if (entity == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if an entity with the specified ID exists in the database.
        /// </summary>
        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        /// <summary>
        /// Retrieves a list of all entities of type T from the database.
        /// </summary>
        public async Task<List<T>> GetAllAsync()
        {
            // Get the DbSet of type T
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Retrieves a list of all entities of type T from the database, mapping them to a specified DTO.
        /// </summary>
        public async Task<List<TResult>> GetAllAsync<TResult>()
        {
            return await _context
                .Set<T>()
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves an entity of type T from the database by ID.
        /// </summary>
        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Retrieves an entity of type T from the database by ID, mapping it to a specified DTO.
        /// </summary>
        public async Task<TResult?> GetAsync<TResult>(int? id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            if (result is null)
            {
                throw new NotFoundException(typeof(T).Name, id.HasValue ? id : "No Key Provided");
            }

            return _mapper.Map<TResult>(result);
        }

        /// <summary>
        /// Updates an entity of type T in the database.
        /// </summary>
        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates an entity of type T in the database by ID, using data from a specified source.
        /// </summary>
        public async Task UpdateAsync<TSource>(int id, TSource source)
        {
            var entity = await GetAsync(id);

            if (entity == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            _mapper.Map(source, entity);
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
