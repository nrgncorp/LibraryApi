using Kutuphane.Persistence.Contexts;
using Kutuphane.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Kutuphane.Application.Repositories;

namespace Kutuphane.Persistence.Repositories;

public class BookCategoryRepository : IBookCategoryRepository
{
    private readonly LibraryDbContext _db;

    public BookCategoryRepository(LibraryDbContext db)
    {
        _db = db;
    }

    public async Task<List<BookCategory>> GetAllAsync()
    {
        return await _db.BookCategories.ToListAsync();
    }

    public void Add(BookCategory bookCategory)
    {
        _db.BookCategories.Add(bookCategory);
    }

    public async Task<BookCategory?> GetByIdAsync(int id)
    {
        return await _db.BookCategories.FirstOrDefaultAsync(b => b.Id == id);
    }


    public void Delete(BookCategory bookCategory)
    {
        _db.BookCategories.Remove(bookCategory);
    }
}