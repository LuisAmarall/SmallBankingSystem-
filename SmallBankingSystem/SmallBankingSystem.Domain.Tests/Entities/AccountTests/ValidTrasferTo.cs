using SmallBankingSystem.Domain.Entities;
using SmallBankingSystem.Domain.VOsInSln;
using Xunit;

namespace SmallBankingSystem.Tests;

[TestClass]
public class ValidTrasferTo
{
    [Fact]
    public void ShouldTransferMoneyBetweenAccount()
    {
        var sender = new Account(Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow, new AccountNumber("1234567890123456"), new Money(341.10m));
        var target = new Account(Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow, new AccountNumber("6543210987654321"), new Money(89.97m));

        var transferAmount = new Money(50m);
        sender.TransferTo(target, transferAmount);

        Assert.Equals(291.10m, sender.Balance.Amount);
    }
}