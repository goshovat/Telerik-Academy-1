// <copyright file="Demo.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Methods
{
    using System;

    /// <summary>
    /// Demonstrate the functionality of the classes in the project.
    /// </summary>
    internal class Demo
    {
        /// <summary>
        /// Staring method, which demonstrate the refactored methods and classes
        /// </summary>
        private static void Main()
        {
            Console.WriteLine(Methods.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(Methods.GetFigureName(5));

            Console.WriteLine(Methods.FindMax(5, -1, 3, 2, 14, 2, 3));

            Methods.PrintAsNumber(1.3, 'f');
            Methods.PrintAsNumber(0.75, '%');
            Methods.PrintAsNumber(2.30, 'r');

            Line line = new Line(3, -1, 3, 2.5);

            Console.WriteLine("Line length is {0}", line.CalculateLength());
            Console.WriteLine("Horizontal? " + line.IsHorizontal);
            Console.WriteLine("Vertical? " + line.IsVertical);

            Student peter = new Student("Peter", "Ivanov", "17.03.1992", "Sofia");

            Student stella = new Student("Stella", "Markova", "03.11.1993", "Vidin", "gamer", 6);

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
