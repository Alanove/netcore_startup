using Microsoft.Extensions.DependencyInjection;

namespace lw.Domain.Services;
public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        return services;
    }
}