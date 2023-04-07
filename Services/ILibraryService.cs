using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface ILibraryService
    {
        // Author Services
        Task<List<Author>> GetAuthorsAsync(); // GET All Authors
        Task<Author> GetAuthorAsync(int id, bool includeBooks); // GET Single Author
        Task<Author> AddAuthorAsync(Author author); // POST New Author
        Task<Author> UpdateAuthorAsync(Author author); // PUT Author
        Task<(bool, string)> DeleteAuthorAsync(Author author); // DELETE Author

        // Book Services
        Task<List<Book>> GetBooksAsync(); // GET All Books
        Task<Book> GetBookAsync(int id); // Get Single Book
        Task<Book> AddBookAsync(Book book); // POST New Book
        Task<Book> UpdateBookAsync(Book book); // PUT Book
        Task<(bool, string)> DeleteBookAsync(Book book); // DELETE Book
    }
}
