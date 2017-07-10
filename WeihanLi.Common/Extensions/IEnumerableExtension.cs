using System;
using System.Collections.Generic;
using System.Text;

namespace System.Collections.Generic
{
    public static class IEnumerableExtension
    {
        public static void Each<T>(this IEnumerable<T> ts, Action<T> action)
        {
            foreach (var t in ts)
            {
                action(t);
            }
        }

        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            yield return value;

            foreach (var element in source)
            {
                yield return element;
            }
        }

        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            foreach (var element in source)
            {
                yield return element;
            }

            yield return value;
        }
    }
}
