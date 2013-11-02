namespace GeometryFigures
{
    using System;

    public abstract class Shape
    {
        protected double width;
        protected double height;

        public Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        
        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public abstract double CalculateSurface();

        public override string ToString()
        {
            return string.Format("Type: {0}\n\tWidht: {1}\n\tHeight: {2}\n\tSurfice: {3:F2}", this.GetType().Name, this.width, this.height, this.CalculateSurface());
        }
    }
}
