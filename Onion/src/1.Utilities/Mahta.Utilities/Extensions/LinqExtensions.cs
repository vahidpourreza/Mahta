using System.Data;
using System.Linq.Expressions;

namespace Mahta.Utilities.Extensions;

/// <summary>
/// Example:
/// var query = dbContext.Employees.AsQueryable();
///var sortedAndFilteredQuery = query
///    .OrderByField("Salary", true) // Sort by Salary in ascending order
///    .WhereIf(isActive, e => e.IsActive) // Filter by IsActive condition
///    .WhereIf(filterByDepartment, e => e.Department == "IT"); // Filter by Department condition
/// </summary>
public static class LinqExtensions
{
    public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string SortField, bool Ascending)
    {
        var param = Expression.Parameter(typeof(T), "p");
        var prop = Expression.Property(param, SortField);
        var exp = Expression.Lambda(prop, param);
        string method = Ascending ? "OrderBy" : "OrderByDescending";
        Type[] types = new Type[] { q.ElementType, exp.Body.Type };
        var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
        return q.Provider.CreateQuery<T>(mce);
    }


    /// <summary>
    /// Filters a <see cref="IQueryable{T}"/> by given predicate if given condition is true.
    /// </summary>
    /// <param name="query">Queryable to apply filtering</param>
    /// <param name="condition">A boolean value</param>
    /// <param name="predicate">Predicate to filter the query</param>
    /// <returns>Filtered or not filtered query based on <paramref name="condition"/></returns>
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
    {
        return condition
        ? query.Where(predicate)
        : query;
    }

    /// <summary>
    /// Filters a <see cref="IQueryable{T}"/> by given predicate if given condition is true.
    /// </summary>
    /// <param name="query">Queryable to apply filtering</param>
    /// <param name="condition">A boolean value</param>
    /// <param name="predicate">Predicate to filter the query</param>
    /// <returns>Filtered or not filtered query based on <paramref name="condition"/></returns>
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)
    {
        return condition
        ? query.Where(predicate)
        : query;
    }
}
