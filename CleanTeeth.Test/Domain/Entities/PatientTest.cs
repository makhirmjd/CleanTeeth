using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.Entities;

[TestClass]
public class PatientTest
{
    [TestMethod]
    public void Constructor_NullName_ThrowsBusinessRuleException()
    {
        Assert.Throws<BusinessRuleException>(() => new Patient(name: default!, email: new Email("felipe@example.com")));
    }

    [TestMethod]
    public void Constructor_NullEmail_ThrowsBusinessRuleException()
    {
        Assert.Throws<BusinessRuleException>(() => new Patient("Abdulmalik Muhammad", email: default!));
    }

    [TestMethod]
    public void Constructor_InvalidEmail_ThrowsBusinessRuleException()
    {
        Assert.Throws<BusinessRuleException>(() => new Patient("Abdulmalik Muhammad", email: new Email("felipe.com")));
    }

    [TestMethod]
    public void Constructor_ValidParameters_CreatesPatient()
    {
        // Arrange
        string name = "Abdulmalik Muhammad";
        Email email = new ("makhirmjd@gmail.com");
        // Act
        Patient patient = new (name, email);
        // Assert
        Assert.AreNotEqual(Guid.Empty, patient.Id);
        Assert.AreEqual(name, patient.Name);
        Assert.AreEqual(email, patient.Email);
    }
}
