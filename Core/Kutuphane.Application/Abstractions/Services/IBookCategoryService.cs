using Kutuphane.Application.Dtos.BookCategory;
using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Abstractions.Services;

public interface IBookCategoryService
{
    Task<List<BookCategoryResponse>> GetAllAsync();
    Task<BookCategoryResponse?> GetByIdAsync(int id);
    Task<BookCategoryResponse?> CreateAsync(CreateBookCategoryRequest request);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(UpdateBookCategoryRequest request, int id);
}