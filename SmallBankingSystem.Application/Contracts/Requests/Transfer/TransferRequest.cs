namespace SmallBankingSystem.Application.Contracts.Requests.Transfer;

public sealed record TransferRequest(Guid OriginAccountId, Guid TargetAccountId, decimal Amount);