using Kutuphane.Application.Dtos.Books;
using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Abstractions.Services;

public interface IBookService
{
    Task<List<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task<Book> CreateAsync(CreateBookRequest request);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(UpdateBookRequest request, int id);
}