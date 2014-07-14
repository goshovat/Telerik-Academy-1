// <copyright file="Line.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Methods
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Describes the geometric line represent by two points.
    /// </summary>
    internal class Line
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Line" /> class.
        /// </summary>
        /// <param name="startPointX">Coordinate X of the first point.</param>
        /// <param name="startPointY">Coordinate Y of the first point.</param>
        /// <param name="stopPointX">Coordinate X of the second point.</param>
        /// <param name="stopPointY">Coordinate Y of the second point.</param>
        public Line(double startPointX, double startPointY, double stopPointX, double stopPointY)
        {
            this.StartPointX = startPointX;
            this.StartPointY = startPointY;
            this.StopPointX = stopPointX;
            this.StopPointY = stopPointY;

            this.IsHorizontal = this.IsLineHorizontal();
            this.IsVertical = this.IsLineVertical();
        }

        /// <summary>
        /// Gets or sets the coordinate X of the first point.
        /// </summary>
        public double StartPointX { get; set; }

        /// <summary>
        /// Gets or sets the coordinate Y of the first point.
        /// </summary>
        public double StartPointY { get; set; }

        /// <summary>
        /// Gets or sets the coordinate X of the second point.
        /// </summary>
        public double StopPointX { get; set; }

        /// <summary>
        /// Gets or sets the coordinate Y of the second point.
        /// </summary>
        public double StopPointY { get; set; }

        /// <summary>
        /// Gets a value indicating whether line is horizontal.
        /// </summary>
        public bool IsHorizontal { get; private set; }

        /// <summary>
        ///  Gets a value indicating whether line is vertical.
        /// </summary>
        public bool IsVertical { get; private set; }

        /// <summary>
        /// Calculate length of the line
        /// </summary>
        /// <returns>Returns the length of the line.</returns>
        public double CalculateLength()
        {
            double distanceBetweenX = this.StopPointX - this.StartPointX;
            double distanceBetweenY = this.StopPointY - this.StartPointY;

            double distance = Math.Sqrt((distanceBetweenX * distanceBetweenX) + (distanceBetweenY * distanceBetweenY));

            Debug.Assert(distance >= 0, "Line cannot has negavite length.");

            return distance;
        }

        /// <summary>
        /// Checks if the line is position vertical.
        /// </summary>
        /// <returns>Returns true if the line is vertical, else returns false.</returns>
        private bool IsLineVertical()
        {
            bool isVertical = this.StartPointX == this.StopPointX;
            return isVertical;
        }

        /// <summary>
        /// Checks if the line is position horizontal.
        /// </summary>
        /// <returns>Returns true if the line is horizontal, else returns false.</returns>
        private bool IsLineHorizontal()
        {
            bool isHorizontal = this.StartPointY == this.StopPointY;
            return isHorizontal;
        }
    }
}
