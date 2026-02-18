using SmallBankingSystem.Domain.Models.Entities;

namespace SmallBankingSystem.Application.Interfaces.Persistence;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(Guid id);

    Task<Account?> GetByAccountNumberAsync(string accountNumber);

    Task AddAsync(Account account);

    Task UpdateAsync(Account account);
}