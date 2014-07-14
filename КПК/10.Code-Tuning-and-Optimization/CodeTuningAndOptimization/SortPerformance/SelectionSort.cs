namespace SortPerformance
{
    using System;

    internal class SelectionSort : SortAlgorithm
    {
        public override void MeasureInt(int[] array)
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < array.Length; i++)
            {
                int low = i;
                for (int k = i + 1; k < array.Length; k++)
                { 
                    if (array[k] < array[low])
                    { 
                        low = k;
                    }
                }

                int t = array[i];
                array[i] = array[low];
                array[low] = t;
            }

            stopwatch.Stop();

            Console.WriteLine("Selection sort int performance time: {0}", stopwatch.Elapsed); 
        }

        public override void MeasureDouble(double[] array)
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < array.Length; i++)
            {
                int low = i;
                for (int k = i + 1; k < array.Length; k++)
                {
                    if (array[k] < array[low])
                    {
                        low = k;
                    }
                }

                double t = array[i];
                array[i] = array[low];
                array[low] = t;
            }

            stopwatch.Stop();

            Console.WriteLine("Selection sort double performance time: {0}", stopwatch.Elapsed);
        }

        public override void MeasureString(string[] array)
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < array.Length; i++)
            {
                int low = i;
                for (int k = i + 1; k < array.Length; k++)
                {
                    if (array[k].CompareTo(array[low]) > 0)
                    {
                        low = k;
                    }
                }

                string t = array[i];
                array[i] = array[low];
                array[low] = t;
            }

            stopwatch.Stop();

            Console.WriteLine("Selection sort string performance time: {0}", stopwatch.Elapsed);
        }
    }
}
