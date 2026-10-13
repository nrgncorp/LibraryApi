using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Repositories;

public interface IBookCategoryRepository
{
    Task<List<BookCategory>> GetAllAsync();
    Task<BookCategory?> GetByIdAsync(int id);
    void Add(BookCategory bookCategory);
    void Delete(BookCategory bookCategory);
}