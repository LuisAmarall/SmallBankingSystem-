using DomainDesign.Exceptions;
using SmallBankingSystem.Domain.VOsInSln;
using Xunit;

namespace SmallBankingSystem.Tests;

[TestClass]
public class NegativeValue
{
    [Fact]
    public void ShouldNotAllowNegativeValue()
    {
        Assert.ThrowsException<InvalidValueObjectException>(() => new Money(-10));
    }

}
