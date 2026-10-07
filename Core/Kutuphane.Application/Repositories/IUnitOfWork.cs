namespace Kutuphane.Application.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}