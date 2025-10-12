using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Entities.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.Entities;

[TestClass]
public class AppointmentTests
{
    readonly Guid patientId = Guid.NewGuid();
    readonly Guid dentistId = Guid.NewGuid();
    readonly Guid dentalOfficeId = Guid.NewGuid();
    readonly TimeInterval timeInterval = new(DateTimeOffset.UtcNow.AddHours(1), DateTimeOffset.UtcNow.AddHours(2));


    [TestMethod]
    public void Constructor_NullTimeInterval_ThrowsBusinessRuleException()
    {
        TimeInterval timeInterval = null!;
        // Act & Assert
        BusinessRuleException exception = Assert.Throws<BusinessRuleException>(() =>
            new Appointment(patientId, dentistId, dentalOfficeId, timeInterval));
        Assert.AreEqual("The time interval is required", exception.Message);
    }

    [TestMethod]
    public void Constructor_StartTimeInThePast_ThrowsBusinessRuleException()
    {
        TimeInterval timeInterval = new(DateTimeOffset.UtcNow.AddHours(-1), DateTimeOffset.UtcNow.AddHours(1));
        // Act & Assert
        BusinessRuleException exception = Assert.Throws<BusinessRuleException>(() =>
            new Appointment(patientId, dentistId, dentalOfficeId, timeInterval));
        Assert.AreEqual("The start time cannot be in the past", exception.Message);
    }

    [TestMethod]
    public void Constructor_ValidParameters_CreatesAppointment()
    {
        // Act
        Appointment appointment = new(patientId, dentistId, dentalOfficeId, timeInterval);
        // Assert
        Assert.AreEqual(patientId, appointment.PatientId);
        Assert.AreEqual(dentistId, appointment.DentistId);
        Assert.AreEqual(dentalOfficeId, appointment.DentalOfficeId);
        Assert.AreEqual(timeInterval, appointment.TimeInterval);
        Assert.AreEqual(AppointmentStatus.Scheduled, appointment.Status);
        Assert.AreNotEqual(Guid.Empty, appointment.Id);
    }

    [TestMethod]
    public void Cancel_StatusNotScheduled_ThrowsBusinessRuleException()
    {
        // Arrange
        Appointment appointment = new(patientId, dentistId, dentalOfficeId, timeInterval);
        appointment.Complete();
        // Act & Assert
        BusinessRuleException exception = Assert.Throws<BusinessRuleException>(() => appointment.Cancel());
        Assert.AreEqual("Only scheduled appointments can be cancelled", exception.Message);
    }

    [TestMethod]
    public void Cancel_StatusScheduled_ChangesStatusToCancelled()
    {
        // Arrange
        Appointment appointment = new(patientId, dentistId, dentalOfficeId, timeInterval);
        // Act
        appointment.Cancel();
        // Assert
        Assert.AreEqual(AppointmentStatus.Cancelled, appointment.Status);
    }

    [TestMethod]
    public void Complete_StatusNotScheduled_ThrowsBusinessRuleException()
    {
        // Arrange
        Appointment appointment = new(patientId, dentistId, dentalOfficeId, timeInterval);
        appointment.Cancel();
        // Act & Assert
        BusinessRuleException exception = Assert.Throws<BusinessRuleException>(() => appointment.Complete());
        Assert.AreEqual("Only scheduled appointments can be completed", exception.Message);
    }

    [TestMethod]
    public void Complete_StatusScheduled_ChangesStatusToCompleted()
    {
        // Arrange
        Appointment appointment = new(patientId, dentistId, dentalOfficeId, timeInterval);
        // Act
        appointment.Complete();
        // Assert
        Assert.AreEqual(AppointmentStatus.Completed, appointment.Status);
    }
}
