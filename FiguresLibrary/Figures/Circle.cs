namespace FiguresLibrary.Figures
{
    public class Circle : BaseFigure
    {
        private double _radius { get; }

        public Circle(double radius)
        {
            //It is assumed that the circle degenerate to a point is acceptable.
            if (radius < 0)
            {
                throw new ArgumentException("Attempt to create circle with negative radius.");
            }
            _radius = radius;
        }

        public override double GetArea()
        {
            var answer = Math.PI * _radius * _radius;
            return double.IsFinite(answer) ? answer : throw new Exception("The area of figure is too large.");
        }
    }
}
