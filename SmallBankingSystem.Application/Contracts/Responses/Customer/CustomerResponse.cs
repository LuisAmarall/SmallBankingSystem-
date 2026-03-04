namespace SmallBankingSystem.Application.Contracts.Responses.Customer;

public sealed record CustomerResponse(Guid CustomerId, string IndividualsName, string Email, DateTime CreatedAt);