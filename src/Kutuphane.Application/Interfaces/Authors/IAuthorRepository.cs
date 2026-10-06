using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Interfaces.Authors;

public interface IAuthorRepository
{
    Task<List<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);
    void Add(Author author);
    void Delete(Author author);
}