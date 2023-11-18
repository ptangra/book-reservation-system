# Book Reservation System

The Book Reservation System is a Web API project developed on ASP.NET 5. The system facilitates the management of books and reservations through two main controllers: BooksController and ReserveBooksController. The project is structured into three layers: the web project, core logic, and data access.
# Project Structure
## Web Project (book-reservation-system)

This project contains the API controllers responsible for handling book-related operations.
### BooksController

    GET Methods:
        GetBooks: Retrieve a list of books.
        GetBooksDetails: Retrieve detailed information about books.
        GetBook: Retrieve details of a specific book by ID.
        GetAvailableBooks: Retrieve a list of available books.
        GetReservedBooksDetails: Retrieve detailed information about reserved books.

    POST Method:
        PostBook: Add a new book to the system.

    PUT Method:
        PutBook: Update details of an existing book.

    DELETE Method:
        DeleteBook: Delete a book by ID.

### ReserveBooksController

    GET Method:
        GetReserveBooksDetails: Retrieve a list of reservations of books with their comment.

    POST Method:
        PostReservedBook: Reserve a book.

    DELETE Method:
        DeleteBook: Delete a reservation by BookID.

## Core Project (book-reservation-system.Core)

This project contains core logic and abstractions, including repositories, middleware, models, and mapper configurations.

    Contracts:
        IGenericRepository: Interface that defines the contract for generic data access operations.
        IBooksRepository: Interface that defines the contract for Books data access operations.
        IReservedBooksRepository: Interface that defines the contract for ReservedBooks data access operations.
        
    Repositories:
        GenericRepository: Implements basic CRUD operations and is used to abstract the data access layer.
        BooksRepository: Implements the GenericRepository and implements specific operations over the Book entity.
        ReservedBooksRepository: Implements the GenericRepository and implements specific operations over the ReservedBook entity.

    Middlewares:
        ExceptionMiddleware: Handles exceptions globally and returns structured error details.

    Models:
        Contains DTOs (Data Transfer Objects) for representing book and reserved book entities.

    Mapper Configuration:
        Configures AutoMapper for mapping between entities and DTOs.

## Data Project (book-reservation-system.Data)

This project holds data entities, the DbContext class, and initial database configurations.

    Entities:
        Book: Represents a book entity.
        ReservedBook: Represents a reserved book entity.

    DbContext:
        BooksReservationDbContext: Manages the database context and entity relationships.

    Initial Configurations:
        Configurations for seeding the database with initial data.

# Additional Features

    Exception Handling:
        Custom exceptions (BadRequestException and NotFoundException) are implemented in the ExceptionMiddleware and logged through the Microsoft Extension Logging framework.

    Logging:
        Microsoft Extension Logging is employed to log exceptions.

# Getting Started

    Clone the Repository:

    git clone https://github.com/ptangra/book-reservation-system.git

    Configure Connection String:
        Update the connection string in appsettings.json with your desired database settings.

    Run the Application:
        Build and run the application using Visual Studio or the command line.

    Explore API Endpoints:
        Access the API endpoints as documented above using tools like Postman or Swagger.

# Database Configuration

For testing purposes, the application uses an in-memory database, which is a lightweight database that runs in the application's memory space. This is ideal for testing scenarios as it provides fast and isolated data access without the need for an external database server.

## Changing Database Configuration

If you want to use a different database configuration, such as a SQL Server database, you can modify the database setup in `Startup.cs`. Locate the `ConfigureServices` method in `Startup.cs` and update the database configuration accordingly:

```csharp
// In-memory database setup (for testing purposes)
services.AddDbContext<BooksReservationDbContext>(options =>
{
    options.UseInMemoryDatabase("InMemoryDatabaseName");
});

// Example: Configuring for SQL Server
// services.AddDbContext<BooksReservationDbContext>(options =>
// {
//     options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnectionString"));
// });
```

## Dependencies

    AutoMapper
    AutoMapper.Extensions.Microsoft.DependencyInjection
    Microsoft.AspNetCore.Http.Abstraction
    Microsoft.EntityFrameworkCore
    Microsoft.EntityFrameworkCore.InMemory
    Microsoft.Extension.Configuration
    Microsoft.Extension.Configuration.Json
    Microsoft.Extension.Logging
    Newtonsoft.Json
    Swashbuckle.AspNetCore

## Contributors

    Petar Georgiev

Feel free to report issues, or suggest improvements.
