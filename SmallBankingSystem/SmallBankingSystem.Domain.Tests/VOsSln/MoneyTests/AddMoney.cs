using SmallBankingSystem.Domain.VOsInSln;
using Xunit;

namespace SmallBankingSystem.Tests;

[TestClass]
public class AddMoney
{
    [Fact]
    public void ShouldAddMoneyCorrectly()
    {
        var first = new Money(100.00m);
        var second = new Money(214.76m);
        var result = first.AddMoney(second);

        Assert.Equals(314.76m, result.Amount);
    }
}
