using System.Collections.Generic;
using Xunit;

namespace Xtzp.Extensions.Tests;

public class StringExtensionTests
{
    /// <summary>
    ///     test cases for <see cref="TestFormatStrReturnsCorrectString" />
    /// </summary>
    public static IEnumerable<object[]> FormatStrTestCases
    {
        get
        {
            yield return new object[]
            {
                null,
                null,
                null
            };
            yield return new object[]
            {
                "",
                null,
                ""
            };
            yield return new object[]
            {
                "Test",
                null,
                "Test"
            };
            yield return new object[]
            {
                "Test",
                new string[0],
                "Test"
            };
            yield return new object[]
            {
                "Test {0}",
                new[] { "STR" },
                "Test STR"
            };
            yield return new object[]
            {
                "Test {0} {1}",
                new[] { "STR", "STR2" },
                "Test STR STR2"
            };

            yield return new object[]
            {
                "{0} Test {0} {1}",
                new[] { "STR", "STR2" },
                "STR Test STR STR2"
            };
        }
    }

    public static IEnumerable<object[]> SplitPascalCaseTestCases
    {
        get
        {
            yield return new object[] { "ARandomText", "A Random Text" };
            yield return new object[] { "aRandomText", "a Random Text" };
            yield return new object[] { "ABCD", "A B C D" };
        }
    }

    public static IEnumerable<object[]> ToCamelCaseTestCases
    {
        get
        {
            yield return new object[] { null, null };
            yield return new object[] { string.Empty, string.Empty };
            yield return new object[] { "A", "A" };
            yield return new object[] { "a", "a" };
            yield return new object[] { "A Random Text", "aRandomText" };
            yield return new object[] { "a Random Text", "aRandomText" };
            yield return new object[] { "A B C D", "aBCD" };
        }
    }

    public static IEnumerable<object[]> ToPascalCaseTestCases
    {
        get
        {
            yield return new object[] { null, null };
            yield return new object[] { string.Empty, string.Empty };
            yield return new object[] { "A", "A" };
            yield return new object[] { "a", "a" };
            yield return new object[] { "A Random Text", "ARandomText" };
            yield return new object[] { "a Random Text", "ARandomText" };
            yield return new object[] { "A B C D", "ABCD" };
        }
    }

    public static IEnumerable<object[]> UcFirstTestCases
    {
        get
        {
            yield return new object[] { "abc", "Abc" };
            yield return new object[] { "a", "A" };
            yield return new object[] { null, null };
            yield return new object[] { string.Empty, string.Empty };
        }
    }

    public static IEnumerable<object[]> EnsurePrefixTestCases
    {
        get
        {
            yield return new object[] { null, "a", null };
            yield return new object[] { string.Empty, "a", "a" };
            yield return new object[] { "Abc", "pref", "prefAbc" };
            yield return new object[] { "prefAbc", "pref", "prefAbc" };
        }
    }

    public static IEnumerable<object[]> EnsureSuffixTestCases
    {
        get
        {
            yield return new object[] { null, "a", null };
            yield return new object[] { string.Empty, "a", "a" };
            yield return new object[] { "Abc", "suff", "Abcsuff" };
            yield return new object[] { "Abccc", "ccc", "Abccc" };
            yield return new object[] { "abccc/", "ccc", "abccc/ccc" };
            yield return new object[] { "abccc/", "/", "abccc/" };
        }
    }

    [Theory]
    [InlineData("", false, "")]
    [InlineData(" ", false, "")]
    [InlineData("  ", false, "")]
    [InlineData(" a ", false, "a")]
    [InlineData(" a a ", false, "a a")]
    [InlineData("      a", false, "a")]
    [InlineData("a      ", false, "a")]
    [InlineData(null, false, null)]
    [InlineData(null, true, "")]
    public void TestTrimSafe(string input, bool emptyStringUponNull, string output)
    {
        Assert.Equal(output, input.TrimSafe(emptyStringUponNull));
    }

