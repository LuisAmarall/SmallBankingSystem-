using DomainDesign.Exceptions;
using DomainDesign.Shared;
using System.Security.Cryptography;
using System.Text;

namespace SmallBankingSystem.Domain.Models.VOsInSln;

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

    public static AccountNumber Generate()
    {
        var random = new Random();
        var number = random.Next(10000000, 99999999).ToString();

        return new AccountNumber(number);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
}