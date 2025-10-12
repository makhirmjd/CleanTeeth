using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.Entities;

[TestClass]
public class DentistTests
{
    [TestMethod]
    public void Constructor_NullName_ThrowsBusinessRuleException()
    {
        Assert.Throws<BusinessRuleException>(() => new Dentist(name: default!, new Email("felipe@example.com")));
    }

    [TestMethod]
    public void Constructor_NullEmail_ThrowsBusinessRuleException()
    {
        Assert.Throws<BusinessRuleException>(() => new Dentist("Samson Viper", email: default!));
    }

    [TestMethod]
    public void Constructor_ValidParameters_CreatesDentist()
    {
        // Arrange
        var name = "Samson Viper";
        var email = new Email("samson.viper@example.com");
        // Act
        Dentist dentist = new(name, email);
        // Assert
        Assert.AreNotEqual(Guid.Empty, dentist.Id);
        Assert.AreEqual(name, dentist.Name);
        Assert.AreEqual(email, dentist.Email);
    }
}
