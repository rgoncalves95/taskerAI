namespace TaskerAI.Common
{
    using System.Linq;
    using System.Linq.Expressions;

    public class SortingHelper
    {
        public static IOrderedQueryable<TDto> Sort<TDto>(IQueryable<TDto> source, string propertyName, bool descending, bool anotherLevel)
        {
            ParameterExpression param = Expression.Parameter(typeof(TDto), string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, propertyName);
            LambdaExpression sort = Expression.Lambda(property, param);

            MethodCallExpression call = Expression.Call
            (
                typeof(Queryable),
                (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                new[] { typeof(TDto), property.Type },
                source.Expression,
                Expression.Quote(sort)
            );

            return (IOrderedQueryable<TDto>)source.Provider.CreateQuery<TDto>(call);
        }

    }
}
