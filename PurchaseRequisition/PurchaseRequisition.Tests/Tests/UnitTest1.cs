//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PurchaseRequisition;
using Xunit;

namespace PurchaseRequisition.Tests
{    
    public class UnitTest1
    {
        /*[Fact]
        public void TestMethod1()
        {
            Assert.Equals(4, 0 + 4);

        }*/

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
