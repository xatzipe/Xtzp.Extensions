using System;
using System.Collections.Generic;
using Xunit;

namespace Xtzp.Extensions.Tests
{
    public class LibExtensionTests
    {
        /// <summary>
        /// tests for the <see cref="ListExtensions.AddWithFormat(IList{string}, string, string[])"/>
        /// </summary>
        /// <returns>The add withFormat.</returns>
        /// <param name="lst">Lst.</param>
        /// <param name="item">Item.</param>
        /// <param name="parameters">Parameters.</param>
        [Theory]
        [MemberData(nameof(AddWithFormatTestCases))]
        public void TestAddWithFormat(IList<string> lst, string item, string[] parameters, IList<string> expected)
        {
            Assert.Equal(expected, lst.AddWithFormat(item, parameters));
        }

        /// <summary>
        /// test cases for <see cref="TestAddWithFormat"/>
        /// </summary>
        /// <value>The add with format test cases.</value>
        public static IEnumerable<object[]> AddWithFormatTestCases
        {
            get
            {
                yield return new object[]
                {
                    new List<string>() {"str1"},
                    null,
                    new string[0],
                    new List<string>() {"str1"}
                };
                yield return new object[]
                {
                    new List<string>() {"str1"},
                    string.Empty,
                    new string[0],
                    new List<string>() {"str1"}
                };
                yield return new object[]
                {
                    new List<string>() {"str1"},
                    "item1",
                    new string[0],
                    new List<string>() {"str1", "item1"}
                };
                yield return new object[]
                {
                    new List<string>() {"str1"},
                    "item1",
                    new[] {"param1"},
                    new List<string>() {"str1", "item1"}
                };
                yield return new object[]
                {
                    new List<string>() {"str1"},
                    "item1 {0}",
                    new[] {"param1"},
                    new List<string>() {"str1", "item1 param1"}
                };
                yield return new object[]
                {
                    new List<string>() {"str1"},
                    "item1 {0} {1}",
                    new[] {"param1", "param2"},
                    new List<string>() {"str1", "item1 param1 param2"}
                };
                yield return new object[]
                {
                    new List<string>() {"str1"},
                    "item1 {0} {1}",
                    new[] {"param2", "param1"},
                    new List<string>() {"str1", "item1 param2 param1"}
                };
            }
        }

        [Fact]
        public void TestAddIfNotExistsWhenTheItemInListExists()
        {
            var lst = new List<string>() {"text1"};
            var expected = new List<string>() {"text1"};
            Assert.Equal(expected, lst.AddIfNotExists("text1"));
        }

        [Fact]
        public void TestAddIfNotExistsWhenTheItemInListDoesNotExist()
        {
            var lst = new List<string>() {"text1"};
            var expected = new List<string>() {"text1", "text2"};
            Assert.Equal(expected, lst.AddIfNotExists("text2"));
        }

        [Fact]
        public void TestAddIfNotExistsThrowsExceptionWhenListNull()
        {
            List<string> lst = null;
            var ex = Assert.Throws<Exception>(() => lst.AddIfNotExists("text1"));
            Assert.Equal("List cannot be null", ex.Message);
        }
    }
}