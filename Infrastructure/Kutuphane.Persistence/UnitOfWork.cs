using Kutuphane.Application.Repositories;
using Kutuphane.Persistence.Contexts;

namespace Kutuphane.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _db;

    public UnitOfWork(LibraryDbContext db)
    {
        _db = db;
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}