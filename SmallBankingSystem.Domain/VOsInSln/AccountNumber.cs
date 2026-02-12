using DomainDesign.Exceptions;
using DomainDesign.Shared;

namespace SmallBankingSystem.Domain.VOsInSln;

public sealed class AccountNumber : ValueObject<AccountNumber>
{
    private AccountNumber() { }

    public AccountNumber(string number)
    {
        ValidateNumber(number);

        Number = number;
    }

    public string Number { get; }

    private static void ValidateNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            throw new InvalidValueObjectException("Account number cannot be empty.");
        if (number.Length != 16)
            throw new InvalidValueObjectException("Account number must be exactly 16 characters long.");
        if (!number.All(char.IsDigit))
            throw new InvalidValueObjectException("Account number must contain only digits.");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
}