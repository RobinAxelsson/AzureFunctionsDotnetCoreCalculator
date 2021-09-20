using Function;
using Xunit;

namespace Test
{
    public class HttpTriggerValidationTests
    {

        [Fact]
        public void StartUp() => Assert.True(true);
        [Fact]
        public void InputDots() => Assert.Null(HttpTrigger.ValidateInput("1.."));
        [Fact]
        public void InputDots3() => Assert.Null(HttpTrigger.ValidateInput("..."));
        [Fact]
        public void InputDotLast() => Assert.Equal("1.", HttpTrigger.ValidateInput("1."));
        [Fact]
        public void InputBraces() => Assert.Null(HttpTrigger.ValidateInput("{{"));
        [Fact]
        public void InputBraces2() => Assert.Null(HttpTrigger.ValidateInput("["));
        [Fact]
        public void InputBraces3() => Assert.Null(HttpTrigger.ValidateInput("("));
        [Fact]
        public void InputQoute() => Assert.Null(HttpTrigger.ValidateInput("\""));
        [Fact]
        public void InputSingleQoute() => Assert.Null(HttpTrigger.ValidateInput("'"));
        [Fact]
        public void InputAlpha() => Assert.Null(HttpTrigger.ValidateInput("abcd"));
        [Fact]
        public void InputAlpha2() => Assert.Null(HttpTrigger.ValidateInput("你好，世界"));
        [Fact]
        public void InputRocket() => Assert.Null(HttpTrigger.ValidateInput("🚀"));
        [Fact]
        public void InputDot() => Assert.Null(HttpTrigger.ValidateInput("."));
        [Fact]
        public void InputMiddleMinus() => Assert.Null(HttpTrigger.ValidateInput("1-1"));
        [Fact]
        public void IsOne() => Assert.Equal("1", HttpTrigger.ValidateInput("1"));
        [Fact]
        public void IsOnePointOne() => Assert.Equal("1.0", HttpTrigger.ValidateInput("1.0"));
        [Fact]
        public void IsOnePoint__() => Assert.Equal("1.0000", HttpTrigger.ValidateInput("1.0000"));
    }
}
