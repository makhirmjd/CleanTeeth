using System.Linq.Expressions;

namespace CleanTeeth.Persistence.Utilities;

internal static class IQuaryableExtensions
{
    internal static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, int pageNumber, int pageSize) =>
        queryable.Skip((pageNumber - 1) * pageSize).Take(pageSize);

    internal static IQueryable<T> Filter<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> expression) => 
        queryable.Where(expression);
}
