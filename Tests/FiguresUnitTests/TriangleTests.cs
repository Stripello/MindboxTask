using FiguresLibrary.Figures;
using Xunit;

namespace FiguresUnitTests
{
    public class TriangleTests
    {
        #region Initialization
        [Theory]
        [InlineData(-1, 1, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 1, -1)]
        public void Initialization_NegativeSide_Fail(double firstSide, double secondSide, double thirdSide)
        {
            //Act
            var exception = Record.Exception(() => new Triangle(firstSide, secondSide, thirdSide));

            //Assert
            Assert.True(exception.Message == "Attempt to create triangle with negative side length.");
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 3, 1)]
        [InlineData(5, 3, 2)]
        public void Initialization_DegenereteCases_Succed(double firstSide, double secondSide, double thirdSide)
        {
            //Act
            var exception = Record.Exception(() => new Triangle(firstSide, secondSide, thirdSide));

            //Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(3, 1, 1)]
        [InlineData(1, 3, 1)]
        [InlineData(1, 1, 3)]
        public void Initialization_ImpossibleSides_Fail(double firstSide, double secondSide, double thirdSide)
        {
            //Act
            var exception = Record.Exception(() => new Triangle(firstSide, secondSide, thirdSide));

            //Assert
            Assert.True(exception.Message == "Can't create triangle from entered sides.");
        }
        #endregion

        #region GetArea
        [Theory]
        [InlineData(2, 2, 2, 1.7320508075688772)]
        [InlineData(3, 4, 5, 6)]
        [InlineData(8, 4, 6, 11.61895003862225)]
        public void GetArea_Succed(double firstSide, double secondSide, double thirdSide, double expectedArea)
        {
            //Arrange
            var testTriangle = new Triangle(firstSide, secondSide, thirdSide);

            //Act
            var actual = testTriangle.GetArea();

            //Assert
            Assert.Equal(expectedArea, actual);
        }

        [Fact]
        public void GetArea_LargeSide_Fail()
        {
            //Arrange
            var testTriangle = new Triangle(double.MaxValue, double.MaxValue, double.MaxValue);

            //Act
            var exception = Record.Exception(() => testTriangle.GetArea());

            //Assert
            Assert.True(exception.Message == "The area of figure is too large.");
        }
        #endregion

        #region IsRightTriangle
        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(4, 3, 5, true)]
        [InlineData(3, 5, 4, true)]
        [InlineData(4, 5, 3, true)]
        [InlineData(5, 4, 3, true)]
        [InlineData(5, 3, 4, true)]
        [InlineData(6, 4, 5, false)]
        [InlineData(4, 4, 5, false)]
        public void IsRightTriangle_Succed(double firstSide, double secondSide, double thirdSide, bool expected)
        {
            //Arrange
            var testTriangle = new Triangle(firstSide, secondSide, thirdSide);

            //Act
            var actual = testTriangle.IsRightTriangle();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsRightTrangle_LargeSides_Fail()
        {
            //Arrange
            var testTriangle = new Triangle(double.MaxValue, double.MaxValue, double.MaxValue);

            //Act
            var excepton = Record.Exception(() => testTriangle.IsRightTriangle());

            //Assert
            Assert.True(excepton.Message == "Can't check this triangle, sides is too big.");
        }
        #endregion
    }
}
