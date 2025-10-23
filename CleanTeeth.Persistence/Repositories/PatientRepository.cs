using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Features.Patients.Queries.GetPatientList;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories;

public class PatientRepository(CleanTeethDbContext context) : Repository<Patient>(context), IPatientRepository
{
    private readonly CleanTeethDbContext context = context;

    public async Task<IEnumerable<Patient>> GetFiltered(PatientsFilterDto filter)
    {
        IQueryable<Patient> query = context.Patients.AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            query = query.Filter(x => x.Name.Contains(filter.Name));
        }
        if (!string.IsNullOrWhiteSpace(filter.Email))
        {
            query = query.Filter(x => x.Email.Value.Contains(filter.Email));
        }
        return await query.OrderBy(x => x.Name).Paginate(filter.Page, filter.RecordsPerPage).ToListAsync();
    }
}
