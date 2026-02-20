using SmallBankingSystem.Application.Contracts.Transfers;
using SmallBankingSystem.Domain.Models.Entities;

namespace SmallBankingSystem.Application.Mappings.Transfers;

public static class TransferMappings
{
    public static TransferResponse ToResponse(this Transfer transfer)
    {
        return new TransferResponse
        {
            TransferId = transfer.TransferId,
            SourceAccountId = transfer.SourceAccountId,
            TargetAccountId = transfer.TargetAccountId,
            Amount = transfer.Amount.Amount,
            CreatedAt = transfer.TransferDate
        };
    }

    public static Transfer ToEntity(this CreateTransferRequest request)
    {
        return new Transfer(
            request.SourceAccountId,
            request.TargetAccountId,
            request.Amount
        );
    }
}