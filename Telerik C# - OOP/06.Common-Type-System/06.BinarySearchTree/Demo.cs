namespace _06.BinarySearchTree
{
    using System;
    using System.Text;

    public class Demo
    {
        static void Main(string[] args)
        {
            Console.Title = "Binary search tree";

            // Initialize a BST which will contain integers
            BinarySearchTree<int> intTree = new BinarySearchTree<int>();

            Random randomGenerathor = new Random(DateTime.Now.Millisecond);
            StringBuilder trace = new StringBuilder();

            // Insert 10 random integers into the intTree
            for (int i = 0; i < 10; i++)
            {
                int randomInt = randomGenerathor.Next(1, 500);
                intTree.Insert(randomInt);
                trace.Append(randomInt);
                trace.Append(" ");
            }

            // Clone the intTree
            dynamic newTree = intTree.Clone();
            StringBuilder newTrace = new StringBuilder(trace.ToString());

            // Insert 3 new random integers into the newTree
            for (int i = 0; i < 3; i++)
            {
                int randomInt = randomGenerathor.Next(1, 500);
                newTree.Insert(randomInt); // May throw Argument exception if the element is already exist in the tree
                newTrace.Append(randomInt);
                newTrace.Append(" ");
            }

            // Find the largest value in the intTree
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Max element: {0}", intTree.FindMax());

            // Find the largest value in the newTree
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nMax element: {0}", newTree.FindMax());

            // Find the smallest value in the intTree
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nMin element: {0}", intTree.FindMin());

            // Find the smallest value in the newTree
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nMin element: {0}", newTree.FindMin());

            // Find the hash code of the intTree
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nHashcode: {0}", intTree.GetHashCode());

            // Find the hash code of the newTree
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nHashcode: {0}", newTree.GetHashCode());

            // Find the root of the intTree
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nRoot: {0}", intTree.Root.Element);

            // Find the root of the newTree
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nRoot: {0}", newTree.Root.Element);

            // The order in which the elements were added to the intTree
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nTrace: {0}", trace);

            // The order in which the elements were added to the newTree
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nTrace: {0}", newTrace);

            // A textual representation of the intTree
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nFirst Tree: \n{0}", intTree);          

            // A textual representation of the newTree
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nSecond Tree: \n{0}", newTree);

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