    [Theory]
    [MemberData(nameof(FormatStrTestCases))]
    public void TestFormatStrReturnsCorrectString(string initialStr, string[] strs, string expected)
    {
        Assert.Equal(expected, initialStr.FormatStr(strs));
    }

    [Theory]
    [InlineData("", true)]
    [InlineData(null, true)]
    [InlineData(" ", false)]
    [InlineData("abc", false)]
    public void TestIsNullOrEmptyWorks(string a, bool result)
    {
        Assert.Equal(result, a.IsNullOrEmpty());
    }

    [Theory]
    [InlineData(null, null, true)]
    [InlineData(null, "", false)]
    [InlineData(null, "abc", false)]
    [InlineData("", null, false)]
    [InlineData("", "", true)]
    [InlineData("abc", "abc", true)]
    [InlineData("abc", "Abc", false)]
    [InlineData("", "Abc", false)]
    [InlineData(" ", "", false)]
    [InlineData(" ", " ", true)]
    public void TestIsEqualIsCorrect(string a, string b, bool result)
    {
        Assert.Equal(result, a.IsEqual(b));
    }

    [Theory]
    [InlineData("", "a", "")]
    [InlineData(" ", "a", " ")]
    [InlineData(null, "a", "a")]
    [InlineData("a", "b", "a")]
    [InlineData("a", null, "a")]
    public void TestFallbackIfNull(string input, string fallBack, string output)
    {
        Assert.Equal(output, input.FallBackIfNull(fallBack));
    }

    [Theory]
    [InlineData("", "a", "a")]
    [InlineData(" ", "a", " ")]
    [InlineData(null, "a", null)]
    [InlineData("", null, null)]
    [InlineData("a", null, "a")]
    public void TestFallbackIfEmpty(string input, string fallBack, string output)
    {
        Assert.Equal(output, input.FallBackIfEmpty(fallBack));
    }

    [Theory]
    [InlineData("", "a", "a")]
    [InlineData(null, "a", "a")]
    [InlineData(" ", "a", " ")]
    [InlineData("", null, null)]
    [InlineData("a", null, "a")]
    public void TestFallbackIfNullOrEmpty(string input, string fallBack, string output)
    {
        Assert.Equal(output, input.FallBackIfNullOrEmpty(fallBack));
    }

    [Theory]
    [InlineData("", "a", false)]
    [InlineData(null, "a", false)]
    [InlineData("a", null, false)]
    [InlineData("a", "", false)]
    [InlineData("", "", true)]
    [InlineData(null, "", true)]
    [InlineData("", null, true)]
    public void TestEqualIfNullOrEmpty(string input1, string input2, bool output)
    {
        Assert.Equal(output, input1.EqualIfNullOrEmpty(input2));
    }

    [Theory]
    [MemberData(nameof(SplitPascalCaseTestCases))]
    public void TestSplitPascalCase(string input, string expected)
    {
        Assert.Equal(expected, input.SplitPascalCase());
    }

    [Theory]
    [MemberData(nameof(ToCamelCaseTestCases))]
    public void TestToCamelCase(string input, string expected)
    {
        Assert.Equal(expected, input.ToCamelCase());
    }

    [Theory]
    [MemberData(nameof(ToPascalCaseTestCases))]
    public void TestToPascalCase(string input, string expected)
    {
        Assert.Equal(expected, input.ToPascalCase());
    }

    [Theory]
    [MemberData(nameof(UcFirstTestCases))]
    public void TestUcFirst(string input, string expected)
    {
        Assert.Equal(expected, input.UcFirst());
    }

    [Theory]
    [MemberData(nameof(EnsurePrefixTestCases))]
    public void TestEnsurePrefix(string input, string prefix, string expected)
    {
        Assert.Equal(expected, input.EnsurePrefix(prefix));
    }

    [Theory]
    [MemberData(nameof(EnsureSuffixTestCases))]
    public void TestEnsureSuffix(string input, string suffix, string expected)
    {
        Assert.Equal(expected, input.EnsureSuffix(suffix));
    }
}