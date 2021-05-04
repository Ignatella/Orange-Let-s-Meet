using System.Collections.Generic;
using System.Linq;

namespace Orange_Let_s_Meet_Lib.Extensions
{
    internal static class LinqExtensions
    {
        internal delegate K SelectorWithState<T, K>(T curr, T next, ref T state);

        /// <summary>
        /// Allows to map collection basing on current and next element with custorm state.
        /// </summary>
        /// <typeparam name="T">Source item</typeparam>
        /// <typeparam name="K">Destination item</typeparam>
        /// <param name="selector">Delegate representing selector function with state</param>
        /// <returns><exceptions cref="type">Collection of destination type</exceptions></returns>
        internal static IEnumerable<K> SelectFromTwo<T, K>(this IEnumerable<T> source, SelectorWithState<T, K> selector)
        {
            T state = default;
            for (int i = 0; i < source.Count() - 1; i++)
                yield return selector(source.ElementAt(i), source.ElementAt(i + 1), ref state);
        }
    }
}
