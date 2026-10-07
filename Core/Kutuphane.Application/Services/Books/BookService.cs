using Kutuphane.Application.Repositories.Books;
using Kutuphane.Application.Repositories;
using Kutuphane.Application.Abstractions.Services;
using Kutuphane.Application.Dtos.Books;
using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Services.Books;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public BookService(IBookRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Book> CreateAsync(CreateBookRequest request)
    {
        var newBook = new Book { Title = request.Title, Author = request.Author };
        _repository.Add(newBook);
        await _unitOfWork.SaveChangesAsync();
        return newBook;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var found = await _repository.GetByIdAsync(id);
        if(found == null)
        {
            return false;
        }
        _repository.Delete(found);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(UpdateBookRequest request, int id)
    {
        var found = await _repository.GetByIdAsync(id);
        if (found == null)
        {
            return false;
        }
        found.Title = request.Title;
        found.Author = request.Author;
        found.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}