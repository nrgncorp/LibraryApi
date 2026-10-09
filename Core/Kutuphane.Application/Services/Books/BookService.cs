using Kutuphane.Application.Repositories.Books;
using Kutuphane.Application.Repositories;
using Kutuphane.Application.Abstractions.Services;
using Kutuphane.Application.Dtos.Books;
using Kutuphane.Domain.Entities;
using Kutuphane.Application.Repositories.Authors;

namespace Kutuphane.Application.Services.Books;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BookService(IBookRepository repository, IUnitOfWork unitOfWork, IAuthorRepository authorRepository)
    {
        _repository = repository;
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BookResponse>> GetAllAsync()
    {
        var books = await _repository.GetAllAsync();
        return books.Select(ToResponse).ToList();
    }

    public async Task<BookResponse?> GetByIdAsync(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        if(book == null)
        {
            return null;
        }
        return ToResponse(book);
    }

    public async Task<BookResponse?> CreateAsync(CreateBookRequest request)
    {
        var author = await _authorRepository.GetByIdAsync(request.AuthorId!.Value);
        if (author == null){
            return null;
        }
        var newBook = new Book { Title = request.Title, AuthorId = request.AuthorId!.Value };
        _repository.Add(newBook);
        await _unitOfWork.SaveChangesAsync();
        return ToResponse(newBook);
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
        var author = await _authorRepository.GetByIdAsync(request.AuthorId!.Value);
        if (author == null){
            return false;
        }
        var found = await _repository.GetByIdAsync(id);
        if (found == null)
        {
            return false;
        }
        found.Title = request.Title;
        found.AuthorId = request.AuthorId!.Value;
        found.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    private static BookResponse ToResponse(Book book)
    {
        return new BookResponse(book.Id, book.Title, book.AuthorId, book.CreatedAt, book.UpdatedAt);
    }
}