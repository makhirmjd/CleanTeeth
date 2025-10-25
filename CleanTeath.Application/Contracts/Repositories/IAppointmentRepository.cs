using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Contracts.Repositories;

public interface IAppointmentRepository : IRepository<Appointment>
{
    new Task<Appointment?> GetById(Guid id);
    Task<bool> OverlapExists(Guid dentistId, DateTimeOffset start, DateTimeOffset end);
}
