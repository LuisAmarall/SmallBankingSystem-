using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmallBankingSystem.Application.Interfaces;
using SmallBankingSystem.Application.Interfaces.Persistence;
using SmallBankingSystem.Infrastructure.Persistence.DbContexts;
using SmallBankingSystem.Infrastructure.Repositories;

namespace SmallBankingSystem.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterDbContext(services, configuration);
        RegisterRepositories(services);

        return services;
    }

    private static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WalletDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ITransferRepository, TransferRepository>();
    }
}
