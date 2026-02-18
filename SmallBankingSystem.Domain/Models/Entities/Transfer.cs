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

    public Transfer(Guid transferId, DateTime transferDate, Guid sourceAccountId, Guid targetAccountId, Money amount, TransferType type, string description)
    {
        TransferId = transferId;
        TransferDate = transferDate;
        SourceAccountId = sourceAccountId;
        TargetAccountId = targetAccountId;
        Amount = amount;
        Type = type;
        Description = description;
    }

    public Guid TransferId { get; private set; }
    public DateTime TransferDate { get; private set; }

    public Guid SourceAccountId { get; private set; }

    public Guid TargetAccountId { get; private set; }

    public Money Amount { get; private set; }

    public TransferType Type { get; private set; }
    public string Description { get; set; }
}