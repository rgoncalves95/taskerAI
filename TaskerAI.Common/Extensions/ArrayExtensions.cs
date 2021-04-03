namespace TaskerAI.Common.Extensions
{
    using System;
    using System.Linq;

    public static class ArrayExtensions
    {
        public static bool SafeAny<T>(this T[] source) => source != null && source.Length > 0;

        public static bool SafeAny<T>(this T[] source, Func<T, bool> predicate) => source != null && source.Any(predicate);
    }
}
