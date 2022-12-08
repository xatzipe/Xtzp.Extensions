using System;
using System.Globalization;

namespace Xtzp.Extensions
{
    /// <summary>
    ///     extension methods for datetime
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, dt.Kind);
        }

        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, dt.Kind);
        }

        /// <summary>
        ///     returns the Beginning of the Month for the input <paramref name="dt" />
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfTheMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1, 0, 0, 0, dt.Kind);
        }

        /// <summary>
        ///     returns the End of the Month for the input <paramref name="dt" />
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfTheMonth(this DateTime dt)
        {
            var endOfTheMonth = new DateTime(dt.Year, dt.Month, 1, dt.Hour, dt.Minute, dt.Second, dt.Millisecond,
                    dt.Kind)
                .AddMonths(1)
                .AddDays(-1)
                .EndOfDay();

            return endOfTheMonth;
        }

        /// <summary>
        ///     returns the Beginning of Next Month for the input <paramref name="dt" />
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfNextMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1).AddMonths(1);
        }

        /// <summary>
        ///     returns the a DateTime that represents the next requested day of week
        ///     whether it belogs to the current week of the <paramref name="dt" />
        ///     or to the next
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime NextGivenDay(this DateTime dt, DayOfWeek d)
        {
            var currentDayOfWeek = (int)dt.DayOfWeek;
            var newDayOfWeek = (int)d;
            var daysToAdd = 0;
            if (currentDayOfWeek >= newDayOfWeek)
                daysToAdd = 7 + newDayOfWeek - currentDayOfWeek;
            else
                daysToAdd = newDayOfWeek - currentDayOfWeek;
            return new GregorianCalendar().AddDays(dt, daysToAdd);
        }

        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime NextMonday(this DateTime dt)
        {
            return dt.NextGivenDay(DayOfWeek.Monday);
        }

        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime NextSunday(this DateTime dt)
        {
            return dt.NextGivenDay(DayOfWeek.Sunday);
        }

        /// <summary>
        ///     Returns the date of the given <paramref name="d"></paramref> from the current week
        ///     that the <paramref name="dt" /> belongs to
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime WeekDay(this DateTime dt, DayOfWeek d)
        {
            var daysToAdd = (int)d - (int)dt.DayOfWeek;
            return new GregorianCalendar().AddDays(dt, daysToAdd);
        }


        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime WeekMonday(this DateTime dt)
        {
            return dt.WeekDay(DayOfWeek.Monday);
        }

        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime WeekFriday(this DateTime dt)
        {
            return dt.WeekDay(DayOfWeek.Friday);
        }

        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int DaysInCurrentMonth(this DateTime dt)
        {
            return DateTime.DaysInMonth(dt.Year, dt.Month);
        }

        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateTime dt)
        {
            return DateTime.DaysInMonth(dt.Year, 2) == 29;
        }
    }
}