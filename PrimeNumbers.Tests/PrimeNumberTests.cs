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
        [InlineData(100000, 1299709)]
        [InlineData(200000, 2750159)]
        [InlineData(1000000,15485863)]
        [InlineData(2000000, 32452843)]
        public void TestPrimes(int n, int expected)
        {
            PrimeNumbers numbers = new PrimeNumbers();
            int result = numbers.GetPrime(n);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "Usability")]
        [InlineData(1, 1)]
        [InlineData(100000, 1)]
        [InlineData(1000000, 5)]
        [InlineData(2000000, 10)]
        public void TestRunTime(int n, int seconds)
        {
            PrimeNumbers numbers = new PrimeNumbers();
            DateTime start = DateTime.Now;
            numbers.GetPrime(n);
            DateTime stop = DateTime.Now;
            double result = (stop - start).Seconds + ((stop - start).Milliseconds / 1000);
            Assert.InRange(result, 0, seconds);
        }
    }
}
