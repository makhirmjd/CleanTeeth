using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Contracts.Repositories.Models;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
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

    new public async Task<Appointment?> GetById(Guid id)
    {
        return await context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Dentist)
            .Include(a => a.DentalOffice)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Appointment>> GetFiltered(AppointmentsFilterDto appointmentsFilterDto)
    {
        IQueryable<Appointment> queryable = context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Dentist)
            .Include(a => a.DentalOffice)
            .AsQueryable();

        if (appointmentsFilterDto.PatientId is not null)
        {
            queryable = queryable.Where(a => a.PatientId == appointmentsFilterDto.PatientId);
        }

        if (appointmentsFilterDto.DentistId is not null)
        {
            queryable = queryable.Where(a => a.DentistId == appointmentsFilterDto.DentistId);
        }

        if (appointmentsFilterDto.DentalOfficeId is not null)
        {
            queryable = queryable.Where(a => a.DentalOfficeId == appointmentsFilterDto.DentalOfficeId);
        }

        if (appointmentsFilterDto.AppointmentStatus is not null)
        {
            queryable = queryable.Where(x => x.Status == appointmentsFilterDto.AppointmentStatus);
        }

        return await queryable.Where(a => a.TimeInterval.Start >= appointmentsFilterDto.StartDate && a.TimeInterval.End <= appointmentsFilterDto.EndDate)
            .OrderBy(a => a.TimeInterval.Start)
            .ToListAsync();
    }
}
