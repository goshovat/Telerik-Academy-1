namespace Task3
{
    using Generator;
    using System;
    using System.Diagnostics;

    public class Demo
    {
        /// <summary>
        /// In all cases the method runs in a quadratic time 0(n*m). Because the second loop will
        /// always be executed.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sum += matrix[row, col];
            }

            if (row + 1 < matrix.GetLength(0))
            {
                sum += CalcSum(matrix, row + 1);
            }

            return sum;
        }

        private static void TestComputeMethod(int rows, int cols)
        {
            Stopwatch stopwatch = new Stopwatch();
            ArrayGenerator generator = new ArrayGenerator();

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Method CalcSum runs in quadratic time O(n*m)");
            Console.WriteLine("Size of the array = [{0}, {1}]", rows, cols);

            int[,] generatedArray = generator.GenerateTwoDimensionalArray(rows, cols);

            stopwatch.Start();
            long counterSmallArray = CalcSum(generatedArray, 0);
            stopwatch.Stop();

            Console.WriteLine("Time: {0}", stopwatch.Elapsed);
            Console.WriteLine("Result = {0}", counterSmallArray);
            Console.WriteLine("--------------------------------------------\n");
        }

        public static void Main(string[] args)
        {
            TestComputeMethod(10, 10);
            TestComputeMethod(50, 10);
            TestComputeMethod(100, 200);
            TestComputeMethod(500, 1000);
            TestComputeMethod(1000, 5000);
            TestComputeMethod(10000, 5000);
            // The elapsed time is 2 seconds for the metodh CalcCount, but the method GenerateTwoDimensionalArray is slow and this
            // make the program wait for about 6 seconds
            TestComputeMethod(10000, 10000);
        }
    }
}
