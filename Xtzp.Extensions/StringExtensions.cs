using System;
using System.Text.RegularExpressions;

namespace Xtzp.Extensions
{
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
            );

            var result = words[0].ToLower();
            for (var i = 1; i < words.Length; i++)
                result +=
                    words[i].Substring(0, 1).ToUpper() +
                    words[i].Substring(1);

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
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="substring"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool Contains(this string str, string substring, StringComparison comp)
        {
            if (substring == null)
                throw new ArgumentNullException(nameof(substring), "substring cannot be null.");
            else if (!Enum.IsDefined(typeof(StringComparison), comp))
                throw new ArgumentException("comp is not a member of StringComparison", nameof(comp));
            return str.IndexOf(substring, comp) >= 0;
        }
    }
}