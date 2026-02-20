namespace SmallBankingSystem.Application.Contracts.Transfers;

public sealed class CreateTransferRequest
{
    public Guid SourceAccountId { get; init; }
    public Guid TargetAccountId { get; init; }
    public decimal Amount { get; init; }
}