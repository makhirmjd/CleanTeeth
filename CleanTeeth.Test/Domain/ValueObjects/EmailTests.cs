using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.ValueObjects;

[TestClass]
public class EmailTests
{
    [TestMethod]
    public void Constructor_NullEmail_ThrowsBusinessRuleException()
    {
        // Act & Assert
        Assert.Throws<BusinessRuleException>(() => new Email(null!));
    }

    [TestMethod]
    public void Constructor_EmailWithoutAtSymbol_ThrowsBusinessRuleException()
    {
        // Act & Assert
        Assert.Throws<BusinessRuleException>(() => new Email("felipe.com"));
    }

    [TestMethod]
    public void Constructor_ValidEmail_NoExceptions()
    {
        string validEmail = "felipe@example.com";

        Email email = new(validEmail);

        Assert.AreEqual(validEmail, email.Value);
    }
}
