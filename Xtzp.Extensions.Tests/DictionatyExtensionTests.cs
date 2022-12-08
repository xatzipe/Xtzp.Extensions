using System;
using System.Collections.Generic;
using Xunit;

namespace Xtzp.Extensions.Tests;

public class DictionatyExtensionTests
{
    [Fact]
    public void TestAdd()
    {
        var obj1 = new KeyValuePair<string, string>("Key1", "Value1");

        var d = new Dictionary<string, string>
        {
            { "K1", "V1" }
        };
        d.Add(obj1);
        Assert.Equal(2, d.Count);
        Assert.True(d.ContainsKey("Key1"));
    }

    [Fact]
    public void TestAddThrowsExceptionWhenKeyExists()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var obj1 = new KeyValuePair<string, string>("Key1", "Value1");
            var d = new Dictionary<string, string> { { "Key1", "V1" } };
            d.Add(obj1);
        });
    }

    [Fact]
    public void TestAddRange()
    {
        var obj1 = new KeyValuePair<string, string>("Key1", "Value1");
        var obj2 = new KeyValuePair<string, string>("Key2", "Value2");
        var obj3 = new KeyValuePair<string, string>("Key3", "Value3");
        var obj4 = new KeyValuePair<string, string>("Key4", "Value4");
        var obj5 = new KeyValuePair<string, string>("Key5", "Value5");

        var d = new Dictionary<string, string>
        {
            { "K1", "V1" }
        };
        d.AddRange(new[] { obj1, obj2, obj3, obj4, obj5 });
        Assert.Equal(6, d.Count);
        Assert.True(d.ContainsKey("Key1"));
        Assert.True(d.ContainsKey("Key2"));
        Assert.True(d.ContainsKey("Key3"));
        Assert.True(d.ContainsKey("Key4"));
        Assert.True(d.ContainsKey("Key5"));
    }

    [Fact]
    public void TestAddRangeThrowsExceptionWhenKeyExists()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var obj1 = new KeyValuePair<string, string>("Key1", "Value1");
            var d = new Dictionary<string, string> { { "Key1", "V1" } };
            d.AddRange(new[] { obj1 });
        });
    }
}