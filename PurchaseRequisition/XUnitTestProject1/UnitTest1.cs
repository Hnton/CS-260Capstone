using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true); 
        }

        [Fact]
        public void TestMethod1()
        {
            Assert.Equal(4, 0 + 4);
        }

        [Fact]
        public void PassingTest()
        {
            Console.WriteLine("In Passing Test");
            Assert.Equal(4, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
