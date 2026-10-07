using Kutuphane.Application.Abstractions.Services;
using Kutuphane.Application.Services.Authors;
using Kutuphane.Application.Services.Books;
using Microsoft.Extensions.DependencyInjection;

namespace Kutuphane.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();
    }
}
