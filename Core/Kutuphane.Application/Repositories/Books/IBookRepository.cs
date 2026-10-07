using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Interfaces.Books;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    void Add(Book book);
    void Delete(Book book);
}