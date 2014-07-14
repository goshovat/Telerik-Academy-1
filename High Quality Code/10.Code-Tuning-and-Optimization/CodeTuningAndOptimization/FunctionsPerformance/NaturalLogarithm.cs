namespace FunctionsPerformance
{
    using System;

    internal class NaturalLogarithm : Function
    {
        public override void MeasureFloat()
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (float i = 0; i < 1000000; i++)
            {
                Math.Log(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Natural logarithm float performance time: {0}", stopwatch.Elapsed);
        }

        public override void MeasureDouble()
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (double i = 0; i < 1000000; i++)
            {
                Math.Log(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Natural logarithm double performance time: {0}", stopwatch.Elapsed);
        }

        public override void MeasureDecimal()
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (decimal i = 0; i < 1000000; i++)
            {
                Math.Log((double)i);
            }

            stopwatch.Stop();
            Console.WriteLine("Natural logarithm decimal performance time: {0}", stopwatch.Elapsed);
        }
    }
}
