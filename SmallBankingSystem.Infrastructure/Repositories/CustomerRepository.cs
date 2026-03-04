using DomainDesign.ValueObjects;
using Microsoft.EntityFrameworkCore;
using SmallBankingSystem.Application.Interfaces.Repositories;
using SmallBankingSystem.Infrastructure.Persistence.DbContexts;

namespace SmallBankingSystem.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public CustomerRepository(WalletDbContext context)
    {
        _context = context;
    }

    private readonly WalletDbContext _context;

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
    }

    public async Task<Customer?> GetByEmailAsync(Email email)
    {
        return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.CustomerId == id);
    }

    public Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}