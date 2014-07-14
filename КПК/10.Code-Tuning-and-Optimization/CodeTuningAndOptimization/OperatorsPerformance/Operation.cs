namespace OperatorsPerformance
{
    using System;
    using System.Diagnostics;

    internal abstract class Operation
    {
        protected readonly Stopwatch stopwatch = new Stopwatch();

        protected int firstInt = 30000;
        protected int secondInt = 50000;
        protected long firstLong = 30000L;
        protected long secondLong = 50000L;
        protected float firstFloat = 30000.0f;
        protected float secondFloat = 50000.0f;
        protected double firstDouble = 30000.0d;
        protected double secondDouble = 50000.0d;
        protected decimal firstDecimal = 30000.0m;
        protected decimal secondDecimal = 50000.0m;

        protected int resultInt = 0;
        protected long resultLong = 0;
        protected double resultDouble = 0;
        protected float resultFloat = 0;
        protected decimal resultDecimal = 0;

        public abstract void MeasureInt();

        public abstract void MeasureLong();

        public abstract void MeasureFloat();

        public abstract void MeasureDouble();

        public abstract void MeasureDecimal();

        protected void ClearResult()
        {
            this.resultInt = 0;
            this.resultLong = 0;
            this.resultDouble = 0;
            this.resultFloat = 0;
            this.resultDecimal = 0;
        }
    }
}
