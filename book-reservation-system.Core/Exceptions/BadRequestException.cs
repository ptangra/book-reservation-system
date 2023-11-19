using System;

namespace book_reservation_system.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a client sends a request that cannot be processed 
    /// by the server due to a client error, such as a malformed request.
    /// </summary>
    public class BadRequestException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public BadRequestException(string message) : base(message) { }
    }
}
