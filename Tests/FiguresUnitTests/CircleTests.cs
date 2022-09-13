using Xunit;
using FiguresLibrary.Figures;
using System;

namespace FiguresUnitTests
{
    public class CircleTests
    {
        [Fact]
        public void Create_NegativeRadius_Fail()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-1));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, Math.PI)]
        [InlineData(3.7, 43.008403427644269)]
        public void GetArea_Succed(double radius, double expectedArea)
        {
            //Arrange
            var testCircle = new Circle(radius);

            //Act
            var actual = testCircle.GetArea();

            //Assert
            Assert.Equal(expectedArea, actual);
        }

        [Fact]
        public void GetArea_LargeRadius_Fail()
        {
            //Arrange
            var testCircle = new Circle(double.MaxValue);

            //Act
            var exception = Record.Exception( ()=> testCircle.GetArea());

            //Assert
            Assert.True(exception.Message == "The area of figure is too large.");
        }
    }
}