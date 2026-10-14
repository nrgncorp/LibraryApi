using Kutuphane.Application.Repositories.Books;
using Kutuphane.Persistence.Contexts;
using Kutuphane.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _db;

    public BookRepository(LibraryDbContext db)
    {
        _db = db;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _db.Books.ToListAsync();
    }

    public void Add(Book book)
    {
        _db.Books.Add(book);
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Book>> GetByCategoryIdAsync(int categoryId)
    {
        return await _db.Books.Where(b => b.CategoryId == categoryId).ToListAsync();
    }

    public async Task<List<Book>> GetByAuthorIdAsync(int authorId)
    {
        return await _db.Books.Where(b => b.AuthorId == authorId).ToListAsync();
    }

    public void Delete(Book book)
    {
        _db.Books.Remove(book);
    }
}