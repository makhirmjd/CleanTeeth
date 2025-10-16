using CleanTeath.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories;

public class Repository<T>(CleanTeethDbContext context) : IRepository<T> where T : class
{
    public Task<T> Add(T entity)
    {
        context.Add(entity);
        return Task.FromResult(entity);
    }

    public Task Delete(T entity)
    {
        context.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> GetAll() => await context.Set<T>().ToListAsync();

    public async Task<T?> GetById(Guid id) => await context.Set<T>().FindAsync(id);

    public Task Update(T entity)
    {
        context.Update(entity);
        return Task.CompletedTask;
    }
}
