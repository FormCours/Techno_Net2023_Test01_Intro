using Testing_01_Intro.BLL.CustomExceptions;
using Xunit;

namespace Testing_01_Intro.BLL.Test
{
    public class CalculatorTests
    {
        private readonly Calculator calculator;

        public CalculatorTests()
        {
            calculator = new Calculator();
        }

        #region Test method Add
        [Fact]
        public void Add_TwoInteger()
        {
            // Arrange (Initialisation)
            double val1 = 22;
            double val2 = 20;
            double expected = 42;

            // Action (Code a tester)
            double actual = calculator.Add(val1, val2);

            // Assert (Validation du test)
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_TwoReal()
        {
            // Arrange
            double val1 = 13.154291;
            double val2 = 2.936321;
            double expect = 16.090612;

            // Action 
            double actual = calculator.Add(val1, val2);

            // Assert
            Assert.Equal(expect, actual);
        }


        [Fact]
        public void Add_TwoReal_Bug_IEEE754()
        {
            // Arrange
            double val1 = 0.1;
            double val2 = 0.2;
            double expect = 0.3;

            // Action 
            double actual = calculator.Add(val1, val2);

            // Assert
            Assert.Equal(expect, actual);
        }
        #endregion

        #region Test method Sub
        [Theory] // Comme "Fact", mais permet d'utiliser "InlineData" ou "MemberData"
        [InlineData(50, 8, 42)]
        [InlineData(50, 0.42, 49.58)]
        [InlineData(0.3, 0.1, 0.2)]
        public void Sub_TwoNumber(double val1, double val2, double expect)
        {
            // Arrange → Via Theory + InlineData

            // Action
            double actual = calculator.Sub(val1, val2);

            // Assert
            Assert.Equal(expect, actual);
        }
        #endregion

        #region Test method Multi
        public static IEnumerable<object[]> multiData = new List<object[]>
        {
            new object[] { 2, 3, 6 },
            new object[] { 5, -3, -15 },
            new object[] { 3, 0, 0 },
            new object[] { 0.5, 0.5, 0.25 },
        };

        [Theory]
        [MemberData(nameof(multiData))]
        public void Multi_TwoNumber(double val1, double val2, double expect)
        {
            // Arrange

            // Action
            double actual = calculator.Multi(val1, val2);

            // Assert
            Assert.Equal(expect, actual);
        }
        #endregion

        #region Test method Div
        [Fact]
        public void Div_TwoNumber()
        {
            // Arrange
            double val1 = 5;
            double val2 = 2;
            double expect = 2.5;

            // Action
            double actual = calculator.Div(val1, val2);

            // Assert
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void Sub_DivByZero_Error()
        {
            // Arrange 
            double val1 = 10;
            double val2 = 0;

            // Action + Assert
            Assert.Throws<DivByZeroCalculatorException>(() =>
            {
                calculator.Div(val1, val2);
            });

        }
        #endregion

        #region Test out of range
        [Fact]
        public void Add_OutOfRange()
        {
            // Arrange 
            double val1 = double.MaxValue;
            double val2 = double.MaxValue;

            // Action + Assert 
            Assert.Throws<OutOfRangeCalculatorException>(() =>
            {
                double result = calculator.Add(val1, val2);
            });
        }

        [Fact]
        public void Sub_OutOfRange()
        {
            // Arrange 
            double val1 = double.MinValue;
            double val2 = double.MaxValue;

            // Action + Assert 
            Assert.Throws<OutOfRangeCalculatorException>(() =>
            {
                double result = calculator.Sub(val1, val2);
            });
        }

        [Fact]
        public void Multi_OutOfRange()
        {
            // Arrange 
            double val1 = double.MaxValue;
            double val2 = 2;

            // Action + Assert 
            Assert.Throws<OutOfRangeCalculatorException>(() =>
            {
                double result = calculator.Multi(val1, val2);
            });
        }

        [Fact]
        public void Div_OutOfRange()
        {
            // Arrange 
            double val1 = 2;
            double val2 = 1/double.MaxValue;

            // Action + Assert 
            Assert.Throws<OutOfRangeCalculatorException>(() =>
            {
                double result = calculator.Div(val1, val2);
            });
        }
        #endregion
    }
}
