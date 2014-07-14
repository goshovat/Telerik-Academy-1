// <copyright file="FiguresExample.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Shapes
{
    using System;

    /// <summary>
    /// Demonstrates figures' state
    /// </summary>
    internal class FiguresExample
    {
        /// <summary>
        /// Demonstrate the usage of figures
        /// </summary>
        public static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine(circle);
            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine(rect);
        }
    }
}
