using System;
using System.Collections.Generic;
using Xunit;

namespace Xtzp.Extensions.Tests
{
    public class DateTimeExtensionTests
    {
        [Theory]
        [MemberData(nameof(NextGivenDateTestCases))]
        public void TestNextGivenDay(DateTime input, DayOfWeek inputDayOfWeek, DateTime expectedOutput)
        {
            Assert.Equal(expectedOutput, input.NextGivenDay(inputDayOfWeek));
        }

        public static IEnumerable<object[]> NextGivenDateTestCases
        {
            get
            {
                yield return new object[] {new DateTime(2016, 11, 28), DayOfWeek.Monday, new DateTime(2016, 12, 05)};
                yield return new object[] {new DateTime(2016, 11, 29), DayOfWeek.Monday, new DateTime(2016, 12, 05)};
                yield return new object[] {new DateTime(2016, 11, 30), DayOfWeek.Monday, new DateTime(2016, 12, 05)};
                yield return new object[] {new DateTime(2016, 12, 1), DayOfWeek.Monday, new DateTime(2016, 12, 05)};
                yield return new object[] {new DateTime(2016, 12, 2), DayOfWeek.Monday, new DateTime(2016, 12, 05)};
                yield return new object[] {new DateTime(2016, 12, 3), DayOfWeek.Monday, new DateTime(2016, 12, 05)};
                yield return new object[] {new DateTime(2016, 12, 4), DayOfWeek.Monday, new DateTime(2016, 12, 05)};

                yield return new object[] {new DateTime(2016, 11, 28), DayOfWeek.Tuesday, new DateTime(2016, 11, 29)};
                yield return new object[] {new DateTime(2016, 11, 29), DayOfWeek.Tuesday, new DateTime(2016, 12, 06)};
                yield return new object[] {new DateTime(2016, 11, 30), DayOfWeek.Tuesday, new DateTime(2016, 12, 06)};
                yield return new object[] {new DateTime(2016, 12, 1), DayOfWeek.Tuesday, new DateTime(2016, 12, 06)};
                yield return new object[] {new DateTime(2016, 12, 2), DayOfWeek.Tuesday, new DateTime(2016, 12, 06)};
                yield return new object[] {new DateTime(2016, 12, 3), DayOfWeek.Tuesday, new DateTime(2016, 12, 06)};
                yield return new object[] {new DateTime(2016, 12, 4), DayOfWeek.Tuesday, new DateTime(2016, 12, 06)};

                yield return new object[] {new DateTime(2016, 11, 28), DayOfWeek.Wednesday, new DateTime(2016, 11, 30)};
                yield return new object[] {new DateTime(2016, 11, 29), DayOfWeek.Wednesday, new DateTime(2016, 11, 30)};
                yield return new object[] {new DateTime(2016, 11, 30), DayOfWeek.Wednesday, new DateTime(2016, 12, 07)};
                yield return new object[] {new DateTime(2016, 12, 1), DayOfWeek.Wednesday, new DateTime(2016, 12, 07)};
                yield return new object[] {new DateTime(2016, 12, 2), DayOfWeek.Wednesday, new DateTime(2016, 12, 07)};
                yield return new object[] {new DateTime(2016, 12, 3), DayOfWeek.Wednesday, new DateTime(2016, 12, 07)};
                yield return new object[] {new DateTime(2016, 12, 4), DayOfWeek.Wednesday, new DateTime(2016, 12, 07)};

                yield return new object[] {new DateTime(2016, 11, 28), DayOfWeek.Thursday, new DateTime(2016, 12, 01)};
                yield return new object[] {new DateTime(2016, 11, 29), DayOfWeek.Thursday, new DateTime(2016, 12, 01)};
                yield return new object[] {new DateTime(2016, 11, 30), DayOfWeek.Thursday, new DateTime(2016, 12, 01)};
                yield return new object[] {new DateTime(2016, 12, 1), DayOfWeek.Thursday, new DateTime(2016, 12, 08)};
                yield return new object[] {new DateTime(2016, 12, 2), DayOfWeek.Thursday, new DateTime(2016, 12, 08)};
                yield return new object[] {new DateTime(2016, 12, 3), DayOfWeek.Thursday, new DateTime(2016, 12, 08)};
                yield return new object[] {new DateTime(2016, 12, 4), DayOfWeek.Thursday, new DateTime(2016, 12, 08)};

                yield return new object[] {new DateTime(2016, 11, 28), DayOfWeek.Friday, new DateTime(2016, 12, 02)};
                yield return new object[] {new DateTime(2016, 11, 29), DayOfWeek.Friday, new DateTime(2016, 12, 02)};
                yield return new object[] {new DateTime(2016, 11, 30), DayOfWeek.Friday, new DateTime(2016, 12, 02)};
                yield return new object[] {new DateTime(2016, 12, 1), DayOfWeek.Friday, new DateTime(2016, 12, 02)};
                yield return new object[] {new DateTime(2016, 12, 2), DayOfWeek.Friday, new DateTime(2016, 12, 09)};
                yield return new object[] {new DateTime(2016, 12, 3), DayOfWeek.Friday, new DateTime(2016, 12, 09)};
                yield return new object[] {new DateTime(2016, 12, 4), DayOfWeek.Friday, new DateTime(2016, 12, 09)};

                yield return new object[] {new DateTime(2016, 11, 28), DayOfWeek.Saturday, new DateTime(2016, 12, 03)};
                yield return new object[] {new DateTime(2016, 11, 29), DayOfWeek.Saturday, new DateTime(2016, 12, 03)};
                yield return new object[] {new DateTime(2016, 11, 30), DayOfWeek.Saturday, new DateTime(2016, 12, 03)};
                yield return new object[] {new DateTime(2016, 12, 1), DayOfWeek.Saturday, new DateTime(2016, 12, 03)};
                yield return new object[] {new DateTime(2016, 12, 2), DayOfWeek.Saturday, new DateTime(2016, 12, 03)};
                yield return new object[] {new DateTime(2016, 12, 3), DayOfWeek.Saturday, new DateTime(2016, 12, 10)};
                yield return new object[] {new DateTime(2016, 12, 4), DayOfWeek.Saturday, new DateTime(2016, 12, 10)};

                yield return new object[] {new DateTime(2016, 11, 28), DayOfWeek.Sunday, new DateTime(2016, 12, 04)};
                yield return new object[] {new DateTime(2016, 11, 29), DayOfWeek.Sunday, new DateTime(2016, 12, 04)};
                yield return new object[] {new DateTime(2016, 11, 30), DayOfWeek.Sunday, new DateTime(2016, 12, 04)};
                yield return new object[] {new DateTime(2016, 12, 1), DayOfWeek.Sunday, new DateTime(2016, 12, 04)};
                yield return new object[] {new DateTime(2016, 12, 2), DayOfWeek.Sunday, new DateTime(2016, 12, 04)};
                yield return new object[] {new DateTime(2016, 12, 3), DayOfWeek.Sunday, new DateTime(2016, 12, 04)};
                yield return new object[] {new DateTime(2016, 12, 4), DayOfWeek.Sunday, new DateTime(2016, 12, 11)};
            }
        }

