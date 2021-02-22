namespace TaskerAI.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public static class IQueryableExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, IEnumerable<Expression<Func<T, bool>>> filter)
        {
            if (filter.SafeAny())
            {
                foreach (Expression<Func<T, bool>> p in filter)
                {
                    query = query.Where(p);
                }
            }

            return query;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string orderBy, string orderAs)
        {
            if (!string.IsNullOrWhiteSpace(orderBy) && !string.IsNullOrWhiteSpace(orderAs))
            {
                switch (orderAs.ToLowerInvariant())
                {
                    case "asc":
                        query = query.OrderAscending(orderBy);
                        break;
                    case "desc":
                        query = query.OrderDescending(orderBy);
                        break;
                }
            }

            return query;
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> query, int? pageSize, int? pageIndex)
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

        public static IOrderedQueryable<T> OrderAscending<T>(this IQueryable<T> source, string propertyName)
            => source.Sort(propertyName, false, false);

        public static IOrderedQueryable<T> OrderDescending<T>(this IQueryable<T> source, string propertyName)
            => source.Sort(propertyName, true, false);

        public static IOrderedQueryable<T> Sort<T>(this IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, propertyName);
            LambdaExpression sort = Expression.Lambda(property, param);

            MethodCallExpression call = Expression.Call
            (
                typeof(Queryable),
                (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                new[] { typeof(T), property.Type },
                source.Expression,
                Expression.Quote(sort)
            );

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
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

