using DesktopUI.Extensions;
using DesktopUI.Extensions.Logic;
using DesktopUI.Tests.Data;
using Xunit;
using LogicColor = Logic.Records.Color;
using RaylibColor = Raylib_cs.Color;

namespace DesktopUI.Tests
{
    public class FunctionTests
    {
        [Theory]
        [ClassData(typeof(ColorToRaylibColorConversionData))]
        public void ColorToRaylibColorConversion(LogicColor color, RaylibColor expectedOutput)
        {
            var output = color.ToRaylibColor();
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void LCM_GCD_Tests()
        {
            Assert.True(15.LeastCommonMultiple(20) == 60);
            Assert.True(4.LeastCommonMultiple(6) == 12);
            Assert.True(32.LeastCommonMultiple(64) == 64);

            Assert.True(24.GreatestCommonDenominator(18) == 6);
            Assert.True(16420.GreatestCommonDenominator(49485) == 5);
            Assert.True(1642031232.GreatestCommonDenominator(494851231) == 1);
        }
    }
}