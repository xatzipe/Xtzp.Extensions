using System;
using System.Collections.Generic;
using System.Linq;

namespace Xtzp.Extensions
{
    /// <summary>
    ///     extension methods for Lists
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        ///     Adds a new <paramref name="item" /> to the <paramref name="list" />
        /// </summary>
        /// <returns>The with format.</returns>
        /// <param name="list">the list where the item will be added</param>
        /// <param name="item">the string item that contains the placeholders just like String.Format method</param>
        /// <param name="parameters">the parameters that will be replace the placeholders of the <paramref name="item" /></param>
        public static IList<string> AddWithFormat(
            this IList<string> list,
            string item,
            params string[] parameters
        )
        {
            if (string.IsNullOrEmpty(item)) return list;

            var parsedItem = string.Format(item, parameters);
            list.Add(parsedItem);
            return list;
        }

        /// <summary>
        ///     Adds the item to the list if it does not exist
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> AddIfNotExists<T>(this List<T> list, T value)
        {
            if (list is null) throw new Exception("List cannot be null");

            if (!list.Contains(value)) list.Add(value);

            return list;
        }

        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<T> AddIfNotExists<T>(this List<T> list, Func<T, Func<T, bool>> predicate, T value)
        {
            if (list is null) throw new Exception("List cannot be null");

            if (!list.Any(predicate(value))) list.Add(value);

            return list;
        }

        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        /// <param name="values"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> AddRangeIfNotExists<T>(
            this List<T> list,
            Func<T, Func<T, bool>> predicate,
            IEnumerable<T> values
        )
        {
            foreach (var val in values) list.AddIfNotExists(predicate, val);

            return list;
        }
    }
}