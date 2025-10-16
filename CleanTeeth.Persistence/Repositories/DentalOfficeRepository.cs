using CleanTeath.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Persistence.Repositories;

public class DentalOfficeRepository(CleanTeethDbContext context) : Repository<DentalOffice>(context), IDentalOfficeRepository
{

}
