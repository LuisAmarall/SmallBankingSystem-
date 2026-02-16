using Microsoft.EntityFrameworkCore;
using SmallBankingSystem.Domain.Models.Entities;
using SmallBankingSystem.Infrastructure.Configuration;

namespace SmallBankingSystem.Infrastructure.DataBase;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    public ApplicationContext() { }

    public DbSet<Customer> Customer { get; set; }
    public DbSet<Account> Account { get; set; }
    public DbSet<Transfer> Transfer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new TransferConfiguration());

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}