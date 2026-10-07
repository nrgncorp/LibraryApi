using Kutuphane.Application.Repositories;
using Kutuphane.Application.Repositories.Authors;
using Kutuphane.Application.Repositories.Books;
using Kutuphane.Persistence.Contexts;
using Kutuphane.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kutuphane.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Library")));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
