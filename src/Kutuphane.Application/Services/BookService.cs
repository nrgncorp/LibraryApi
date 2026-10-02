using Kutuphane.Application.Dtos;
using Kutuphane.Application.Interfaces;
using Kutuphane.Domain.Entities;

namespace Kutuphane.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
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
        await _repository.AddAsync(newBook);
        return newBook;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var found = await _repository.GetByIdAsync(id);
        if(found == null)
        {
            return false;
        }
        await _repository.DeleteAsync(found);
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
        await _repository.SaveChangesAsync();
        return true;
    }
}