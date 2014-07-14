namespace SortPerformance
{
    using System;
    using System.Diagnostics;

    internal abstract class SortAlgorithm
    {
        protected readonly Stopwatch stopwatch = new Stopwatch();

        public abstract void MeasureInt(int[] array);

        public abstract void MeasureDouble(double[] array);

        public abstract void MeasureString(string[] array);
    }
}
