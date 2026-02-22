using Microsoft.EntityFrameworkCore;
using SmallBankingSystem.Application.Interfaces.Persistence;
using SmallBankingSystem.Domain.Models.Entities;
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

    public async Task<IReadOnlyList<Transfer>> GetBySourceAccountIdAsync(Guid sourceAccountId)
    {
        return await _context.Transfers.AsNoTracking().Where(t => t.SourceAccountId == sourceAccountId).ToListAsync();
    }

    public async Task<IReadOnlyList<Transfer>> GetByTargetAccountIdAsync(Guid targetAccountId)
    {
        return await _context.Transfers.AsNoTracking().Where(t => t.TargetAccountId == targetAccountId).ToListAsync();
    }
}