using System.Collections.Generic;

namespace Xtzp.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// adds a range of items in a collection
        /// </summary>
        /// <param name="collection">Collection.</param>
        /// <param name="newItems">New items.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> newItems)
        {
            foreach (var item in newItems)
            {
                collection.Add(item);
            }
        }
    }
}