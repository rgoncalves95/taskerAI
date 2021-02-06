namespace TaskerAI.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static bool SafeAny<T>(this IEnumerable<T> source) => source != null && source.Any();

        public static bool SafeAny<T>(this IEnumerable<T> source, Func<T, bool> predicate) => source != null && source.Any(predicate);
    }
}
