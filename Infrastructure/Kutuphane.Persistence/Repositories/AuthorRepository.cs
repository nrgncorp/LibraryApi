using Kutuphane.Application.Repositories.Authors;
using Kutuphane.Persistence.Contexts;
using Kutuphane.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Persistence.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDbContext _db;

    public AuthorRepository(LibraryDbContext db)
    {
        _db = db;
    }

    public async Task<List<Author>> GetAllAsync()
    {
        return await _db.Authors.ToListAsync();
    }

    public void Add(Author author)
    {
        _db.Authors.Add(author);
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _db.Authors.FirstOrDefaultAsync(a => a.Id == id);
    }

    public void Delete(Author author)
    {
        _db.Authors.Remove(author);
    }
}