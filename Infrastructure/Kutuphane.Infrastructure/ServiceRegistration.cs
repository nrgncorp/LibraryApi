using Microsoft.Extensions.DependencyInjection;

namespace Kutuphane.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        // Dış servisler (JWT token üretimi, e-posta, dosya depolama...) buraya kaydedilecek.
    }
}
