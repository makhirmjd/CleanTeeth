using CleanTeath.Application.Features.Dentists.Queries.GetDentistList;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Contracts.Repositories;

public interface IDentistRepository : IRepository<Dentist>
{
    Task<IEnumerable<Dentist>> GetFiltered(DentistsFilterDto filter);
}
