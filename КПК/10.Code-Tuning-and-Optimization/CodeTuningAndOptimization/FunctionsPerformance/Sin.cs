namespace FunctionsPerformance
{
    using System;

    internal class Sin : Function
    {
        public override void MeasureFloat()
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (float i = 0; i < 1000000; i++)
            {
                Math.Sin(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Sinus float performance time: {0}", stopwatch.Elapsed);
        }

        public override void MeasureDouble()
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (double i = 0; i < 1000000; i++)
            {
                Math.Sin(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Sinus double performance time: {0}", stopwatch.Elapsed);
        }

        public override void MeasureDecimal()
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (decimal i = 0; i < 1000000; i++)
            {
                Math.Sin((double)i);
            }

            stopwatch.Stop();
            Console.WriteLine("Sinus decimal performance time: {0}", stopwatch.Elapsed);
        }
    }
}
