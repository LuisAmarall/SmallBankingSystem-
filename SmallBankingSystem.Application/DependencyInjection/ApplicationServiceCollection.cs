using Microsoft.Extensions.DependencyInjection;
using SmallBankingSystem.Application.Services;

namespace SmallBankingSystem.Application.DependencyInjection;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        RegisterServices(services);

        return services;
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<TransferService>();
    }
}