namespace GeometryFigures
{
    using System;

    public class Circle : Shape
    {

        public Circle(double radius)
            : base(radius, radius)
        {
        }

        public override double CalculateSurface()
        {
            return Math.PI * width * height;
        }
    }
}
