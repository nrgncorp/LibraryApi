using Kutuphane.Infrastructure.Data;
using Kutuphane.Application.Dtos;
using Kutuphane.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Kutuphane.Application.Interfaces;

namespace KutuphaneApi.Services;

public class BookService : IBookService
{
    private readonly LibraryDbContext _db;

    public BookService(LibraryDbContext db)
    {
        _db = db;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _db.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Book> CreateAsync(CreateBookRequest request)
    {
        var newBook = new Book { Title = request.Title, Author = request.Author };
        _db.Books.Add(newBook);
        await _db.SaveChangesAsync();
        return newBook;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var found = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
        if(found == null)
        {
            return false;
        }
        _db.Books.Remove(found);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(UpdateBookRequest request, int id)
    {
        var found = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (found == null)
        {
            return false;
        }
        found.Title = request.Title;
        found.Author = request.Author;
        await _db.SaveChangesAsync();
        return true;
    }
}