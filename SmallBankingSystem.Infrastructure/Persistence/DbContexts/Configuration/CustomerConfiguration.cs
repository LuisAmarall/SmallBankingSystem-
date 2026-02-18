using Microsoft.EntityFrameworkCore;
using SmallBankingSystem.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmallBankingSystem.Infrastructure.Persistence.DbContexts.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(b => b.CustomerId);

        builder.Property(b => b.CreatedAt).HasColumnName("CreatedAt").HasColumnType("DATETIME").IsRequired();

        builder.OwnsOne(b => b.Name, name =>
        {
            name.Property(b => b.IndividualsName).HasColumnName("Name").HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
        });

        builder.OwnsOne(b => b.Email, email =>
        {
            email.Property(b => b.EmailAddress).HasColumnName("Email").HasColumnType("VARCHAR").HasMaxLength(80).IsRequired();
        });

        builder.OwnsOne(b => b.Password, password =>
        {
            password.Property(b => b.Key).HasColumnName("Password").HasColumnType("VARCHAR").HasMaxLength(10).IsRequired();
        });
    }
}