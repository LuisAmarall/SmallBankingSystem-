namespace SmallBankingSystem.Application.Contracts.Accounts;

public sealed class CreateAccountResponse
{
    public Guid CustomerId { get; init; }
    public string AccountNumber { get; init; } = string.Empty;
    public decimal Balance { get; init; }
    public Guid AccountId { get; internal set; }
}