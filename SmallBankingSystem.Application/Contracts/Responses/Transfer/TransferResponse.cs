namespace SmallBankingSystem.Application.Contracts.Responses.Transfer;

public sealed record TransferResponse(Guid TransferId, Guid OriginAccountId, Guid TargetAccountId, decimal Amount, string Status, DateTime CreatedAt);