namespace SortPerformance
{
    using System;

    internal class InsertionSort : SortAlgorithm
    {
        public override void MeasureInt(int[] array)
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < array.Length; i++)
            {
                for (int k = i; k > 0 && array[k] < array[k - 1]; k--)
                {
                    int t = array[k];
                    array[k] = array[k - 1];
                    array[k - 1] = t;
                }
            }

            stopwatch.Stop();

            Console.WriteLine("Insertion sort int performance time: {0}", stopwatch.Elapsed);
        }

        public override void MeasureDouble(double[] array)
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < array.Length; i++)
            {
                for (int k = i; k > 0 && array[k] < array[k - 1]; k--)
                {
                    double t = array[k];
                    array[k] = array[k - 1];
                    array[k - 1] = t;
                }
            }

            stopwatch.Stop();

            Console.WriteLine("Insertion sort double performance time: {0}", stopwatch.Elapsed);
        }

        public override void MeasureString(string[] array)
        {
            stopwatch.Reset();
            stopwatch.Start();
            int i, j;

            for (i = 1; i < array.Length; i++)
            {
                string value = array[i];
                j = i - 1;
                
                while ((j >= 0) && (array[j].CompareTo(value) > 0))
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = value;
            }

            stopwatch.Stop();

            Console.WriteLine("Insertion sort string performance time: {0}", stopwatch.Elapsed);
        }
    }
}
