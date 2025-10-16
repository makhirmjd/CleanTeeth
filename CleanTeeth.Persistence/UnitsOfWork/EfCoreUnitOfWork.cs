using CleanTeath.Application.Contracts.Persistence;

namespace CleanTeeth.Persistence.UnitsOfWork;

public class EfCoreUnitOfWork(CleanTeethDbContext context) : IUnitOfWork
{
    public async Task Commit() => await context.SaveChangesAsync();

    public Task Rollback() => Task.CompletedTask;
}
