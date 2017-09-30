using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace System.Collections.Generic
{
    public static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> ts, Action<T> action)
        {
            foreach (var t in ts)
            {
                action(t);
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> ts, Func<T, Task> action)
        {
            foreach (var t in ts)
            {
                await action(t);
            }
        }

        /// <summary>
        ///     A T[] extension method that converts an array to a read only.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>A list of.</returns>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> @this)
        {
            return Array.AsReadOnly(@this.ToArray());
        }

        /// <summary>
        ///     An IEnumerable&lt;T&gt; extension method that queries if a null or is empty.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The collection to act on.</param>
        /// <returns>true if a null or is t>, false if not.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this == null || !@this.Any();
        }

        /// <summary>
        ///     An IEnumerable&lt;T&gt; extension method that queries if a not null or is empty.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The collection to act on.</param>
        /// <returns>true if a not null or is t>, false if not.</returns>
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this != null && @this.Any();
        }

        /// <summary>
        ///     Concatenates all the elements of a IEnumerable, using the specified separator between each element.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">An IEnumerable that contains the elements to concatenate.</param>
        /// <param name="separator">
        ///     The string to use as a separator. separator is included in the returned string only if
        ///     value has more than one element.
        /// </param>
        /// <returns>
        ///     A string that consists of the elements in value delimited by the separator string. If value is an empty array,
        ///     the method returns String.Empty.
        /// </returns>
        public static string StringJoin<T>(this IEnumerable<T> @this, string separator)
        {
            return string.Join(separator, @this);
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