using System.Collections.Generic;
using Xunit;

namespace Xtzp.Extensions.Tests
{
    public class CollectionExtensionTests
    {
        [Fact]
        public void TestAddRange()
        {
            var input = (ICollection<string>)new List<string>() {"text1"};
            input.AddRange(new[] {"text2", "text3"});
            Assert.Equal(new List<string> {"text1", "text2", "text3"}, input);
        }
    }
}