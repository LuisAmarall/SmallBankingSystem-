using SmallBankingSystem.Application.Contracts.Accounts;
using SmallBankingSystem.Domain.Models.Entities;
using SmallBankingSystem.Domain.Models.VOsInSln;

namespace SmallBankingSystem.Application.Mappings;

public static class AccountMappings
{
    public static Account ToEntity(CreateAccountRequest request)
    {
        return new Account(
            request.CustomerId,
            new AccountNumber(request.AccountNumber),
            new Money(request.InitialBalance));
    }

    public static CreateAccountResponse ToCreateResponse(Account account)
    {
        return new CreateAccountResponse
        {
            AccountId = account.AccountId,  
            AccountNumber = account.AccountNumber.Number,
            Balance = account.Balance.Amount
        };
    }

    public static GetAccountResponse ToGetResponse(Account account)
    {
        return new GetAccountResponse
        {
            AccountId = account.AccountId,
            AccountNumber = account.AccountNumber.Number,
            Balance = account.Balance.Amount,
            CustomerId = account.CustomerId
        };
    }
}