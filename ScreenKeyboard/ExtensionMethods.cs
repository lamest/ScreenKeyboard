using System.Collections.Generic;

namespace ScreenKeyboard
{
    public static class ExtensionMethods
    {
        public static IEnumerable<TSource> IndexRange<TSource>(
            this IList<TSource> source,
            int fromIndex,
            int toIndex)
        {
            var currIndex = fromIndex;
            while (currIndex <= toIndex)
            {
                yield return source[currIndex];
                currIndex++;
            }
        }
    }
}