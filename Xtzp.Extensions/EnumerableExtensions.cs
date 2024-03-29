using System.Collections.Generic;

namespace Xtzp.Extensions
{
    /// <summary>
    ///     extension methods for Enumerables
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     It takes an enumerable and returns another one that bar be iterated in batches
        /// </summary>
        /// <param name="input"></param>
        /// <param name="size"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> input, int size)
        {
            if (input == null) yield break;

            var counter = 0;
            var batch = new List<T>();
            foreach (var item in input)
            {
                batch.Add(item);
                counter++;
                if (counter == size)
                {
                    var result = batch;
                    batch = new List<T>();
                    counter = 0;
                    yield return result;
                }
            }

            if (batch.Count > 0) yield return batch;
        }
    }
}