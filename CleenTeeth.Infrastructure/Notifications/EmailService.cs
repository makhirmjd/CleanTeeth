using CleanTeath.Application.Notifications;
using CleanTeeth.Infrastructure.Notifications.Dtos;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Net.Http.Json;

namespace CleanTeeth.Infrastructure.Notifications;

public class EmailService(IConfiguration configuration, IHttpClientFactory httpClientFactory) : INotifications
{
    private readonly string sender = 
        configuration.GetValue<string>("EMAIL_CONFIGURATIONS:Sender") ?? throw new ArgumentException("Configuration not found!");
    private readonly string hostUrl = 
        configuration.GetValue<string>("EMAIL_CONFIGURATIONS:HostUrl") ?? throw new ArgumentException("Configuration not found!");
    private readonly HttpClient client = httpClientFactory.CreateClient();

    public async Task SendAppointmentConfirmation(AppointmentConfirmationDto appointmentConfirmationDto)
    {
        string subject = "Appointment Confirmation - Clean Teeth";
        string message = $"""
            Dear, {appointmentConfirmationDto.Patient},

            Your appointment with Dr. {appointmentConfirmationDto.Dentist} has been schduled for {appointmentConfirmationDto.Date.ToString("f", new CultureInfo("en-NG"))} in the office {appointmentConfirmationDto.DentalOffice}

            We will be waiting for you.

            Clean Teeth team
            """;
        EmailDto emailDto = new() { Sender = sender, Receipient = appointmentConfirmationDto.PatientEmail, Body = message, Subject = subject };
        
        await client.PostAsJsonAsync(hostUrl, emailDto);
    }

    public async Task SendAppointmentReminder(AppointmentReminderDto appointmentReminderDto)
    {
        string subject = "Appointment Reminder - Clean Teeth";
        string message = $"""
            Dear, {appointmentReminderDto.Patient},

            This is a reminder for your appointment with Dr. {appointmentReminderDto.Dentist} on {appointmentReminderDto.Date.ToString("f", new CultureInfo("en-NG"))} in the office {appointmentReminderDto.DentalOffice}

            We will be waiting for you.

            Clean Teeth team
            """;
        EmailDto emailDto = new() { Sender = sender, Receipient = appointmentReminderDto.PatientEmail, Body = message, Subject = subject };

        await client.PostAsJsonAsync(hostUrl, emailDto);
    }
}
