using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingLib.Math;

namespace UnitTesting
{
    public class BasicCalcTest
    {
        private readonly BasicCalc _calculator;

        public BasicCalcTest()
        {
            _calculator = new BasicCalc();
        }


        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            int result = _calculator.Add(2, 3);
            Assert.Equal(5, result);
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1, -2)]
        public void Add_Theory(int a, int b, int expectedResult)
        {
            int result = _calculator.Add(a, b);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Divide_ShouldThrowDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(2, 0));
        }

        [Fact]
        public void Factorial_ShouldReturnCorrectAnswer()
        {
            var result = _calculator.Factorial(3);
            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData(3, 6)]
        [InlineData(0, 1)]
        [InlineData(5, 120)]
        public void Factorial_Theory(int a, int expectedResult)
        {
            var result = _calculator.Factorial(a);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Factorial_ShouldThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Factorial(-2));
        }

        [Theory]
        [InlineData(1, -3, 2, 2.0, 1.0)]
        [InlineData(1.0, -2.0, 1.0, 1.0, 1.0)]
        [InlineData(1.0, 0, 1.0, null, null)]
        public void SolveQuadraticEquation_ShouldReturnCorrectRoots(double a, double b, double c, double? expectedFirstRoot, double? expectedSecondRoot)
        {
            var (firstRoot, secondRoot) = _calculator.SolveQuadraticEquation(a, b, c);
            Assert.Equal(expectedFirstRoot, firstRoot);
            Assert.Equal(expectedSecondRoot, secondRoot);
        }

        [Fact]
        public void SolveQuadraticEquation_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.SolveQuadraticEquation(0, 2, 4));
        }
    }
}

