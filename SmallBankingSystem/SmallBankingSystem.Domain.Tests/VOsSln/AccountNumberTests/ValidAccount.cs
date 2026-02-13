using SmallBankingSystem.Domain.VOsInSln;
using Xunit;

namespace SmallBankingSystem.Tests;

[TestClass]
public class ValidAccount
{
    [Fact]
    public void ShouldCreateValidAccountNumber()
    {
        var validAccountNumber = "1234567890123456";
        var accountNumber = new AccountNumber(validAccountNumber);
    
        Assert.IsNotNull(accountNumber);
    }
}