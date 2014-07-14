// <copyright file="TwoDimensionalUtils.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Utils
{
    using System;

    /// <summary>
    /// Describes utils for two dimensional figure.
    /// </summary>
    internal static class TwoDimensionalUtils
    {      
        /// <summary>
        /// Calculate distance between two points in 2D.
        /// </summary>
        /// <param name="x1">Coordinate X of the first point</param>
        /// <param name="y1">Coordinate Y of the first point</param>
        /// <param name="x2">Coordinate X of the second point</param>
        /// <param name="y2">Coordinate Y of the second point</param>
        /// <returns>Returns the distance between the given points.</returns>
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distanceX = x2 - x1;
            double distanceY = y2 - y1;

            double distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY));
            return distance;
        }

        /// <summary>
        /// Calculate the diagonal value
        /// </summary>
        /// <param name="firstSide">First side of the figure.</param>
        /// <param name="secondSide">Second side of the figure.</param>
        /// <returns>Returns the diagonal value.</returns>
        public static double CalcDiagonal(double firstSide, double secondSide)
        {
            double diagonal = Math.Sqrt((firstSide * firstSide) + (secondSide * secondSide));
            return diagonal;
        }
    }
}
