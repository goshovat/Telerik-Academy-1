namespace Matix
{
    using System;

    public class RotatingWalk
    {
        static Direction GetNextDirection(Direction currentDirection)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < dirX.Length; i++)
            {
                if (dirX[i] == currentDirection.DirX && dirY[i] == currentDirection.DirY)
                {
                    Direction nextDirection = new Direction()
                    {
                        DirX = dirX[(i + 1) % dirX.Length],
                        DirY = dirY[(i + 1) % dirX.Length]
                    };
                    return nextDirection;
                }
            }

            throw new InvalidOperationException(
                String.Format(
                    "Could not find the next direction: dirX={0}, dirY={1}",
                    currentDirection.DirX,
                    currentDirection.DirY));
        }

        static bool CheckDirections(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                    dirX[i] = 0;
                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                    dirY[i] = 0;
            }
            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                    return true;
            }
            return false;
        }

        static Point GetFirstEmptyCell(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        Point emptyCell = new Point() { Row = row, Col = col };
                        return emptyCell;
                    }
                }
            }

            return null;
        }

        public static int[,] GenerateRotatingWalkMatrix(int n)
        {
            if (n < 1 || n > 100)
            {
                throw new ArgumentOutOfRangeException(
                    "The size of the matrix should be positive integer number " +
                    "in the range [1..100]!");
            }

            int[,] outputMatrix = new int[n, n];

            int number = 1;
            Point currentCell = new Point() { Row = 0, Col = 0 };
            Direction currentDir = new Direction() { DirX = 1, DirY = 1 };
            FillMatrixWhilePossible(n, outputMatrix, ref number, currentCell, ref currentDir);

            number++;

            currentCell = GetFirstEmptyCell(outputMatrix);
            if (currentCell != null)
            {
                currentDir.DirX = 1;
                currentDir.DirY = 1;
                FillMatrixWhilePossible(n, outputMatrix, ref number, currentCell, ref currentDir);
            }

            return outputMatrix;
        }

        private static void FillMatrixWhilePossible(int n, int[,] outputMatrix, ref int number, Point currentCell, ref Direction currentDir)
        {
            while (true) //malko e kofti tova uslovie, no break-a raboti 100% :)
            {
                outputMatrix[currentCell.Row, currentCell.Col] = number;
                if (!CheckDirections(outputMatrix, currentCell.Row, currentCell.Col))
                {
                    break;      // prekusvame ako sme se zadunili
                }
                while (IsNextCellAvailable(n, outputMatrix, currentCell, currentDir))
                {
                    currentDir = GetNextDirection(currentDir);
                }
                currentCell.Row += currentDir.DirX;
                currentCell.Col += currentDir.DirY;
                number++;
            }
        }

        private static bool IsNextCellAvailable(
            int n, int[,] matrix, Point cell, Direction dir)
        {
            return cell.Row + dir.DirX >= n || cell.Row + dir.DirX < 0 ||
                cell.Col + dir.DirY >= n || cell.Col + dir.DirY < 0 ||
                matrix[cell.Row + dir.DirX, cell.Col + dir.DirY] != 0;
        }

        public static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }
            int[,] matrix = GenerateRotatingWalkMatrix(n);
            PrintMatrix(n, matrix);
        }

        private static void PrintMatrix(int n, int[,] output)
        {
            for (int row = 0; row < n; row++)
            {
                Console.Write("{ ");
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0,6},", output[row, col]);
                }
                Console.WriteLine(" },");
            }
        }
    }
}
