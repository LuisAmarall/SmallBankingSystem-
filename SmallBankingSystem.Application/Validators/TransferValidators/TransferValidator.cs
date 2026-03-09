using DomainDesign.Exceptions;
using SmallBankingSystem.Application.Contracts.Requests.Transfer;

namespace SmallBankingSystem.Application.Validators.Transfers;

public sealed class TransferValidator
{
    public static void Validate(TransferRequest request)
    {
        if (request is null)
            throw new RequiredFieldException($"{nameof(request)} cannot be null.");

        if (request.OriginAccountId == Guid.Empty)
            throw new RequiredFieldException($"{nameof(request.OriginAccountId)}: Please note that the source account id field does not allow null values.");

        if (request.TargetAccountId == Guid.Empty)
            throw new RequiredFieldException($"{nameof(request.TargetAccountId)}: Please note that the target account id field does not allow null values.");

        if (request.OriginAccountId == request.TargetAccountId)
            throw new InvalidValueObjectException($"{nameof(request.OriginAccountId)} and {nameof(request.TargetAccountId)}: Please note that the source account id and target account id fields cannot be the same.");

        if (request.Amount <= 0)
            throw new InvalidValueObjectException($"{nameof(request.Amount)}: Please note that the amount field must be greater than zero.");
    }
}