namespace TaskerAI.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<TDto> OrderBy<TDto>(this IQueryable<TDto> source, string propertyName)
            => SortingHelper.Sort(source, propertyName, false, false);

        public static IOrderedQueryable<TDto> OrderByDescending<TDto>(this IQueryable<TDto> source, string propertyName)
            => SortingHelper.Sort(source, propertyName, true, false);

        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> query, IEnumerable<Expression<Func<TEntity, bool>>> filter)
        {
            if (filter.SafeAny())
            {
                foreach (Expression<Func<TEntity, bool>> p in filter)
                {
                    query = query.Where(p);
                }
            }

            return query;
        }

        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, string orderBy, string orderAs)
        {
            if (!string.IsNullOrWhiteSpace(orderBy) && !string.IsNullOrWhiteSpace(orderAs))
            {
                switch (orderAs.ToLowerInvariant())
                {
                    case "asc":
                        query = query.OrderBy(orderBy);
                        break;
                    case "desc":
                        query = query.OrderByDescending(orderBy);
                        break;
                }
            }

            return query;
        }

        public static IQueryable<TEntity> Page<TEntity>(this IQueryable<TEntity> query, int? pageSize, int? pageIndex)
        {
            if (pageSize.HasValue)
            {
                if (pageIndex.HasValue)
                {
                    query = query.Skip(pageIndex.Value * pageSize.Value);
                }

                query = query.Take(pageSize.Value);
            }

            return query;
        }

        //public static IQueryable<TEntity> Include<TEntity>
        //(
        //    this IQueryable<TEntity> query,
        //    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include
        //)
        //where TEntity : class
        //{
        //    if (include != null)
        //    {
        //        return query = include(query);
        //    }

        //    return query;
        //}
    }
}

