using Fibonacci.Api;
using NUnit.Framework;
using Shouldly;

namespace Fibonacci.Tests
{
    public class FibonacciServiceTests
    {
        private IFibonacciService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new FibonacciService();
        }

        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(5, true)]
        [TestCase(-5, false)]
        [TestCase(7, false)]
        [TestCase(10, false)]
        [TestCase(3.14, false)]
        [Test]
        public void TestIsFibonacci(double number, bool expected)
        {
            var result = _sut.IsFibonacci(number);

            result.ShouldBe(expected);
        }
    }
}