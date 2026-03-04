using DomainDesign.ValueObjects;

namespace SmallBankingSystem.Application.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);

    Task<Customer?> GetByIdAsync(Guid id);

    Task<Customer?> GetByEmailAsync(Email email);

    Task UpdateAsync(Customer customer);

    Task SaveChangesAsync();
}