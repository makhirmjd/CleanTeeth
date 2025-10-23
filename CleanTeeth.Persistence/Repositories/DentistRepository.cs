using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Features.Dentists.Queries.GetDentistList;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories;

public class DentistRepository(CleanTeethDbContext context) : Repository<Dentist>(context), IDentistRepository
{
    private readonly CleanTeethDbContext context = context;

    public async Task<IEnumerable<Dentist>> GetFiltered(DentistsFilterDto filter)
    {
        IQueryable<Dentist> query = context.Dentists.AsQueryable();
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
