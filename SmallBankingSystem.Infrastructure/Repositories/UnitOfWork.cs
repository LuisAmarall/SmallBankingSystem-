using SmallBankingSystem.Application.Interfaces;
using SmallBankingSystem.Infrastructure.Persistence.DbContexts;

namespace SmallBankingSystem.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(WalletDbContext context)
    {
        _context = context;
    }

    private readonly WalletDbContext _context;

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}