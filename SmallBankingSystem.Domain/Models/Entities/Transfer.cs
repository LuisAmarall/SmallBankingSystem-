using SmallBankingSystem.Domain.Models.VOsInSln;

namespace SmallBankingSystem.Domain.Models.Entities;

public class Transfer
{
    public enum TransferStatus
    {
        Pending = 1,
        Completed = 2,
        Failed = 3
    }

    private Transfer() { }

    public Transfer(Guid originAccountId, Guid targetAccountId, Money amount)
    {
        if (originAccountId == Guid.Empty)
            throw new ArgumentException("Origin account cannot be empty.");

        if (targetAccountId == Guid.Empty)
            throw new ArgumentException("Target account cannot be empty.");

        if (originAccountId == targetAccountId)
            throw new InvalidOperationException("Cannot transfer to the same account.");

        if (amount is null || amount.IsNegativeOrZero())
            throw new InvalidOperationException("Transfer amount must be greater than zero.");

        TransferId = Guid.NewGuid();
        OriginAccountId = originAccountId;
        TargetAccountId = targetAccountId;
        Amount = amount;
        CreatedAt = DateTime.UtcNow;
        Status = TransferStatus.Pending;
    }

    public Guid TransferId { get; private set; }
    public Guid OriginAccountId { get; private set; }
    public Guid TargetAccountId { get; private set; }

    public Money Amount { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public TransferStatus Status { get; private set; }

    public void MarkAsCompleted()
    {
        if (Status != TransferStatus.Pending)
            throw new InvalidOperationException("Transfer cannot be completed.");

        Status = TransferStatus.Completed;
    }

    public void MarkAsFailed()
    {
        if (Status != TransferStatus.Pending)
            throw new InvalidOperationException("Transfer cannot be marked as failed.");

        Status = TransferStatus.Failed;
    }
}