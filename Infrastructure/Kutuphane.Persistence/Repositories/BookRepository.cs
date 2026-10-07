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

    public void Delete(Book book)
    {
        _db.Books.Remove(book);
    }
}