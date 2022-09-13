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
            if (  !((firstSide <= secondSide + thirdSide) && 
                  (secondSide <= firstSide + thirdSide)  &&
                  (thirdSide <= firstSide + secondSide)) )
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
            return double.IsFinite(answer) ? answer : throw new ArgumentException("The area of figure is too large.");
        }

        public bool IsRightTriangle()
        {
            var firstSideSquare = _firstSide * _firstSide;
            var secondSideSquare = _secondSide * _secondSide;
            var thirdSideSquare = _thirdSide * _thirdSide;
            return (firstSideSquare == secondSideSquare + thirdSideSquare ||
                    secondSideSquare == firstSideSquare + thirdSideSquare ||
                    thirdSideSquare == firstSideSquare + secondSideSquare);
        }
    }
}
