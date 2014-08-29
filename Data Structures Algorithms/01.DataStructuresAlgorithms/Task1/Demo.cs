namespace Task1
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
        /// <param name="arr"></param>
        /// <returns></returns>
        private static long Compute(int[] arr)
        {
            long count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int start = 0, end = arr.Length - 1;
                while (start < end)
                {
                    if (arr[start] < arr[end])
                    {
                        start++; count++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }

            return count;
        }

        private static void TestComputeMethod(int arraySize)
        {
            Stopwatch stopwatch = new Stopwatch();
            ArrayGenerator generator = new ArrayGenerator();

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Method Compute runs in quadratic time O(n*n)");
            Console.WriteLine("Size of the array = {0}", arraySize);

            int[] generatedArray = generator.GenerateArray(arraySize);

            stopwatch.Start();
            long result = Compute(generatedArray);
            stopwatch.Stop();

            Console.WriteLine("Time: {0}", stopwatch.Elapsed);
            Console.WriteLine("Result = {0}", result);
            Console.WriteLine("------------------------------------\n");
        }

        public static void Main(string[] args)
        {
            TestComputeMethod(10);
            TestComputeMethod(50);
            TestComputeMethod(100);
            TestComputeMethod(500);
            TestComputeMethod(1000);
            TestComputeMethod(5000);
            TestComputeMethod(10000);
            TestComputeMethod(20000);
        }
    }
}
