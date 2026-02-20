namespace SmallBankingSystem.Application.Contracts.Accounts;

public sealed class CreateAccountRequest
{
    public Guid CustomerId { get; init; }
    public string AccountNumber { get; init; } = string.Empty;
    public decimal InitialBalance { get; init; }    
}