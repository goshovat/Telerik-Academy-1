namespace _14.Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Labyrinth
    {
        public static void Main(string[] args)
        {
            var matrix = new string[,]
            {
                {"0", "0", "0", "x", "0", "x"},
                {"0", "x", "0", "x", "0", "x"},
                {"0", "0", "x", "0", "x", "0"},
                {"0", "x", "0", "0", "0", "0"},
                {"0", "0", "0", "x", "0", "x"},
                {"0", "0", "0", "x", "x", "0"},
                {"0", "0", "0", "x", "0", "x"}
            };

            FindPathToAnyCell(matrix, 1, 2);
            PrintMatrix(matrix);
        }

        private static void FindPathToAnyCell(string[,] matrix, int startPositionX, int startPositionY)
        {
            var queue = new Queue<Position>();

            queue.Enqueue(new Position(startPositionX, startPositionY, 0));
            matrix[startPositionY, startPositionX] = "*";

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                var right = top;
                var down = top;
                var left = top;

                top.Y -= 1;

                if (IsReachablePoint(matrix, top.X, top.Y))
                {
                    top.Number++;
                    matrix[top.Y, top.X] = top.Number.ToString();
                    queue.Enqueue(top);
                }

                right.X += 1;

                if (IsReachablePoint(matrix, right.X, right.Y))
                {
                    right.Number++;
                    matrix[right.Y, right.X] = right.Number.ToString();
                    queue.Enqueue(right);
                }

                down.Y += 1;

                if (IsReachablePoint(matrix, down.X, down.Y))
                {
                    down.Number++;
                    matrix[down.Y, down.X] = down.Number.ToString();
                    queue.Enqueue(down);
                }

                left.X -= 1;

                if (IsReachablePoint(matrix, left.X, left.Y))
                {
                    left.Number++;
                    matrix[left.Y, left.X] = left.Number.ToString();
                    queue.Enqueue(left);
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    if (matrix[row, col] == "0")
                    {
                        matrix[row, col] = "u";
                    }

                    Console.Write(matrix[row, col] + "  ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsReachablePoint(string[,] matrix, int x, int y)
        {
            var checkX = 0 <= x && x <= (matrix.GetLength(1) - 1);
            var checkY = 0 <= y & y <= (matrix.GetLength(0) - 1);

            if (checkX && checkY)
            {
                var value = matrix[y, x];

                if (value == "0")
                {
                    return true;
                }
            }

            return false;
        }

        internal struct Position
        {
            internal int X;

            internal int Y;

            internal int Number;

            internal Position(int x, int y, int number)
            {
                this.X = x;
                this.Y = y;
                this.Number = number;
            }
        }
    }
}
