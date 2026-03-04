namespace SmallBankingSystem.Application.Contracts.Responses.Account;

public sealed record AccountResponse(Guid AccountId, Guid CustomerId, string AccountNumber, decimal Balance, DateTime CreatedAt);