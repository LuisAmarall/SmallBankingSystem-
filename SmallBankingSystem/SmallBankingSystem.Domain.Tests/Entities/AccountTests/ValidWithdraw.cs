using SmallBankingSystem.Domain.Entities;
using SmallBankingSystem.Domain.VOsInSln;
using Xunit;

namespace SmallBankingSystem.Tests;

[TestClass]
public class ValidWithdraw
{
    [Fact]
    public void ShouldDecreaseBalance()
    {
        var account = new Account(Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow, new AccountNumber("1234567890123456"), new Money(341.10m));
        var withdrawAmount = new Money(178.54m);
        account.Withdraw(withdrawAmount);

        Assert.Equals(162.56m, account.Balance.Amount);
    }
}