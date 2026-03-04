namespace SmallBankingSystem.Application.Contracts.Requests.Customer;

public sealed record CreateCustomerRequest(string IndividualsName, string Email, string Key);