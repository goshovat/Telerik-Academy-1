// <copyright file="Circle.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Shapes
{
    using System;

    /// <summary>
    /// Describes the circle state.
    /// </summary>
    internal class Circle : Figure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">Radius of the circle.</param>
        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Radius cannot be negative.");
            }

            this.Radius = radius;
        }

        /// <summary>
        /// Gets the radius's values
        /// </summary>
        public double Radius { get; private set; }

        /// <summary>
        /// Calculate perimeter of the circle.
        /// </summary>
        /// <returns>Returns the perimeter of the circle</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        /// <summary>
        /// Calculate surface of the circle.
        /// </summary>
        /// <returns>Returns the surface of the circle.</returns>
        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }

        /// <summary>
        /// Convert circle to string.
        /// </summary>
        /// <returns>Returns the circle representation of the rectangle.</returns>
        public override string ToString()
        {
            string circle = "I am circle." + base.ToString();
            return circle;
        }
    }
}
