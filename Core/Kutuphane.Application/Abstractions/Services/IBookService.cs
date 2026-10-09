using Kutuphane.Application.Dtos.Books;
using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Abstractions.Services;

public interface IBookService
{
    Task<List<BookResponse>> GetAllAsync();
    Task<BookResponse?> GetByIdAsync(int id);
    Task<BookResponse?> CreateAsync(CreateBookRequest request);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(UpdateBookRequest request, int id);
}