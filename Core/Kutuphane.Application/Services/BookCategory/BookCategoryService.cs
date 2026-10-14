using Kutuphane.Application.Repositories;
using Kutuphane.Application.Abstractions.Services;
using Kutuphane.Domain.Entities;
using Kutuphane.Application.Dtos.BookCategory;
using Kutuphane.Application.Repositories.Books;

namespace Kutuphane.Application.Services.BookCategorys;

public class BookCategoryService : IBookCategoryService
{
    private readonly IBookCategoryRepository _repository;
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BookCategoryService(IBookCategoryRepository repository, IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BookCategoryResponse>> GetAllAsync()
    {
        var bookCategories = await _repository.GetAllAsync();
        return bookCategories.Select(ToResponse).ToList();
    }

    public async Task<BookCategoryResponse?> GetByIdAsync(int id)
    {
        var bookCategory = await _repository.GetByIdAsync(id);
        if(bookCategory == null)
        {
            return null;
        }
        return ToResponse(bookCategory);
    }

    public async Task<BookCategoryResponse?> CreateAsync(CreateBookCategoryRequest request)
    {
        var newBookCategory = new BookCategory { Name = request.Name };
        _repository.Add(newBookCategory);
        await _unitOfWork.SaveChangesAsync();
        return ToResponse(newBookCategory);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var found = await _repository.GetByIdAsync(id);
        var CategoryBooks = await _bookRepository.GetByCategoryIdAsync(id);
        if(found == null || CategoryBooks.Count > 0)
        {
            return false;
        }
        _repository.Delete(found);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(UpdateBookCategoryRequest request, int id)
    {
        var found = await _repository.GetByIdAsync(id);
        if (found == null)
        {
            return false;
        }
        found.Name = request.Name;
        found.IsActive = request.IsActive;
        found.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    private static BookCategoryResponse ToResponse(BookCategory bookCategory)
    {
        return new BookCategoryResponse(bookCategory.Id, bookCategory.Name,  bookCategory.CreatedAt, bookCategory.UpdatedAt);
    }
}