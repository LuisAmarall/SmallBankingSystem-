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

    public Transfer(Guid transferId, Guid accountId, DateTime transactionDate, Money amount, TransferType type, string description)
    {
        TransferId = transferId;
        AccountId = accountId;
        TransferDate = transactionDate;
        Amount = amount;
        Type = type;
        Description = description;
    }

    public Guid TransferId { get; private set; }
    public Guid AccountId { get; private set; }
    public DateTime TransferDate { get; private set; }

    public Money Amount { get; private set; }

    public TransferType Type { get; private set; }
    public string Description { get; set; }
}