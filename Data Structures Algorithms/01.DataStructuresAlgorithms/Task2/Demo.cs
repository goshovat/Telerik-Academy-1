namespace Task2
{
    using Generator;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Demo
    {
        /// <summary>
        /// Best case : All elements are odd and the second loop are not going to be executed, so linear time - О(n).
        /// Average case : Half ot the elements are odd and the second loop will be executed m/2 times, so quadratic time -  О(n*m).
        /// Worst case : All elements are even and the second loop loop will be executed m/2 times, so quadratic time - O(n*m).
        /// </summary>
        /// <param name="arraySize"></param>
        private static long CalcCount(int[,] matrix)
        {
            long count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, 0] % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] > 0)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private static void TestComputeMethod(int rows, int cols)
        {
            Stopwatch stopwatch = new Stopwatch();
            ArrayGenerator generator = new ArrayGenerator();

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Best case: method CalcCount runs in linear time O(n)");
            Console.WriteLine("Average case: method CalcCount runs in quadratic time O(n*m)");
            Console.WriteLine("Worst case: method CalcCount runs in quadratic time O(n*m)");
            Console.WriteLine("Size of the array = [{0}, {1}]", rows, cols);

            int[,] generatedArray = generator.GenerateTwoDimensionalArray(rows, cols);
           
            stopwatch.Start();
            long counterSmallArray = CalcCount(generatedArray);
            stopwatch.Stop();

            Console.WriteLine("Time: {0}", stopwatch.Elapsed);
            Console.WriteLine("Result = {0}", counterSmallArray);
            Console.WriteLine("------------------------------------------------------------\n");
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
            // make the program wait for about 8 seconds
            TestComputeMethod(20000, 10000);
        }
    }
}
