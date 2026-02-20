using SmallBankingSystem.Domain.Models.VOsInSln;

namespace SmallBankingSystem.Domain.Models.Entities;

public class Transfer
{
    public enum TransferType
    {
        Deposit,
        Withdraw,
        TransferIn,
        TransferOut,
    }

    private Transfer() { }



    public Transfer(Guid sourceAccountId, Guid targetAccountId, decimal amount, TransferType type = default, string description = null, Guid transferId = default, DateTime transferDate = default)
    {
        SourceAccountId = sourceAccountId;
        TargetAccountId = targetAccountId;
        Type = type;
        Description = description;
        TransferId = transferId;
        TransferDate = transferDate;
    }

    public Guid TransferId { get; private set; }
    public DateTime TransferDate { get; private set; }

    public Guid SourceAccountId { get; private set; }

    public Guid TargetAccountId { get; private set; }

    public Money Amount { get; private set; }

    public TransferType Type { get; private set; }
    public string Description { get; set; }
}