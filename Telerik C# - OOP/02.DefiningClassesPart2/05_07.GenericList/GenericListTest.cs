namespace _05_07.GenericList
{
    using System;

    class GenericListTest
    {
        static void Main(string[] args)
        {
            GenericList<int> gl = new GenericList<int>(4); // Set the capacity of the list

            // Add some element
            gl.Add(1);
            gl.Add(2);
            gl.Add(3);
            gl.Add(4);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(gl); // Show the elements
            Console.WriteLine("Count = {0}", gl.Count); // Show the number of added elements
            Console.WriteLine("Capacity = {0}\n", gl.Capacity); // Show the capacity

            gl.InsertAt(0, -1); // Insert element at given position
            gl.InsertAt(3, 256);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(gl);
            Console.WriteLine("Count = {0}", gl.Count);
            Console.WriteLine("Capacity = {0}\n", gl.Capacity);

            // Add some elements
            gl.Add(1);
            gl.Add(2);
            gl.Add(3);
            gl.Add(4);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(gl);
            Console.WriteLine("Count = {0}", gl.Count);
            Console.WriteLine("Capacity = {0}\n", gl.Capacity);

            // Find element with value 1 starting searching from given position
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Index of element with value 1, starting from index 0 is № = {0}", gl.Find(1));
            Console.WriteLine("Index of element with value 1, starting from index 4 is № = {0}", gl.Find(1, 4));

            Console.WriteLine();

            // Find min and max 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("List's min value = {0}", gl.Min());
            Console.WriteLine("List's max value = {0}", gl.Max());

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}