using SmallBankingSystem.Domain.VOsInSln;

namespace SmallBankingSystem.Domain.Entities;

public class Account
{
    private Account() { }

    public Account(Guid accountId, Guid customerId, DateTime createdAt, AccountNumber accountNumber, Money balance)
    {
        AccountId = accountId;
        CustomerId = customerId;
        CreatedAt = createdAt;
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public Guid AccountId { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public AccountNumber AccountNumber { get; private set; }
    public Money Balance { get; private set; }

    public void Deposit(Money amount)
    {
        if (amount is null)
            throw new ArgumentNullException(nameof(amount), "Amount cannot be null.");

        Balance = Balance.AddMoney(amount);
    }

    public void Withdraw(Money amount)
    {
        if (amount is null)
            throw new ArgumentNullException(nameof(amount), "Amount cannot be null.");

        Balance = Balance.SubtractMoney(amount);
    }

    public void TransferTo(Account target, Money amount)
    {
        if (target is null)
            throw new ArgumentNullException(nameof(target), "Target account cannot be null.");
        if (amount is null)
            throw new ArgumentNullException(nameof(amount), "Amount cannot be null.");

        this.Withdraw(amount);
        target.Deposit(amount);
    }
}