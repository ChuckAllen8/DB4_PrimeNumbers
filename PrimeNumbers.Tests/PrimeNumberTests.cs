using Xunit;
using PrimeNumbers;
using System;

namespace PrimeNumbers.Tests
{
    public class PrimeNumberTests
    {
        [Theory]
        [Trait("Category", "Calculation Validation")]
        [InlineData(1, 2)]
        [InlineData(10, 29)]
        [InlineData(80, 409)]
        [InlineData(90, 463)]
        [InlineData(168, 997)]
        //[InlineData(100000, 1299709)]
        public void TestPrimes(int n, int expected)
        {
            PrimeNumbers numbers = new PrimeNumbers();
            int result = numbers.GetPrime(n);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "Usability")]
        [InlineData(1, 2)]
        //[InlineData(100000, 1000)]
        public void TestRunTime(int n, int milliseconds)
        {
            PrimeNumbers numbers = new PrimeNumbers();
            DateTime start = DateTime.Now;
            numbers.GetPrime(n);
            DateTime stop = DateTime.Now;
            int result = (stop - start).Milliseconds;
            Assert.InRange(result, 0, milliseconds);
        }
    }
}
