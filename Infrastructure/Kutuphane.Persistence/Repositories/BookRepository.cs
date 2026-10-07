using Kutuphane.Application.Interfaces.Books;
using Kutuphane.Domain.Entities;
using Kutuphane.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Infrastructure.Repositories;

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