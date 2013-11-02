namespace _3dSpace
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class TestProgram
    {
        static void Main(string[] args)
        {
            Console.Title = "Calculates the distance between two points";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please, enter the coordinate for the first point:");

            Console.Write("X = ");
            int firstX = int.Parse(Console.ReadLine());

            Console.Write("Y = ");
            int firstY = int.Parse(Console.ReadLine());

            Console.Write("Z = ");
            int firstZ = int.Parse(Console.ReadLine());

            Point3D firstPoint = new Point3D() { X = firstX, Y = firstY, Z = firstZ };

            Console.WriteLine("\nPlease, enter the coordinate for the second point:");

            Console.Write("X = ");
            int secondX = int.Parse(Console.ReadLine());

            Console.Write("Y = ");
            int secondY = int.Parse(Console.ReadLine());

            Console.Write("Z = ");
            int secondZ = int.Parse(Console.ReadLine());

            Point3D secondPoint = new Point3D() { X = secondX, Y = secondY, Z = secondZ };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDistance between them = {0:F2}", Distance.CalculateDistanceBetweenTwoPoints(firstPoint, secondPoint));

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(new string('-', Console.WindowWidth));
            System.Threading.Thread.Sleep(2000);

            try
            {
                // Save path
                Path path = new Path();
                path.Add(1, 2, 3);
                path.Add(2, 3, 4);
                path.Add(3, 4, 5);
                PathStorage.SavePath(path);

                // Load paths
                List<Path> paths = PathStorage.LoadPaths();

                for (int index = 0; index < paths.Count - 1; index++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Path [{0}]:", index);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    for (int point = 0; point < paths[index].PathPoints.Count; point++)
                    {
                        Console.WriteLine("Point [{0}, {1}, {2}]", paths[index].PathPoints[point].X, paths[index].PathPoints[point].Y, paths[index].PathPoints[point].Z);
                    }

                    Console.WriteLine();
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(fnfe.Message);
            }
        }
    }
}