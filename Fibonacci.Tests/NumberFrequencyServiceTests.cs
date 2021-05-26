using Fibonacci.Api;
using NUnit.Framework;
using Shouldly;

namespace Fibonacci.Tests
{
    public class NumberFrequencyServiceTests
    {
        private INumberFrequencyService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new NumberFrequencyService();
        }

        [Test]
        public void TestIncrementingFrequency()
        {
            var frequency = _sut.IncrementFrequency(5);
            frequency.ShouldBe(1);

            frequency = _sut.IncrementFrequency(5);
            frequency.ShouldBe(2);

            _sut.IncrementFrequency(7);

            var actualNumbers = _sut.Numbers;
            actualNumbers.ShouldContainKey(5);
            actualNumbers[5].ShouldBe(2);

            actualNumbers.ShouldContainKey(7);
            actualNumbers[7].ShouldBe(1);

            actualNumbers.ShouldNotContainKey(10);
        }
    }
}