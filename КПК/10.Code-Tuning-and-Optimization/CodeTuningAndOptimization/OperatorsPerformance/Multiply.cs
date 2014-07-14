namespace OperatorsPerformance
{
    using System;

    internal class Multiply : Operation
    {
        public override void MeasureInt()
        {
            this.ClearResult();
            stopwatch.Reset();
            this.stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                this.resultInt = this.firstInt * this.secondInt;
            }

            this.stopwatch.Stop();
            Console.WriteLine("Multiply integers performance time: {0}", this.stopwatch.Elapsed);
        }

        public override void MeasureLong()
        {
            this.ClearResult();
            stopwatch.Reset();
            this.stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                this.resultLong = this.firstLong * this.secondLong;
            }

            this.stopwatch.Stop();
            Console.WriteLine("Multiply longs performance time: {0}", this.stopwatch.Elapsed);
        }

        public override void MeasureFloat()
        {
            this.ClearResult();
            stopwatch.Reset();
            this.stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                this.resultFloat = this.firstFloat * this.secondFloat;
            }

            this.stopwatch.Stop();
            Console.WriteLine("Multiply floats performance time: {0}", this.stopwatch.Elapsed);
        }

        public override void MeasureDouble()
        {
            this.ClearResult();
            stopwatch.Reset();
            this.stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                this.resultDouble = this.firstDouble * this.secondDouble;
            }

            this.stopwatch.Stop();
            Console.WriteLine("Multiply doubles performance time: {0}", this.stopwatch.Elapsed);
        }

        public override void MeasureDecimal()
        {
            this.ClearResult();
            stopwatch.Reset();
            this.stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                this.resultDecimal = this.firstDecimal * this.secondDecimal;
            }

            this.stopwatch.Stop();
            Console.WriteLine("Multiply decimals performance time: {0}", this.stopwatch.Elapsed);
        }
    }
}
