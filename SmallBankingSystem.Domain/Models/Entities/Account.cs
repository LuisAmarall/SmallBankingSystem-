using DomainDesign.Exceptions;
using SmallBankingSystem.Domain.Models.VOsInSln;

namespace SmallBankingSystem.Domain.Models.Entities;

public class Account
{
    private Account() { } 

    private Account(Guid customerId, AccountNumber accountNumber)
    {
        AccountId = Guid.NewGuid();
        CustomerId = customerId;
        CreatedAt = DateTime.UtcNow;
        AccountNumber = accountNumber;
        Balance = Money.Zero;
    }

    public static Account Create(Guid customerId)
    {
        if (customerId == Guid.Empty)
            throw new ArgumentException("CustomerId cannot be empty.");

        return new Account(
            customerId,
            AccountNumber.Generate());
    }

    public Guid AccountId { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public AccountNumber AccountNumber { get; private set; }
    public Money Balance { get; private set; }

    public void Deposit(Money amount)
    {
        if (amount is null)
            throw new RequiredFieldException(nameof(amount));

        if (amount.IsNegativeOrZero())
            throw new InvalidValueObjectException("Deposit amount must be greater than zero.");

        Balance = Balance.AddMoney(amount);
    }

    public void Withdraw(Money amount)
    {
        if (amount is null)
            throw new RequiredFieldException(nameof(amount));

        if (amount.IsNegativeOrZero())
            throw new InvalidValueObjectException("Withdraw amount must be greater than zero.");

        if (Balance.IsLessThan(amount))
            throw new InvalidValueObjectException("Insufficient balance.");

        Balance = Balance.SubtractMoney(amount);
    }

    public void TransferTo(Account targetAccount, Money amount)
    {
        if (targetAccount is null)
            throw new ArgumentNullException(nameof(targetAccount), "Target account cannot be null.");

        if (amount is null)
            throw new ArgumentNullException(nameof(amount), "Amount cannot be null.");

        Withdraw(amount);
        targetAccount.Deposit(amount);
    }
}