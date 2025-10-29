
using CleanTeath.Application.Features.Appointments.Commands.SendAppointmentReminder;
using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeeth.API.Jobs;

public class AppointmentReminderJob(IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        TimeZoneInfo nigeriaTz = TimeZoneInfo.FindSystemTimeZoneById("W. Central Africa Standard Time");
        while (!stoppingToken.IsCancellationRequested)
        {
            DateTimeOffset nowInNigeria = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, nigeriaTz);
            if (nowInNigeria.Hour == 8)
            {
                using IServiceScope scope = serviceScopeFactory.CreateScope();
                IMediator mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(new SendAppointmentReminderCommand());
            }

            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }
    }
}
