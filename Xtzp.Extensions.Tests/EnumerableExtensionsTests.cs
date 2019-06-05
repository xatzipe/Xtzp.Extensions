using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Xtzp.Extensions.Tests
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void TestBatchEnumerableReturnsBatchSize()
        {
            var itemsList = new[]
            {
                1, 2, 3, 4, 5,
                6, 7, 8, 9, 10,
                11, 12, 13, 14, 15,
                16, 17, 18, 19, 20,
                21, 22, 23, 24, 25,
            };
            var result = itemsList.Batch(5);
            var resultList = result.ToList();
            Assert.Equal(5, resultList.Count);
            Assert.Equal(new[] {1, 2, 3, 4, 5}, resultList[0]);
            Assert.Equal(new[] {6, 7, 8, 9, 10,}, resultList[1]);
            Assert.Equal(new[] {11, 12, 13, 14, 15,}, resultList[2]);
            Assert.Equal(new[] {16, 17, 18, 19, 20,}, resultList[3]);
            Assert.Equal(new[] {21, 22, 23, 24, 25,}, resultList[4]);
        }

        [Fact]
        public void TestBatchEnumerableReturnsBatchSize_WhenInputIsEmpty()
        {
            var enumerable = (IEnumerable<string>) new List<string>(); 
            Assert.Equal(Enumerable.Empty<IEnumerable<string>>(), enumerable.Batch(3));
        }
        
        [Fact]
        public void TestBatchEnumerableReturnsBatchSize_WhenInputIsNull()
        {
            var enumerable = (IEnumerable<string>) null; 
            Assert.Equal(Enumerable.Empty<IEnumerable<string>>(), enumerable.Batch(3));
        }
    }
}