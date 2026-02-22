using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SmallBankingSystem.Infrastructure.Persistence.DbContexts;

public class WalletDbContextFactory : IDesignTimeDbContextFactory<WalletDbContext>
{
    public WalletDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WalletDbContext>();

        optionsBuilder.UseSqlServer(
            "Data Source = BAGRE; Initial Catalog = SmallBankingSystem; Integrated Security = True; Connect Timeout = 30;Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False");

        return new WalletDbContext(optionsBuilder.Options);
    }
}