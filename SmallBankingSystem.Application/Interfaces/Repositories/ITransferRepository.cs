using SmallBankingSystem.Domain.Models.Entities;

namespace SmallBankingSystem.Application.Interfaces.Persistence;

public interface ITransferRepository
{
    Task AddAsync(Transfer transfer);

    Task<Transfer> GetByIdAsync(Guid id);

    Task<IReadOnlyList<Transfer>> GetByOriginAccountIdAsync(Guid originAccountId);

    Task<IReadOnlyList<Transfer>> GetByTargetAccountIdAsync(Guid targetAccountId);

    Task SaveChangesAsync();
}