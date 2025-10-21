using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Features.Patients.Queries.GetPatientList;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories;

public class PatientRepository(CleanTeethDbContext context) : Repository<Patient>(context), IPatientRepository
{
    private readonly CleanTeethDbContext context = context;

    public async Task<IEnumerable<Patient>> GetFiltered(PatientsFilterDto filter) =>
        await context.Patients.OrderBy(x => x.Name).Paginate(filter.Page, filter.RecordsPerPage).ToListAsync();
}
