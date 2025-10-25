using CleanTeath.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories;

public class AppointmentRepository(CleanTeethDbContext context) : Repository<Appointment>(context), IAppointmentRepository
{
    private readonly CleanTeethDbContext context = context;
    public async Task<bool> OverlapExists(Guid dentistId, DateTimeOffset start, DateTimeOffset end)
    {
        return await context.Appointments.AnyAsync(a =>
            a.DentistId == dentistId && a.Status == AppointmentStatus.Scheduled && 
            start < a.TimeInterval.End && end > a.TimeInterval.Start);
    }
}
