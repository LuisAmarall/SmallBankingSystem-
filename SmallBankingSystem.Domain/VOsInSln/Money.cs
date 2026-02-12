using DomainDesign.Exceptions;
using DomainDesign.Shared;

namespace SmallBankingSystem.Domain.VOsInSln;

public sealed class Money : ValueObject<Money>
{
    private Money() { }

    public Money(decimal amount)
    {
        ValidateAmount(amount);

        Amount = amount;
    }

    public decimal Amount { get; }

    private static void ValidateAmount(decimal amount)
    {
        if (amount < 0)
            throw new InvalidValueObjectException("Amount cannot be negative.");
        if (decimal.Round(amount, 2) != amount)
            throw new InvalidValueObjectException("Amount cannot have more than two decimal places.");
        if (amount > 1000000)
            throw new InvalidValueObjectException("Amount cannot exceed 1,000,000.");
    }

    public static Money Zero => new Money(0);

    public Money AddMoney(Money other)
    {
        if (other is null)
            throw new RequiredFieldException($"{nameof(other)}: Please note that the money field does not allow null values.");
        
        return new Money(Amount + other.Amount);
    }

    public Money SubtractMoney(Money other)
    {
        if (other is null)
            throw new RequiredFieldException($"{nameof(other)}: Please note that the money field does not allow null values.");
        if (Amount < other.Amount)
            throw new InvalidValueObjectException("Cannot subtract more than the current amount.");

        return new Money(Amount - other.Amount);
    }

    public override string ToString()
    {
        return Amount.ToString("F2");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }
}
