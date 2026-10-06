namespace Kutuphane.Application.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}