using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Repositories.Books;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task<List<Book>> GetByCategoryIdAsync(int categoryId);
    Task<List<Book>> GetByAuthorIdAsync(int authorId);
    void Add(Book book);
    void Delete(Book book);
}