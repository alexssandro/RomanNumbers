using FluentAssertions;
using Xunit;

namespace ConsoleAppRomanNumber.Tests
{
    public class GetDecimalNumberTests
    {
        [Fact]
        public void GivenXXI_ShouldReturn21()
        {
            var result = RomanNumber.GetDecimalNumber("XXI");

            result.Should().Be(21);
        }

        [Fact]
        public void GivenMDCLXVI_ShouldReturn1666()
        {
            var result = RomanNumber.GetDecimalNumber("MDCLXVI");

            result.Should().Be(1666);
        }

        [Fact]
        public void GivenMMVIII_ShouldReturn2008()
        {
            var result = RomanNumber.GetDecimalNumber("MMVIII");

            result.Should().Be(2008);
        }
    }
}
