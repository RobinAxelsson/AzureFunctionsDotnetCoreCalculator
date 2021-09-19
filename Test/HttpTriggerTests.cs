using System;
using Function;
using Xunit;

namespace Test
{
    public class HttpTriggerTests
    {
        [Fact]
        public void StartUp() => Assert.True(true);
        [Fact]
        public void ConnectReference() => Assert.False(HttpTrigger.Flip(true));
    }
}
