using System;

namespace book_reservation_system.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an entity, identified by its name and key,
    /// is not found in the system.
    /// </summary>
    public class NotFoundException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with a formatted error message.
        /// </summary>
        /// <param name="name">The name or type of the entity that was not found.</param>
        /// <param name="key">The key or identifier of the entity that was not found.</param>
        public NotFoundException(string name, object key) : base($"{name} with id ({key}) was not found")
        {
        }
    }
}
