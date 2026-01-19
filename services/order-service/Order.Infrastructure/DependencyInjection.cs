using Microsoft.Extensions.DependencyInjection;
using Order.Application.Interfaces;
using Order.Infrastructure.Persistence;

namespace Order.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
        return services;
    }
}
