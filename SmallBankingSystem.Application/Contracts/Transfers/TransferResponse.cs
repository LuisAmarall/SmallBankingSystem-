namespace SmallBankingSystem.Application.Contracts.Transfers;

public sealed class TransferResponse
{
    public Guid TransferId { get; init; }
    public Guid SourceAccountId { get; init; }
    public Guid TargetAccountId { get; init; }
    public decimal Amount { get; init; }
    public DateTime CreatedAt { get; init; }
}