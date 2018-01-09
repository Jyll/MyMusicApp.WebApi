using System;
using Xunit;

namespace Test.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = nameof(Test1))]
        public void Test1()
        {
            Assert.True(true);
        }
    }
}
