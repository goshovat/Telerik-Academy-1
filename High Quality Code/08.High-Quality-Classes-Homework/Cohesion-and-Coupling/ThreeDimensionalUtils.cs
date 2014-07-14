// <copyright file="ThreeDimensionalUtils.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Utils
{
    using System;
    
    /// <summary>
    /// Describes utils for the three dimensional figure.
    /// </summary>
    internal static class ThreeDimensionalUtils
    {
        /// <summary>
        /// Calculate distance between two points in 3D.
        /// </summary>
        /// <param name="x1">Coordinate X of the first point</param>
        /// <param name="y1">Coordinate Y of the first point</param>
        /// <param name="z1">Coordinate Z of the first point</param>
        /// <param name="x2">Coordinate X of the second point</param>
        /// <param name="y2">Coordinate Y of the second point</param>
        /// <param name="z2">Coordinate Z of the second point</param>
        /// <returns>Returns the distance between the given points.</returns>
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distanceX = x2 - x1;
            double distanceY = y2 - y1;
            double distanceZ = z2 - z1;

            double distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY) + (distanceZ * distanceZ));
            return distance;
        }

        /// <summary>
        /// Calculate the diagonal value
        /// </summary>
        /// <param name="width">Width of the figure.</param>
        /// <param name="height">Height of the figure.</param>
        /// <param name="depth">Depth of the figure.</param>
        /// <returns>Returns the diagonal value.</returns>
        public static double CalcDiagonal(double width, double height, double depth)
        {
            double diagonal = Math.Sqrt((width * width) + (height * height) + (depth * depth));
            return diagonal;
        }

        /// <summary>
        /// Calculate volume of the figure
        /// </summary>
        /// <param name="width">Width of the figure.</param>
        /// <param name="height">Height of the figure.</param>
        /// <param name="depth">Depth of the figure.</param>
        /// <returns>Returns the volume of the figure</returns>
        public static double CalcVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;
            return volume;
        }
    }
}
