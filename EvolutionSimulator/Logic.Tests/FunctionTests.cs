using System;
using Logic.Records;
using Xunit;
using Xunit.Abstractions;

namespace Logic.Tests
{
    public class FunctionTests
    {
        private ITestOutputHelper _testOutput;
        public FunctionTests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Theory]
        [InlineData(66 , 245, 138, "#42f58a")]
        [InlineData(215, 245, 66 , "#d7f542")]
        [InlineData(245, 66 , 239, "#f542ef")]
        [InlineData(0  , 0  , 0  , "#000000")]
        public void ColorToHex(int R, int G, int B, string expectedOutput)
        {
            Color color = new Color(R, G, B);
            string output = color.ToHex();
            _testOutput.WriteLine($"Generated Output: {output}");
            Assert.True(String.Compare(output, expectedOutput, StringComparison.OrdinalIgnoreCase) == 0);
        }
    }
}