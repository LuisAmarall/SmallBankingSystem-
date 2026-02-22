using DomainDesign.Exceptions;
using SmallBankingSystem.Domain.Models.VOsInSln;
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
