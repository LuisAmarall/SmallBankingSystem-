using SmallBankingSystem.Domain.VOsInSln;

namespace SmallBankingSystem.Domain.Entities;

public class Transaction
{
    public enum TransactionType
    {
        Deposit,
        Withdraw,
        TransferIn,
        TransferOut,
    }

    private Transaction() { }

    public Transaction(Guid transactionId, Guid accountId, DateTime transactionDate, Money amount, TransactionType type, string description)
    {
        TransactionId = transactionId;
        AccountId = accountId;
        TransactionDate = transactionDate;
        Amount = amount;
        Type = type;
        Description = description;
    }

    public Guid TransactionId { get; private set; }
    public Guid AccountId { get; private set; }
    public DateTime TransactionDate { get; private set; }

    public Money Amount { get; private set; }

    public TransactionType Type { get; private set; }
    public string Description { get; set; }
}