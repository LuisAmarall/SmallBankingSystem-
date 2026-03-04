using SmallBankingSystem.Domain.Models.Entities;
using SmallBankingSystem.Application.Contracts.Responses.Transfer;

namespace SmallBankingSystem.Application.Mappings.TransferMappings;

public static class TransferMappings
{
    public static TransferResponse ToResponse(this Transfer transfer)
    {
        return new TransferResponse
        (
            transfer.TransferId,
            transfer.OriginAccountId,
            transfer.TargetAccountId,
            transfer.Amount.Amount,
            transfer.Status.ToString(),
            transfer.CreatedAt
        );
    }
}