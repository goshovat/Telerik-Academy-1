namespace FunctionsPerformance
{
    using System;

    internal class Demo
    {
        internal static void Main(string[] args)
        {
            Function[] functions = new Function[] 
            { 
                new Sin(), new NaturalLogarithm(), new SquareRoot()
            };

            foreach (var function in functions)
            {
                function.MeasureFloat();
                function.MeasureDouble();
                function.MeasureDecimal();

                Console.WriteLine();
            }
        }
    }
}
