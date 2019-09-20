using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Xtzp.Extensions
{
    
    /// <summary>
    /// extension methods for string
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Non static way to check if string is Null or Empty
        /// </summary>
        /// <param name="s"></param>
        /// <returns><see langword="true"/> if the</returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Non static way to format a string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string FormatStr(this string s, params object[] items)
        {
            if (string.IsNullOrEmpty(s)) return s;

            return null == items ? s : string.Format(s, items);
        }

        /// <summary>
        /// Returns true if two strings are identical
        /// </summary>
        /// <param name="s"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool IsEqual(this string s, string that)
        {
            if (null == s) return null == that;

            if (string.Empty == s && string.Empty == that) return true;

            return s.Equals(that, StringComparison.Ordinal);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="emptyStringUponNull"></param>
        /// <returns></returns>
        public static string TrimSafe(this string s, bool emptyStringUponNull = false)
        {
            if (null != s) return s.Trim();
            return emptyStringUponNull ? string.Empty : null;
        }


        /// <summary>
        /// returns true if both strings are null or Empty.
        /// if not, two strings are compared normally
        /// </summary>
        /// <param name="s"></param>
        /// <param name="s2"></param>
        /// <param name="strComparison"></param>
        /// <returns></returns>
        public static bool EqualIfNullOrEmpty(this string s, string s2,
            StringComparison strComparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(s2)) return true;

            return null != s && s.Equals(s2, strComparison);
        }

        /// <summary>
        /// Splits the string by pascal case.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string SplitPascalCase(this string text)
        {
            return string.IsNullOrEmpty(text)
                ? text
                : Regex.Replace(text, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string s)
        {
            if (s == null || s.Length < 2)
                return s;

            var words = s.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries
            ).AsEnumerable();

            var result = words.First().ToLower();
            result += string.Join(
                string.Empty,
                words.Skip(1).Select(w => w.Substring(0, 1).ToUpper() + w.Substring(1)));

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToPascalCase(this string s)
        {
            if (s == null || s.Length < 2)
                return s;

            var words = s.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries
            ).AsEnumerable();

            var result = String.Join(
                string.Empty,
                words
                    .Select(w => w.Substring(0, 1).ToUpper() + w.Substring(1))
            );
            return result;
        }

        /// <summary>
        /// if the string is null return the fallback string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="fallBack"></param>
        /// <returns></returns>
        public static string FallBackIfNull(this string s, string fallBack)
        {
            return s ?? fallBack;
        }

        /// <summary>
        /// if the string is equal to empty string return the fallback string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="fallBack"></param>
        /// <returns></returns>
        public static string FallBackIfEmpty(this string s, string fallBack)
        {
            return s != string.Empty ? s : fallBack;
        }

        /// <summary>
        /// if the string is null or empty return the fallback string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="fallBack"></param>
        /// <returns></returns>
        public static string FallBackIfNullOrEmpty(this string s, string fallBack)
        {
            return string.IsNullOrEmpty(s) ? fallBack : s;
        }

        /// <summary>
        /// converts the first character of the string to UpperCase
        /// inspired by PHP's function ucfirst
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UcFirst(this string str)
        {
            return str.IsNullOrEmpty()
                ? str
                : str.Aggregate(string.Empty,
                    (st, c) => st + (st.IsNullOrEmpty() ? char.ToUpper(c) : c));
        }

        /// <summary>
        /// adds the given <paramref name="prefix"/> to the start of the
        /// string if it doesn't exist already
        /// </summary>
        /// <param name="str"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string EnsurePrefix(this string str, string prefix)
        {
            return str == null
                ? str
                : str.StartsWith(prefix)
                    ? str
                    : prefix + str;
        }
        
        /// <summary>
        /// adds the given <paramref name="suffix"/> to the end of the
        /// string if it doesn't exist already
        /// </summary>
        /// <param name="str"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string EnsureSuffix(this string str, string suffix)
        {
            return str == null
                ? str
                : str.StartsWith(suffix)
                    ? str
                    : str + suffix;
        }
    }
}