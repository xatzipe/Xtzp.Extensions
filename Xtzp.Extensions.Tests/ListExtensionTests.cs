using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Xtzp.Extensions.Tests
{
    public class ListExtensionTests
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


        [Fact]
        public void TestAddIfNotExistsOverrideThrowsExceptionWhenListNull()
        {
            List<string> lst = null;
            var ex = Assert.Throws<Exception>(() => lst.AddIfNotExists(v => true, "text1"));
            Assert.Equal("List cannot be null", ex.Message);
        }
        
        [Theory]
        [MemberData(nameof(AddIfNotExistsOverrideAddsItemWhenNotInListTestCases))]
        public void TestAddIfNotExistsOverrideAddsItemWhenNotInList(
            List<AddIfNotExistPOCOClass> expected, 
            List<AddIfNotExistPOCOClass> actual
        )
        {
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<Object[]> AddIfNotExistsOverrideAddsItemWhenNotInListTestCases
        {
            get
            {
                var obj1 = new AddIfNotExistPOCOClass("Name1", "LastName1", 10);
                var obj2 = new AddIfNotExistPOCOClass("Name1", "LastName2", 11);
                var obj3 = new AddIfNotExistPOCOClass("Name3", "LastName3", 12);
                var obj4 = new AddIfNotExistPOCOClass("Name1", "LastName1", 14);
                var obj5 = new AddIfNotExistPOCOClass("Name5", "LastName5", 15);
                
                var lst = new List<AddIfNotExistPOCOClass>();
                lst.AddIfNotExists(obj1);
                
                yield return new object[]{ new [] {obj1}.ToList(), lst};
                
                lst = new List<AddIfNotExistPOCOClass>();
                lst.AddIfNotExists(obj1);
                lst.AddIfNotExists(o => o.Name == obj2.Name, obj2);
                yield return new object[]{ new [] {obj1}.ToList(), lst};
                
                lst = new List<AddIfNotExistPOCOClass>();
                lst.AddIfNotExists(obj1);
                lst.AddIfNotExists(o => o.Name == obj3.Name, obj3);
                yield return new object[]{ new [] {obj1, obj3}.ToList(), lst};
                
                lst = new List<AddIfNotExistPOCOClass>();
                lst.AddIfNotExists(obj1);
                lst.AddIfNotExists(obj3);
                lst.AddIfNotExists(o => o.Name == obj4.Name && o.LastName == obj4.LastName, obj4);
                yield return new object[]{ new [] {obj1, obj3}.ToList(), lst};

                lst = new List<AddIfNotExistPOCOClass>();
                lst.AddIfNotExists(obj1);
                lst.AddIfNotExists(obj3);
                lst.AddIfNotExists(o => o.Age == obj5.Age, obj5);
                yield return new object[]{ new [] {obj1, obj3, obj5}.ToList(), lst};

            }
        }

        public class AddIfNotExistPOCOClass
        {
            public readonly string Name;
            public readonly string LastName;
            public readonly int Age;

            public AddIfNotExistPOCOClass(string name, string lastName, int age)
            {
                Name = name;
                LastName = lastName;
                Age = age;
            }
        }
    }
}