using SmallBankingSystem.Domain.Models.Entities;
using SmallBankingSystem.Application.Contracts.Responses.Account;

namespace SmallBankingSystem.Application.Mappings.AccountMappings;

public static class AccountMappings
{
    public static AccountResponse ToResponse(this Account account)
    {
        return new AccountResponse
        (
            account.AccountId,
            account.CustomerId,
            account.AccountNumber.Number,
            account.Balance.Amount,
            account.CreatedAt
        );
    }
}