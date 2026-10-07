using Kutuphane.Application.Interfaces;

namespace Kutuphane.Infrastructure.Data;

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