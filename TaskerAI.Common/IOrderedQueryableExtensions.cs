namespace TaskerAI.Common
{
    using System.Linq;

    public static class IOrderedQueryableExtensions
    {
        public static IOrderedQueryable<TDto> ThenBy<TDto>(this IOrderedQueryable<TDto> source, string propertyName) => SortingHelper.Sort(source, propertyName, false, true);

        public static IOrderedQueryable<TDto> ThenByDescending<TDto>(this IOrderedQueryable<TDto> source, string propertyName) => SortingHelper.Sort(source, propertyName, true, true);

    }
}
