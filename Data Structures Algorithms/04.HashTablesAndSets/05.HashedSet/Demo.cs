namespace _05.HashedSet
{
    using System;

    public class Demo
    {
        public static void Main(string[] args)
        {
            var hashedSet1 = new HashedSet<string>();

            for (int i = 0; i < 4; i++)
            {
                hashedSet1.Add("pesho" + i);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("First hashed set:");
            foreach (var item in hashedSet1)
            {
                 Console.WriteLine(item);
            }

            var hashedSet2 = new HashedSet<string>();

            for (int i = 2; i < 6; i++)
            {
                hashedSet2.Add("pesho" + i);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nSecond hashed set:");
            foreach (var item in hashedSet2)
            {
                Console.WriteLine(item);
            }


            var intersected = hashedSet1.Intersect(hashedSet2);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nIntersected:");
            foreach (var item in intersected)
            {
                Console.WriteLine(item);
            }

            var unioned = hashedSet1.Union(hashedSet2);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nUnioned:");
            foreach (var item in unioned)
            {
                Console.WriteLine(item);
            }
        }
    }
}
