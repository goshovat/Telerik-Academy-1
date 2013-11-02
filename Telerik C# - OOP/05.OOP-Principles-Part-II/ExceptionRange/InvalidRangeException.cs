namespace ExceptionRange
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
     where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private readonly T valueOutOfRange;
        private readonly T start;
        private readonly T end;

        public T ValueOutOfRange1
        {
            get
            {
                return this.valueOutOfRange;
            }
        }

        public T Start
        {
            get
            {
                return start;
            }
        }

        public T End
        {
            get
            {
                return end;
            }
        }


        public InvalidRangeException(T start, T end, T valueOutOfRange)
            : this(null, start, end, null, valueOutOfRange)
        {
        }

        public InvalidRangeException(string message, T start, T end, Exception innerException, T valueOutOfRange)
            : base(message, innerException)
        {
            this.start = start;
            this.end = end;
            this.valueOutOfRange = valueOutOfRange;

        }

        public InvalidRangeException(string message, T start, T end, T valueOutOfRange)
            : this(message, start, end, null, valueOutOfRange)
        {
        }
    }
}