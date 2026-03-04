using Microsoft.EntityFrameworkCore;
using SmallBankingSystem.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmallBankingSystem.Infrastructure.Persistence.Configuration;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.ToTable("Transfers");
        builder.HasKey(b => b.TransferId);

        builder.Property(b => b.OriginAccountId).HasColumnName("OriginAccountId").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

        builder.Property(b => b).HasColumnName("TargetAccountId").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

        builder.OwnsOne(b => b.Amount, amount =>
        {
            amount.Property(b => b.Amount).HasColumnName("Balance").HasColumnType("DECIMAL(18,2)").IsRequired();
        });

        builder.Property(b => b.CreatedAt).HasColumnName("CreatedAt").HasColumnType("DATETIME").IsRequired();

        builder.Property(b => b.Status).HasColumnName("Type").HasColumnType("INT").IsRequired();
    }
} 