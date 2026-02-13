using SmallBankingSystem.Domain.Entities;
using SmallBankingSystem.Domain.VOsInSln;
using Xunit;

namespace SmallBankingSystem.Tests;

[TestClass]
public class ValidDeposit
{
    [Fact]
    public void ShouldIncreaseBalance()
    {
        var account = new Account(Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow, new AccountNumber("1234567890123456"), new Money(100m));
        var depositAmount = new Money(211.21m);
        account.Deposit(depositAmount);

        Assert.Equals(311.21m, account.Balance.Amount);
    }
}