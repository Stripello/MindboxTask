using FiguresLibrary.Figures;
using System;
using Xunit;

namespace FiguresUnitTests
{
    public class CircleTests
    {
        [Fact]
        public void Create_NegativeRadius_Fail()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-1));
        }

        #region GetArea
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, Math.PI)]
        [InlineData(3.7, 43.0084034276)]
        public void GetArea_Succed(double radius, double expectedArea)
        {
            //Arrange
            //Number 10 was chosen based on consideration 2^-32 ~ 2*e-10.
            const int accuracy = 10;
            var testCircle = new Circle(radius);

            //Act
            var actual = testCircle.GetArea();

            //Assert
            Assert.Equal(Math.Round(expectedArea,accuracy), Math.Round(actual,accuracy));
        }

        [Fact]
        public void GetArea_LargeRadius_Fail()
        {
            //Arrange
            var testCircle = new Circle(double.MaxValue);

            //Act
            var exception = Record.Exception(() => testCircle.GetArea());

            //Assert
            Assert.True(exception.Message == "The area of figure is too large.");
        }
        #endregion
    }
}