using SmallBankingSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using SmallBankingSystem.Application.Interfaces.Services;

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
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ITransferService, TransferService>();
    }
}