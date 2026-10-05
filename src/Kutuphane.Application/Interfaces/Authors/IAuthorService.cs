using Kutuphane.Application.Dtos;
using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Interfaces;

public interface IAuthorService
{
    Task<List<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);
    Task<Author> CreateAsync(CreateAuthorRequest request);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(UpdateAuthorRequest request, int id);
}