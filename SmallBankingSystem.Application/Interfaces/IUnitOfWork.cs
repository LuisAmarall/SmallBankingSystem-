namespace SmallBankingSystem.Application.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}