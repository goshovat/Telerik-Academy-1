namespace FunctionsPerformance
{
    using System;

    internal class SquareRoot : Function
    {
        public override void MeasureFloat()
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (float i = 0; i < 1000000; i++)
            {
                Math.Sqrt(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Square root float performance time: {0}", stopwatch.Elapsed);
        }

        public override void MeasureDouble()
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (double i = 0; i < 1000000; i++)
            {
                Math.Sqrt(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Square root double performance time: {0}", stopwatch.Elapsed);
        }

        public override void MeasureDecimal()
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (decimal i = 0; i < 1000000; i++)
            {
                Math.Sqrt((double)i);
            }

            stopwatch.Stop();
            Console.WriteLine("Square root decimal performance time: {0}", stopwatch.Elapsed);
        }
    }
}
