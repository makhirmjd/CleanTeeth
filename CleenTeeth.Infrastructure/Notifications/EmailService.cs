using CleanTeath.Application.Notifications;
using CleenTeeth.Infrastructure.Notifications.Dtos;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Net.Http.Json;

namespace CleenTeeth.Infrastructure.Notifications;

public class EmailService(IConfiguration configuration, IHttpClientFactory httpClientFactory) : INotifications
{
    public async Task SendAppointmentConfirmation(AppointmentConfirmationDto appointmentConfirmationDto)
    {
        string sender = configuration.GetValue<string>("EMAIL_CONFIGURATIONS:Sender") ?? throw new ArgumentException("Configuration not found!");
        string hostUrl = configuration.GetValue<string>("EMAIL_CONFIGURATIONS:HostUrl") ?? throw new ArgumentException("Configuration not found!");
        string subject = "Appointment Confirmation - Clean Teeth";
        string message = $"""
            Dear, {appointmentConfirmationDto.Patient},

            Your appointment with Dr. {appointmentConfirmationDto.Dentist} has been schduled for {appointmentConfirmationDto.Date.ToString("f", new CultureInfo("en-NG"))} in the office {appointmentConfirmationDto.DentalOffice}

            We will be waiting for you.

            Clean Teeth team
            """;
        EmailDto emailDto = new() { Sender = sender, Receipient = appointmentConfirmationDto.PatientEmail, Body = message, Subject = subject };
        HttpClient client = httpClientFactory.CreateClient();
        await client.PostAsJsonAsync(hostUrl, emailDto);
    }
}
