namespace SmallBankingSystem.Application.Contracts.Accounts;

public sealed class GetAccountResponse
{
    public Guid CustomerId { get; init; }
    public string AccountNumber { get; init; } = string.Empty;
    public decimal Balance { get; init; }
    public Guid AccountId { get; init; }
}