        [Theory]
        [MemberData(nameof(NextMondayTestCases))]
        public void TestNextMonday(DateTime input, DateTime expected)
        {
            Assert.Equal(expected, input.NextMonday());
        }

        public static IEnumerable<object[]> NextMondayTestCases
        {
            get
            {
                yield return new object[] {new DateTime(2016, 11, 28), new DateTime(2016, 12, 05)};
                yield return new object[] {new DateTime(2016, 11, 29), new DateTime(2016, 12, 05)};
                yield return new object[] {new DateTime(2016, 11, 30), new DateTime(2016, 12, 05)};
                yield return new object[] {new DateTime(2016, 12, 1), new DateTime(2016, 12, 05)};
                yield return new object[] {new DateTime(2016, 12, 2), new DateTime(2016, 12, 05)};
                yield return new object[] {new DateTime(2016, 12, 3), new DateTime(2016, 12, 05)};
            }
        }

        [Theory]
        [MemberData(nameof(NextSundayTestCases))]
        public void TestNextSunday(DateTime input, DateTime expected)
        {
            Assert.Equal(expected, input.NextSunday());
        }

        public static IEnumerable<object[]> NextSundayTestCases
        {
            get
            {
                var expectedResult = new DateTime(2016, 12, 04);
                yield return new object[]
                {
                    new DateTime(2016, 11, 27),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 28),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 29),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 30),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 1),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 2),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 3),
                    expectedResult
                };
            }
        }

        [Theory]
        [MemberData(nameof(EndOfTheMonthTestCases))]
        public void TestEndOfTheMonth(DateTime input, DateTime expected)
        {
            Assert.Equal(expected, input.EndOfTheMonth());
        }

        public static IEnumerable<object[]> EndOfTheMonthTestCases
        {
            get
            {
                yield return new object[]
                {
                    new DateTime(2016, 1, 1),
                    new DateTime(2016, 1, 31)
                };
                yield return new object[]
                {
                    new DateTime(2016, 8, 10),
                    new DateTime(2016, 8, 31)
                };
                yield return new object[]
                {
                    new DateTime(2016, 10, 15),
                    new DateTime(2016, 10, 31)
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 28),
                    new DateTime(2016, 11, 30)
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 2),
                    new DateTime(2016, 12, 31)
                };
                yield return new object[]
                {
                    new DateTime(2015, 2, 2),
                    new DateTime(2015, 2, 28)
                };
                //2016 is leap year
                yield return new object[]
                {
                    new DateTime(2016, 2, 2),
                    new DateTime(2016, 2, 29)
                };
            }
        }

        [Theory]
        [MemberData(nameof(BeginningOfTheMonthTestCases))]
        public void TestBeginningOfTheMonth(DateTime input, DateTime expected)
        {
            Assert.Equal(expected, input.BeginningOfTheMonth());
        }

        public static IEnumerable<object[]> BeginningOfTheMonthTestCases
        {
            get
            {
                yield return new object[]
                {
                    new DateTime(2016, 1, 1),
                    new DateTime(2016, 1, 1)
                };
                yield return new object[]
                {
                    new DateTime(2016, 8, 10),
                    new DateTime(2016, 8, 1)
                };
                yield return new object[]
                {
                    new DateTime(2016, 10, 15),
                    new DateTime(2016, 10, 1)
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 28),
                    new DateTime(2016, 11, 1)
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 2),
                    new DateTime(2016, 12, 1)
                };
                yield return new object[]
                {
                    new DateTime(2015, 2, 2),
                    new DateTime(2015, 2, 1)
                };
                //2016 is leap year
                yield return new object[]
                {
                    new DateTime(2016, 2, 2),
                    new DateTime(2016, 2, 1)
                };
                yield return new object[]
                {
                    new DateTime(2016, 2, 29),
                    new DateTime(2016, 2, 1)
                };
            }
        }


        [Theory]
        [MemberData(nameof(WeekMondayTestCases))]
        public void TestWeekMonday(DateTime input, DateTime expected)
        {
            Assert.Equal(expected, input.WeekMonday());
        }

        public static IEnumerable<object[]> WeekMondayTestCases
        {
            get
            {
                var expectedResult = new DateTime(2016, 11, 28, 0, 0, 0);
                yield return new object[]
                {
                    new DateTime(2016, 11, 28, 0, 0, 0),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 29, 0, 0, 0),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 30, 0, 0, 0),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 1, 0, 0, 0),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 2, 0, 0, 0),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 3, 0, 0, 0),
                    expectedResult
                };
            }
        }


        [Theory]
        [MemberData(nameof(WeekFridayTestCases))]
        public void TestWeekFriday(DateTime input, DateTime expected)
        {
            Assert.Equal(expected, input.WeekFriday());
        }

        public static IEnumerable<object[]> WeekFridayTestCases
        {
            get
            {
                var expectedResult = new DateTime(2016, 12, 2, 0, 0, 0);
                yield return new object[]
                {
                    new DateTime(2016, 11, 28, 0, 0, 0),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 29, 0, 0, 0),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 30, 0, 0, 0),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 1, 0, 0, 0),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 2, 0, 0, 0),
                    expectedResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 3, 0, 0, 0),
                    expectedResult
                };
            }
        }

        [Theory]
        [MemberData(nameof(DayOfWeekTestCases))]
        public void TestDayOfWeek(DateTime input, DayOfWeek d, DateTime expected)
        {
            Assert.Equal(expected, input.WeekDay(d));
        }

        public static IEnumerable<object[]> DayOfWeekTestCases
        {
            get
            {
                var expectedMondayResult = new DateTime(2016, 11, 28, 0, 0, 0);
                yield return new object[]
                {
                    new DateTime(2016, 11, 28, 0, 0, 0),
                    DayOfWeek.Monday,
                    expectedMondayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 29, 0, 0, 0),
                    DayOfWeek.Monday,
                    expectedMondayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 30, 0, 0, 0),
                    DayOfWeek.Monday,
                    expectedMondayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 1, 0, 0, 0),
                    DayOfWeek.Monday,
                    expectedMondayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 2, 0, 0, 0),
                    DayOfWeek.Monday,
                    expectedMondayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 3, 0, 0, 0),
                    DayOfWeek.Monday,
                    expectedMondayResult
                };

                var expectedTuesdayResult = new DateTime(2016, 11, 29, 0, 0, 0);
                yield return new object[]
                {
                    new DateTime(2016, 11, 28, 0, 0, 0),
                    DayOfWeek.Tuesday,
                    expectedTuesdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 29, 0, 0, 0),
                    DayOfWeek.Tuesday,
                    expectedTuesdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 30, 0, 0, 0),
                    DayOfWeek.Tuesday,
                    expectedTuesdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 1, 0, 0, 0),
                    DayOfWeek.Tuesday,
                    expectedTuesdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 2, 0, 0, 0),
                    DayOfWeek.Tuesday,
                    expectedTuesdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 3, 0, 0, 0),
                    DayOfWeek.Tuesday,
                    expectedTuesdayResult
                };

                var expectedWednesdayResult = new DateTime(2016, 11, 30, 0, 0, 0);
                yield return new object[]
                {
                    new DateTime(2016, 11, 28, 0, 0, 0),
                    DayOfWeek.Wednesday,
                    expectedWednesdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 29, 0, 0, 0),
                    DayOfWeek.Wednesday,
                    expectedWednesdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 30, 0, 0, 0),
                    DayOfWeek.Wednesday,
                    expectedWednesdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 1, 0, 0, 0),
                    DayOfWeek.Wednesday,
                    expectedWednesdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 2, 0, 0, 0),
                    DayOfWeek.Wednesday,
                    expectedWednesdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 3, 0, 0, 0),
                    DayOfWeek.Wednesday,
                    expectedWednesdayResult
                };

                var expectedThursdayResult = new DateTime(2016, 12, 1, 0, 0, 0);
                yield return new object[]
                {
                    new DateTime(2016, 11, 28, 0, 0, 0),
                    DayOfWeek.Thursday,
                    expectedThursdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 29, 0, 0, 0),
                    DayOfWeek.Thursday,
                    expectedThursdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 30, 0, 0, 0),
                    DayOfWeek.Thursday,
                    expectedThursdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 1, 0, 0, 0),
                    DayOfWeek.Thursday,
                    expectedThursdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 2, 0, 0, 0),
                    DayOfWeek.Thursday,
                    expectedThursdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 3, 0, 0, 0),
                    DayOfWeek.Thursday,
                    expectedThursdayResult
                };

                var expectedFridayResult = new DateTime(2016, 12, 2, 0, 0, 0);
                yield return new object[]
                {
                    new DateTime(2016, 11, 28, 0, 0, 0),
                    DayOfWeek.Friday,
                    expectedFridayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 29, 0, 0, 0),
                    DayOfWeek.Friday,
                    expectedFridayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 30, 0, 0, 0),
                    DayOfWeek.Friday,
                    expectedFridayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 1, 0, 0, 0),
                    DayOfWeek.Friday,
                    expectedFridayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 2, 0, 0, 0),
                    DayOfWeek.Friday,
                    expectedFridayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 3, 0, 0, 0),
                    DayOfWeek.Friday,
                    expectedFridayResult
                };

                var expectedSaturdayResult = new DateTime(2016, 12, 3, 0, 0, 0);
                yield return new object[]
                {
                    new DateTime(2016, 11, 28, 0, 0, 0),
                    DayOfWeek.Saturday,
                    expectedSaturdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 29, 0, 0, 0),
                    DayOfWeek.Saturday,
                    expectedSaturdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 11, 30, 0, 0, 0),
                    DayOfWeek.Saturday,
                    expectedSaturdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 1, 0, 0, 0),
                    DayOfWeek.Saturday,
                    expectedSaturdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 2, 0, 0, 0),
                    DayOfWeek.Saturday,
                    expectedSaturdayResult
                };
                yield return new object[]
                {
                    new DateTime(2016, 12, 3, 0, 0, 0),
                    DayOfWeek.Saturday,
                    expectedSaturdayResult
                };
            }
        }

        [Theory]
        [MemberData(nameof(IsLeapYearTestCases))]
        public void TestIsLeapYear(int year, bool expectedResult)
        {
            Assert.Equal(expectedResult, new DateTime(year, 1, 1).IsLeapYear());
        }

        public static IEnumerable<object[]> IsLeapYearTestCases
        {
            get
            {
                yield return new object[] {1996, true};
                yield return new object[] {1997, false};
                yield return new object[] {1998, false};
                yield return new object[] {1999, false};
                yield return new object[] {2000, true};
            }
        }

        [Theory]
        [MemberData(nameof(BeginningOfNextMonthTestCases))]
        public void TestBeginningOfNextMonth(DateTime input, DateTime expectedOutput)
        {
            Assert.Equal(expectedOutput, input.BeginningOfNextMonth());
        }

        public static IEnumerable<object[]> BeginningOfNextMonthTestCases
        {
            get
            {
                yield return new object[] {new DateTime(2018, 01, 01), new DateTime(2018, 02, 01),};
                yield return new object[] {new DateTime(2018, 01, 02), new DateTime(2018, 02, 01),};
                yield return new object[] {new DateTime(2018, 01, 03), new DateTime(2018, 02, 01),};
                yield return new object[] {new DateTime(2018, 01, 04), new DateTime(2018, 02, 01),};
                yield return new object[] {new DateTime(2018, 01, 05), new DateTime(2018, 02, 01),};
                yield return new object[] {new DateTime(2018, 01, 06), new DateTime(2018, 02, 01),};
                yield return new object[] {new DateTime(2018, 01, 07), new DateTime(2018, 02, 01),};
                yield return new object[] {new DateTime(2018, 01, 08), new DateTime(2018, 02, 01),};
                yield return new object[] {new DateTime(2018, 01, 09), new DateTime(2018, 02, 01),};
                yield return new object[] {new DateTime(2018, 01, 10), new DateTime(2018, 02, 01),};
                yield return new object[] {new DateTime(2018, 02, 01), new DateTime(2018, 03, 01),};
                yield return new object[] {new DateTime(2018, 02, 02), new DateTime(2018, 03, 01),};
                yield return new object[] {new DateTime(2018, 02, 03), new DateTime(2018, 03, 01),};
                yield return new object[] {new DateTime(2018, 02, 04), new DateTime(2018, 03, 01),};
                yield return new object[] {new DateTime(2018, 02, 05), new DateTime(2018, 03, 01),};
                yield return new object[] {new DateTime(2018, 02, 06), new DateTime(2018, 03, 01),};
                yield return new object[] {new DateTime(2018, 02, 07), new DateTime(2018, 03, 01),};
                yield return new object[] {new DateTime(2018, 02, 08), new DateTime(2018, 03, 01),};
                yield return new object[] {new DateTime(2018, 02, 09), new DateTime(2018, 03, 01),};
                yield return new object[] {new DateTime(2018, 02, 10), new DateTime(2018, 03, 01),};
                yield return new object[] {new DateTime(2018, 02, 28), new DateTime(2018, 03, 01),};
                yield return new object[] {new DateTime(2016, 02, 01), new DateTime(2016, 03, 01),};
                yield return new object[] {new DateTime(2016, 02, 02), new DateTime(2016, 03, 01),};
                yield return new object[] {new DateTime(2016, 02, 03), new DateTime(2016, 03, 01),};
                yield return new object[] {new DateTime(2016, 02, 04), new DateTime(2016, 03, 01),};
                yield return new object[] {new DateTime(2016, 02, 05), new DateTime(2016, 03, 01),};
                yield return new object[] {new DateTime(2016, 02, 06), new DateTime(2016, 03, 01),};
                yield return new object[] {new DateTime(2016, 02, 07), new DateTime(2016, 03, 01),};
                yield return new object[] {new DateTime(2016, 02, 08), new DateTime(2016, 03, 01),};
                yield return new object[] {new DateTime(2016, 02, 09), new DateTime(2016, 03, 01),};
                yield return new object[] {new DateTime(2016, 02, 10), new DateTime(2016, 03, 01),};
                yield return new object[] {new DateTime(2016, 02, 29), new DateTime(2016, 03, 01),};
            }
        }

        [Theory]
        [MemberData(nameof(DaysInCurrentMonthTestCases))]
        public void TestDaysInCurrentMonth(DateTime dt, int expectedResult)
        {
            Assert.Equal(expectedResult, dt.DaysInCurrentMonth());
        }

        public static IEnumerable<object[]> DaysInCurrentMonthTestCases
        {
            get
            {
                yield return new object[] {new DateTime(2000, 01, 01), 31};
                yield return new object[] {new DateTime(2000, 02, 01), 29};
                yield return new object[] {new DateTime(2000, 03, 01), 31};
                yield return new object[] {new DateTime(2000, 04, 01), 30};
                yield return new object[] {new DateTime(2000, 05, 01), 31};
                yield return new object[] {new DateTime(2000, 06, 01), 30};
                yield return new object[] {new DateTime(2000, 07, 01), 31};
                yield return new object[] {new DateTime(2000, 08, 01), 31};
                yield return new object[] {new DateTime(2000, 09, 01), 30};
                yield return new object[] {new DateTime(2000, 10, 01), 31};
                yield return new object[] {new DateTime(2000, 11, 01), 30};
                yield return new object[] {new DateTime(2000, 12, 01), 31};
                yield return new object[] {new DateTime(2001, 01, 01), 31};
                yield return new object[] {new DateTime(2001, 02, 01), 28};
                yield return new object[] {new DateTime(2001, 03, 01), 31};
                yield return new object[] {new DateTime(2001, 04, 01), 30};
                yield return new object[] {new DateTime(2001, 05, 01), 31};
                yield return new object[] {new DateTime(2001, 06, 01), 30};
                yield return new object[] {new DateTime(2001, 07, 01), 31};
                yield return new object[] {new DateTime(2001, 08, 01), 31};
                yield return new object[] {new DateTime(2001, 09, 01), 30};
                yield return new object[] {new DateTime(2001, 10, 01), 31};
                yield return new object[] {new DateTime(2001, 11, 01), 30};
                yield return new object[] {new DateTime(2001, 12, 01), 31};
            }
        }
    }
}