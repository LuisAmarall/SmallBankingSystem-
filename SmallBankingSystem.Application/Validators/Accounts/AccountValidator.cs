using DomainDesign.Exceptions;
using SmallBankingSystem.Application.Contracts.Accounts;
using System.Diagnostics;

namespace SmallBankingSystem.Application.Validators.Accounts;

public sealed class AccountValidator
{
    public static void Validate(CreateAccountRequest request)
    {
        if (request is null)
            throw new RequiredFieldException($"{nameof(request)}: Please note that the request field does not allow null values.");

        if (request.CustomerId == Guid.Empty)
            throw new RequiredFieldException($"{nameof(request.CustomerId)}: Please note that the customer id field does not allow null values.");

        if (string.IsNullOrWhiteSpace(request.AccountNumber))
            throw new RequiredFieldException($"{nameof(request.AccountNumber)}: Please note that the account number field does not allow null or empty values.");

        if (request.InitialBalance < 0)
            throw new InvalidValueObjectException($"{nameof(request.InitialBalance)}: Please note that the initial balance field must be greater than or equal to zero.");
    }
}