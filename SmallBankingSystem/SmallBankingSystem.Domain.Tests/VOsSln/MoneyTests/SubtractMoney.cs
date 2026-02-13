using SmallBankingSystem.Domain.VOsInSln;
using Xunit;

namespace SmallBankingSystem.Tests;

[TestClass]
public class SubtractMoney
{
    [Fact]
    public void ShouldSubtractMoneyCorrectly()
    {
        var first = new Money(739.00m);
        var second = new Money(118.33m);
        var result = first.SubtractMoney(second);

        Assert.Equals(620.67m, result.Amount);
    }
}
