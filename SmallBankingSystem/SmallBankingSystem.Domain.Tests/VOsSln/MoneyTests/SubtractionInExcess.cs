using DomainDesign.Exceptions;
using SmallBankingSystem.Domain.VOsInSln;
using Xunit;

namespace SmallBankingSystem.Tests;

[TestClass]
public class SubtractionInExcess
{
    [Fact]
    public void ShouldThrowExceptionWhenSubtractingMoreThanBalance()
    {
        var first = new Money(50);
        var second = new Money(100);

        Assert.ThrowsException<InvalidValueObjectException>(() => first.SubtractMoney(second));
    }
}
