namespace OperatorsPerformance
{
    using System;

    internal class PrefixIteration : Operation
    {
        public override void MeasureInt()
        {
            this.ClearResult();
            stopwatch.Reset();
            this.stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                ++this.resultInt;
            }

            this.stopwatch.Stop();
            Console.WriteLine("Postfix increment integer performance time: {0}", this.stopwatch.Elapsed);
        }

        public override void MeasureLong()
        {
            this.ClearResult();
            stopwatch.Reset();
            this.stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                ++this.resultLong;
            }

            this.stopwatch.Stop();
            Console.WriteLine("Postfix increment long performance time: {0}", this.stopwatch.Elapsed);
        }

        public override void MeasureFloat()
        {
            this.ClearResult();
            stopwatch.Reset();
            this.stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                ++this.resultFloat;
            }

            this.stopwatch.Stop();
            Console.WriteLine("Postfix increment float performance time: {0}", this.stopwatch.Elapsed);
        }

        public override void MeasureDouble()
        {
            this.ClearResult();
            stopwatch.Reset();
            this.stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                ++this.resultDouble;
            }

            this.stopwatch.Stop();
            Console.WriteLine("Postfix increment double performance time: {0}", this.stopwatch.Elapsed);
        }

        public override void MeasureDecimal()
        {
            this.ClearResult();
            stopwatch.Reset();
            this.stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                ++this.resultDecimal;
            }

            this.stopwatch.Stop();
            Console.WriteLine("Postfix increment decimal performance time: {0}", this.stopwatch.Elapsed);
        }
    }
}
