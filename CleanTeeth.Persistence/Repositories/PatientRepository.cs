using CleanTeath.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Persistence.Repositories;

public class PatientRepository(CleanTeethDbContext context) : Repository<Patient>(context), IPatientRepository
{
}
