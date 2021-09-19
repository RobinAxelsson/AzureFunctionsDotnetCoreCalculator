using System;
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
