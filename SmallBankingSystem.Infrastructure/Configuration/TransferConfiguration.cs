using Microsoft.EntityFrameworkCore;
using SmallBankingSystem.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmallBankingSystem.Infrastructure.Configuration;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.ToTable("Transfer");
        builder.HasKey(b => b.TransferId);

        builder.Property(b => b.TransferDate).HasColumnName("TransferDate").HasColumnType("DATETIME").IsRequired();

        builder.OwnsOne(b => b.Amount, amount =>
        {
            amount.Property(b => b.Amount).HasColumnName("Balance").HasColumnType("DECIMAL(18,2)").IsRequired();
        });

        builder.Property(b => b.Type).HasColumnName("Type").HasColumnType("INT").IsRequired();

        builder.Property(b => b.Description).HasColumnName("Description").HasColumnType("VARCHAR").HasMaxLength(200).IsRequired(false);
    }
}