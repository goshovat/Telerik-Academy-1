// <copyright file="Rectangle.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Shapes
{
    using System;

    /// <summary>
    /// Describes the rectangle state.
    /// </summary>
    internal class Rectangle : Figure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public Rectangle(double width, double height)
        {
            if (width < 0)
            {
                throw new ArgumentException("Width cannot be negative.");
            }

            if (height < 0)
            {
                throw new ArgumentException("Height cannot be negative.");
            }

            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets width's value
        /// </summary>
        public double Width { get; private set; }
        
        /// <summary>
        /// Gets height's value
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Calculate perimeter of the rectangle.
        /// </summary>
        /// <returns>Returns the perimeter of the rectangle</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        /// <summary>
        /// Calculate surface of the rectangle.
        /// </summary>
        /// <returns>Returns the surface of the rectangle.</returns>
        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }

        /// <summary>
        /// Convert rectangle to string.
        /// </summary>
        /// <returns>Returns the string representation of the rectangle.</returns>
        public override string ToString()
        {
            string rectangle = "I am rectangle." + base.ToString();
            return rectangle;
        }
    }
}
