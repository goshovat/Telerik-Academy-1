namespace _08_10.Matrix
{
    using System;
    using System.Threading;

    public class MatrixTest
    {
        static void Main(string[] args)
        {
            Console.Title = "Matrix";

            Console.ForegroundColor = ConsoleColor.Green;

            int firstRows = 0;

            do
            {
                Console.Write("How many rows does the first matrix have : ");
                firstRows = int.Parse(Console.ReadLine());
            } while (firstRows < 1);

            int firstCols = 0;

            do
            {
                Console.Write("How many cols does the first matrix have : ");
                firstCols = int.Parse(Console.ReadLine());
            } while (firstCols < 1);

            Matrix<int> firstMatrix = new Matrix<int>(firstRows, firstCols);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nEnter the elements for the first matrix:");
            Console.Write(new string('-', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int row = 0; row < firstRows; row++)
            {
                for (int col = 0; col < firstCols; col++)
                {
                    Console.Write("Element[{0}, {1}] = ", row, col);
                    firstMatrix[row, col] = int.Parse(Console.ReadLine());
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(new string('-', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Green;

            int secondRows = 0;

            do
            {
                Console.Write("\nHow many rows does the second matrix have : ");
                secondRows = int.Parse(Console.ReadLine());
            } while (secondRows < 1);

            int secondCols = 0;

            do
            {
                Console.Write("How many cols does the second matrix have : ");
                secondCols = int.Parse(Console.ReadLine());
            } while (secondCols < 1);

            Matrix<int> secondMatrix = new Matrix<int>(secondRows, secondCols);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nEnter the elements of the second array:");
            Console.Write(new string('-', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int row = 0; row < secondRows; row++)
            {
                for (int col = 0; col < secondCols; col++)
                {
                    Console.Write("Element[{0}, {1}] = ", row, col);
                    secondMatrix[row, col] = int.Parse(Console.ReadLine());
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(new string('-', Console.WindowWidth));

            // Print the first matrix
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThe first matrix:");
            Console.Write(new string('-', Console.WindowWidth));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(firstMatrix);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string('-', Console.WindowWidth));

            Thread.Sleep(2000);

            // Print the second matrix
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThe second matrix:");
            Console.Write(new string('-', Console.WindowWidth));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(secondMatrix);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string('-', Console.WindowWidth));

            Thread.Sleep(2000);

            // Print the matrix after adding the matrices
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAdding the matrices");
            Console.Write(new string('-', Console.WindowWidth));
            Console.ForegroundColor = ConsoleColor.Yellow;

            try
            {
                Console.Write(firstMatrix + secondMatrix);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(new string('-', Console.WindowWidth));

            Thread.Sleep(2000);

            // Print the matrix after substracting the matrices
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nSubtracting the matrices");
            Console.Write(new string('-', Console.WindowWidth));
            Console.ForegroundColor = ConsoleColor.Yellow;

            try
            {
                Console.Write(firstMatrix - secondMatrix);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(new string('-', Console.WindowWidth));

            Thread.Sleep(2000);

            // Print the matrix after multiplying the matrices
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nMultiplying the matrices");
            Console.Write(new string('-', Console.WindowWidth));
            Console.ForegroundColor = ConsoleColor.Yellow;

            try
            {
                Console.Write(firstMatrix * secondMatrix);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(new string('-', Console.WindowWidth));

            Console.WriteLine("\n");
            Console.ResetColor();
        }
      
    }
}
