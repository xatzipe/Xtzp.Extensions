using System;
using System.Collections.Generic;

namespace Xtzp.Extensions
{
    /// <summary>
    /// extension methods for Dictionary
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// inserts a KeyValuePair to the dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="input"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Add<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> input)
        {
            dictionary.Add(input.Key, input.Value);
        }

        /// <summary>
        /// inserts multiple KeyValuePairs to the dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="input"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddRange<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            IEnumerable<KeyValuePair<TKey, TValue>> input
        )
        {
            foreach (var item in input)
                dictionary.Add(item);
        }
    }
}