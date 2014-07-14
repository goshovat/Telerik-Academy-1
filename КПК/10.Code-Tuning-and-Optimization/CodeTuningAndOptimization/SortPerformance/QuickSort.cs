namespace SortPerformance
{
    using System;

    internal class QuickSort : SortAlgorithm
    {        
        public override void MeasureInt(int[] array)
        {
            stopwatch.Reset();
            stopwatch.Start();
            
            this.MeasureInt(array, 0, array.Length - 1);
            
            stopwatch.Stop();

            Console.WriteLine("Quick sort int performance time: {0}", stopwatch.Elapsed);
        }

        public override void MeasureDouble(double[] array)
        {
            stopwatch.Reset();
            stopwatch.Start();
            
            this.MeasureDouble(array, 0, array.Length - 1);
            
            stopwatch.Stop();

            Console.WriteLine("Quick sort double performance time: {0}", stopwatch.Elapsed);
        }

        public override void MeasureString(string[] array)
        {
            stopwatch.Reset();
            stopwatch.Start();

            this.MeasureString(array, 0, array.Length - 1);

            stopwatch.Stop();

            Console.WriteLine("Quick sort string performance time: {0}", stopwatch.Elapsed);
        }

        private void MeasureString(string[] array, int left, int right)
        {
            int i = left, j = right;
            string temp = array[(left + right) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(temp) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(temp) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    string tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                this.MeasureString(array, left, j);
            }

            if (i < right)
            {
                this.MeasureString(array, i, right);
            }
        }

        private void Swap(int[] array, int left, int right)
        {
            int temp = array[right];
            array[right] = array[left];
            array[left] = temp;
        }

        private void MeasureInt(int[] array, int left, int right)
        {
            int currentLeftHolder = left;
            int currentRightHolder = right;
            int pivot = left;
            left++;

            while (right >= left)
            {
                if (array[left] >= array[pivot] &&
                    array[right] < array[pivot])
                {
                    this.Swap(array, left, right);
                }
                else if (array[left] >= array[pivot])
                {
                    right--;
                }
                else if (array[right] < array[pivot])
                {
                    left++;
                }
                else
                {
                    right--;
                    left++;
                }
            }

            this.Swap(array, pivot, right);
            pivot = right;

            if (pivot > currentLeftHolder)
            {
                this.MeasureInt(array, currentLeftHolder, pivot);
            }

            if (currentRightHolder > pivot + 1)
            {
                this.MeasureInt(array, pivot + 1, currentRightHolder);
            }
        }

        private void SwapDouble(double[] array, int left, int right)
        {
            double temp = array[right];
            array[right] = array[left];
            array[left] = temp;
        }

        private void MeasureDouble(double[] array, int left, int right)
        {
            int currentLeftHolder = left;
            int currentRightHolder = right;
            int pivot = left;
            left++;

            while (right >= left)
            {
                if (array[left] >= array[pivot] &&
                    array[right] < array[pivot])
                {
                    this.SwapDouble(array, left, right);
                }
                else if (array[left] >= array[pivot])
                {
                    right--;
                }
                else if (array[right] < array[pivot])
                {
                    left++;
                }
                else
                {
                    right--;
                    left++;
                }
            }

            this.SwapDouble(array, pivot, right);
            pivot = right;

            if (pivot > currentLeftHolder)
            {
                this.MeasureDouble(array, currentLeftHolder, pivot);
            }

            if (currentRightHolder > pivot + 1)
            {
                this.MeasureDouble(array, pivot + 1, currentRightHolder);
            }
        }
    }
}
