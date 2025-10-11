using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.ValueObjects;

[TestClass]
public class TimeIntervalTests
{
    [TestMethod]
    public void Constructor_StartIsAfterEnd_ThrowsBusinessRuleException()
    {
        // Arrange
        DateTimeOffset start = DateTimeOffset.UtcNow;
        DateTimeOffset end = DateTimeOffset.UtcNow.AddHours(-1);
        // Act & Assert
        Assert.Throws<BusinessRuleException>(() => new TimeInterval(start, end));
    }

    [TestMethod]
    public void Constructor_ValidTimeInterval_NoExceptions()
    {
        // Arrange
        DateTimeOffset start = DateTimeOffset.UtcNow;
        DateTimeOffset end = DateTimeOffset.UtcNow.AddHours(1);
        // Act
        TimeInterval timeInterval = new(start, end);
        // Assert
        Assert.AreEqual(start, timeInterval.Start);
        Assert.AreEqual(end, timeInterval.End);
    }
}
