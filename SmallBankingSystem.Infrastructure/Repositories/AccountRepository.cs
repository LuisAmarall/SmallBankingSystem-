using Microsoft.EntityFrameworkCore;
using SmallBankingSystem.Application.Interfaces.Persistence;
using SmallBankingSystem.Domain.Models.Entities;
using SmallBankingSystem.Infrastructure.Persistence.DbContexts;

namespace SmallBankingSystem.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    public AccountRepository(WalletDbContext context)
    {
        _context = context;
    }

    private readonly WalletDbContext _context;

    public async Task<Account?> GetByIdAsync(Guid id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public async Task<Account?> GetByAccountNumberAsync(string accountNumber)
    {
        return await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber.Number == accountNumber);
    }

    public async Task AddAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
    }

    public Task UpdateAsync(Account account)
    {
        _context.Accounts.Update(account);
        return Task.CompletedTask;
    }
}