using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallBankingSystem.Domain.Models.Entities;

namespace SmallBankingSystem.Infrastructure.Persistence.DbContexts.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        builder.HasKey(b => b.AccountId);

        builder.Property(b => b.CustomerId).HasColumnName("CustomerId").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

        builder.Property(b => b.CreatedAt).HasColumnName("CreatedAt").HasColumnType("DATETIME").IsRequired();

        builder.OwnsOne(b => b.AccountNumber, accountNumber =>
        {
            accountNumber.Property(b => b.Number).HasColumnName("AccountNumber").HasColumnType("VARCHAR").HasMaxLength(16).IsRequired();
        });

        builder.OwnsOne(b => b.Balance, balance =>
        {
            balance.Property(b => b.Amount).HasColumnName("Balance").HasColumnType("DECIMAL(18,2)").IsRequired();
        });
    }
}