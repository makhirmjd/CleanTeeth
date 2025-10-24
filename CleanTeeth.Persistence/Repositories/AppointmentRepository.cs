using CleanTeath.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Persistence.Repositories;

public class AppointmentRepository(CleanTeethDbContext context) : Repository<Appointment>(context), IAppointmentRepository
{
}
