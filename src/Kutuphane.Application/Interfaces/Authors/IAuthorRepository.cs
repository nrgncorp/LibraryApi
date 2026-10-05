using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Interfaces;

public interface IAuthorRepository
{
    Task<List<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);
    Task AddAsync(Author author);
    Task DeleteAsync(Author author);
    Task SaveChangesAsync();
}