using Xunit;
using PrimeNumbers;

namespace PrimeNumbers.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [Trait("Category", "UserInput")]
        [InlineData("1", true)]
        [InlineData("100", true)]
        [InlineData("0", false)]
        [InlineData("-1", false)]
        [InlineData("abc", false)]
        public void TestInputRestraints(string input, bool expected)
        {
            Validator validator = new Validator();
            bool result = validator.AcceptableInput(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "UserInput")]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("abc", false)]
        [InlineData("100", false)]
        [InlineData("nope", false)]
        [InlineData("yes", true)]
        [InlineData("y", true)]
        [InlineData("no", true)]
        [InlineData("n", true)]
        public void TestYesNoRestraints(string input, bool expected)
        {
            Validator validator = new Validator();
            bool result = validator.ParseYN(input, out string selection);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "UserInput")]
        [InlineData("yEs", "Y")]
        [InlineData("nO", "N")]
        [InlineData("y", "Y")]
        [InlineData("n", "N")]
        public void TestYesNoInput(string input, string expected)
        {
            Validator validator = new Validator();
            validator.ParseYN(input, out string selection);
            Assert.Equal(expected, selection);
        }
    }
}
