namespace CarRentalSystem.Infrastructure.Common
{
    using CarRentalSystem.Application.Common;
    using System.Linq;

    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> Sort<TEntity>(
            this IQueryable<TEntity> queryable,
            SortOrder<TEntity> sortOrder)
            => sortOrder.Order == SortOrder<TEntity>.Descending
                ? queryable.OrderByDescending(sortOrder.ToExpression())
                : queryable.OrderBy(sortOrder.ToExpression());
    }
}
