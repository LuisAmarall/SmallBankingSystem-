using Microsoft.EntityFrameworkCore;
using SmallBankingSystem.Domain.Models.Entities;
using SmallBankingSystem.Application.Interfaces.Persistence;
using SmallBankingSystem.Infrastructure.Persistence.DbContexts;

namespace SmallBankingSystem.Infrastructure.Repositories;

public class TransferRepository : ITransferRepository
{
    public TransferRepository(WalletDbContext dbContext)
    {
        _context = dbContext;
    }

    private readonly WalletDbContext _context;

    public async Task AddAsync(Transfer transfer)
    {
        await _context.Transfers.AddAsync(transfer);
    }

    public async Task<Transfer?> GetByIdAsync(Guid id)
    {
        return await _context.Transfers.FindAsync(id);
    }

    public async Task<IReadOnlyList<Transfer>> GetByOriginAccountIdAsync(Guid originAccountId)
    {
        return await _context.Transfers.AsNoTracking().Where(t => t.OriginAccountId == originAccountId).ToListAsync();
    }

    public async Task<IReadOnlyList<Transfer>> GetByTargetAccountIdAsync(Guid targetAccountId)
    {
        return await _context.Transfers.AsNoTracking().Where(t => t.TargetAccountId == targetAccountId).ToListAsync();
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}