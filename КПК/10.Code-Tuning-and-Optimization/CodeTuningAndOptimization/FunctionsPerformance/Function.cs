namespace FunctionsPerformance
{
    using System;
    using System.Diagnostics;

    internal abstract class Function
    {
        protected readonly Stopwatch stopwatch = new Stopwatch();

        public abstract void MeasureFloat();

        public abstract void MeasureDouble();

        public abstract void MeasureDecimal();
    }
}
