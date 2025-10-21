using CleanTeath.Application.Features.Patients.Queries.GetPatientList;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Contracts.Repositories;

public interface IPatientRepository : IRepository<Patient>
{
    Task<IEnumerable<Patient>> GetFiltered(PatientsFilterDto filter);
}
