// <copyright file="Figure.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Shapes
{
    using System;

    /// <summary>
    /// Describes the geometric figures state.
    /// </summary>
    internal abstract class Figure : IFigure
    {
        /// <summary>
        /// Calculate the perimeter of the figure.
        /// </summary>
        /// <returns>Returns the perimeter of the figure</returns>
        public abstract double CalcPerimeter();

        /// <summary>
        /// Calculate the surface of the figure.
        /// </summary>
        /// <returns>Returns the surface of the figure</returns>
        public abstract double CalcSurface();

        /// <summary>
        /// Convert figure as string.
        /// </summary>
        /// <returns>Returns string representation of the figure.</returns>
        public override string ToString()
        {
            string figure = string.Format(
                "My perimeter is {0:f2}. My surface is {1:f2}.", this.CalcPerimeter(), this.CalcSurface());

            return figure;
        }

    }
}
