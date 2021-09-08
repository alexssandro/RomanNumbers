using FluentAssertions;
using Xunit;

namespace ConsoleAppRomanNumber.Tests
{
    public class GetRomanNumberTests
    {
        [Fact]
        public void Given89_ShouldReturnLXXXIX()
        {
            var result = RomanNumber.GetRomanNumber(89);

            result.Should().Be("LXXXIX");
        }

        [Fact]
        public void Given91_ShouldReturnXCI()
        {
            var result = RomanNumber.GetRomanNumber(91);

            result.Should().Be("XCI");
        }

        [Fact]
        public void Given1889_ShouldReturnMDCCCLXXXIX()
        {
            var result = RomanNumber.GetRomanNumber(1889);

            result.Should().Be("MDCCCLXXXIX");
        }
    }
}
