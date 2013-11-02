namespace GeometryFigures
{
    using System;

    public class Demo
    {
        static void Main(string[] args)
        {
            Console.Title = "Shapes";

            Shape[] shapes = 
                         { new Rectangle(2,5),
                           new Triangle(4,2),
                           new Circle(2)
                         };

            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
