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
            var ex = Assert.Throws<Exception>(() => lst.AddIfNotExists(ob => v => true, "text1"));
            Assert.Equal("List cannot be null", ex.Message);
        }

        [Theory]
        [MemberData(nameof(AddIfNotExistsOverrideAddsItemWhenNotInListTestCases))]
        public void TestAddIfNotExistsOverrideAddsItemWhenNotInList(
            List<AddIfNotExistPocoClass> expected,
            List<AddIfNotExistPocoClass> actual
        )
        {
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<Object[]> AddIfNotExistsOverrideAddsItemWhenNotInListTestCases
        {
            get
            {
                var obj1 = new AddIfNotExistPocoClass("Name1", "LastName1", 10);
                var obj2 = new AddIfNotExistPocoClass("Name1", "LastName2", 11);
                var obj3 = new AddIfNotExistPocoClass("Name3", "LastName3", 12);
                var obj4 = new AddIfNotExistPocoClass("Name1", "LastName1", 14);
                var obj5 = new AddIfNotExistPocoClass("Name5", "LastName5", 15);

                var lst = new List<AddIfNotExistPocoClass>();
                lst.AddIfNotExists(obj1);

                yield return new object[] {new[] {obj1}.ToList(), lst};

                lst = new List<AddIfNotExistPocoClass>();
                lst.AddIfNotExists(obj1);
                lst.AddIfNotExists(ob => o => o.Name == ob.Name, obj2);
                yield return new object[] {new[] {obj1}.ToList(), lst};

                lst = new List<AddIfNotExistPocoClass>();
                lst.AddIfNotExists(obj1);
                lst.AddIfNotExists(ob => o => o.Name == ob.Name, obj3);
                yield return new object[] {new[] {obj1, obj3}.ToList(), lst};

                lst = new List<AddIfNotExistPocoClass>();
                lst.AddIfNotExists(obj1);
                lst.AddIfNotExists(obj3);
                lst.AddIfNotExists(ob => o => o.Name == ob.Name && o.LastName == ob.LastName, obj4);
                yield return new object[] {new[] {obj1, obj3}.ToList(), lst};

                lst = new List<AddIfNotExistPocoClass>();
                lst.AddIfNotExists(obj1);
                lst.AddIfNotExists(obj3);
                lst.AddIfNotExists(ob => o => o.Age == ob.Age, obj5);
                yield return new object[] {new[] {obj1, obj3, obj5}.ToList(), lst};
            }
        }

        [Fact]
        public void TestAddRangeIfNotExists()
        {
            var obj1 = new AddIfNotExistPocoClass("Name1", "LastName1", 10);
            var obj2 = new AddIfNotExistPocoClass("Name1", "LastName2", 11);
            var obj3 = new AddIfNotExistPocoClass("Name3", "LastName3", 12);
            var obj4 = new AddIfNotExistPocoClass("Name1", "LastName1", 14);
            var obj5 = new AddIfNotExistPocoClass("Name5", "LastName5", 15);

            var lst = new List<AddIfNotExistPocoClass>()
            {
                obj1,
                obj2
            };
            lst.AddRangeIfNotExists(
                obj => o => o.Name == obj.Name && o.LastName == obj.LastName,
                new[] {obj4, obj5}
            );
            Assert.Equal(new[] {obj1, obj2, obj5}, lst);
        }

        public class AddIfNotExistPocoClass
        {
            public readonly string Name;
            public readonly string LastName;
            public readonly int Age;

            public AddIfNotExistPocoClass(string name, string lastName, int age)
            {
                Name = name;
                LastName = lastName;
                Age = age;
            }
        }
    }
}