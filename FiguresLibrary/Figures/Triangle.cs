namespace FiguresLibrary.Figures
{
    public class Triangle : BaseFigure
    {
        private double _firstSide { get; }
        private double _secondSide { get; }
        private double _thirdSide { get; }

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            //It is assumed that the triangle degenerate into a segment is acceptable.
            if (firstSide < 0 || secondSide < 0 || thirdSide < 0)
            {
                throw new ArgumentException("Attempt to create triangle with negative side length.");
            }

            //Expression could be simplified according to basic rules of Boolean algebra, but this will lead to loosing obvious geometrical interpritation of expression.
            if (!((firstSide <= secondSide + thirdSide) &&
                  (secondSide <= firstSide + thirdSide) &&
                  (thirdSide <= firstSide + secondSide)))
            {
                throw new ArgumentException("Can't create triangle from entered sides.");
            }

            _firstSide = firstSide;
            _secondSide = secondSide;
            _thirdSide = thirdSide;
        }

        public override double GetArea()
        {
            var halfPerimeter = (_firstSide + _secondSide + _thirdSide) / 2;
            var answer = Math.Sqrt(halfPerimeter * (halfPerimeter - _firstSide) * (halfPerimeter - _secondSide) * (halfPerimeter - _thirdSide));
            return double.IsFinite(answer) ? answer : throw new OverflowException("The area of figure is too large.");
        }

        public bool IsRightTriangle()
        {
            //Number 10 was chosen based on consideration 2^-32 ~ 2*e-10.
            const int accurracy = 10;
            var firstSideSquare = Math.Round(_firstSide * _firstSide , accurracy);
            var secondSideSquare = Math.Round(_secondSide * _secondSide , accurracy );
            var thirdSideSquare = Math.Round(_thirdSide * _thirdSide , accurracy);
            if (double.IsInfinity(firstSideSquare) || double.IsInfinity(secondSideSquare) || double.IsInfinity(thirdSideSquare))
            {
                throw new OverflowException("Can't check this triangle, sides is too big.");
            }
            return (firstSideSquare == secondSideSquare + thirdSideSquare ||
                    secondSideSquare == firstSideSquare + thirdSideSquare ||
                    thirdSideSquare == firstSideSquare + secondSideSquare);
        }
    }
}
