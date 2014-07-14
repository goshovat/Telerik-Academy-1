// <copyright file="Methods.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Methods
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Contains several methods to execute
    /// </summary>
    internal static class Methods
    {
        /// <summary>
        /// Calculate the area of triangle by given three sides.
        /// </summary>
        /// <param name="sideA">Side A.</param>
        /// <param name="sideB">Side B.</param>
        /// <param name="sideC">Side C.</param>
        /// <returns>Returns the area of the triangle.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">When sides are negative number.</exception>
        /// <exception cref="System.ArgumentException">When sides cannot construct a triangle.</exception>
        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            if (!(sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA))
            {
                throw new ArgumentException("A triangle cannot be constructed from three line segments " +
                                            "if any of them is longer than the sum of the other two.");
            }

            double semiperimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC));

            Debug.Assert(area > 0, "Area must be positive.");

            return area;
        }

        /// <summary>
        /// Get the name of the given figure.
        /// </summary>
        /// <param name="figure">The figure, which name will be returned.</param>
        /// <returns>Returns the figure name</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">When the number is not between 0 and 9.</exception>
        public static string GetFigureName(int figure)
        {
            switch (figure)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    throw new ArgumentOutOfRangeException("Number must be between 0 and 9.");
            }
        }

        /// <summary>
        /// Find the maximal elements from given sequence.
        /// </summary>
        /// <param name="elements">Sequence of elements, where method will find the max element from.</param>
        /// <returns>Returns the maximal element form the sequence.</returns>
        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("elements is null.");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("No elements specified.");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        /// <summary>
        /// Print the number in given format.
        /// </summary>
        /// <param name="number">Number to be formatted.</param>
        /// <param name="format">Format for the number.</param>
        public static void PrintAsNumber(object number, char format)
        {
            switch (format)
            {
                case 'f':
                    Console.WriteLine("{0:f2}", number);
                    break;
                case '%':
                    Console.WriteLine("{0:p0}", number);
                    break;
                case 'r':
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Invalid format. Format must be f, % or r.");
            }
        }
    }
}
