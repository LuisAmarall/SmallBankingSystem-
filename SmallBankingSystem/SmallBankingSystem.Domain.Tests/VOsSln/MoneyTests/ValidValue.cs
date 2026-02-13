using SmallBankingSystem.Domain.VOsInSln;
using Xunit;

namespace SmallBankingSystem.Tests;

[TestClass]
public class ValidValue
{
    [Fact]
    public void ShouldCreateMoneyWithValidValue()
    {
        var money = new Money(100.50m);
        Assert.Equals(100.50m, money.Amount);
    }
}
