using DomainDesign.Exceptions;
using SmallBankingSystem.Application.Contracts.Transfers;

namespace SmallBankingSystem.Application.Validators.Transfers;

public sealed class TransferValidator
{
    public static void Validate(CreateTransferRequest request)
    {
        if (request is null)
            throw new RequiredFieldException($"{nameof(request)}: Please note that the id field does not allow null values.");

        if (request.SourceAccountId == Guid.Empty)
            throw new RequiredFieldException($"{nameof(request.SourceAccountId)}: Please note that the source account id field does not allow null values.");

        if (request.TargetAccountId == Guid.Empty)
            throw new RequiredFieldException($"{nameof(request.TargetAccountId)}: Please note that the target account id field does not allow null values.");

        if (request.Amount <= 0)
            throw new InvalidValueObjectException($"{nameof(request.Amount)}: Please note that the amount field must be greater than zero.");
    }
}