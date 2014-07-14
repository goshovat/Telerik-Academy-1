namespace OperatorsPerformance
{
    using System;

    public class Demo
    {
        public static void Main(string[] args)
        {
            Operation[] operations = new Operation[] 
            { 
                new Add(), 
                new Subtract(), 
                new PostfixIteration(), 
                new PrefixIteration(), 
                new Multiply(), 
                new Divide() 
            };

            foreach (var operation in operations)
            {
                operation.MeasureInt();
                operation.MeasureLong();
                operation.MeasureFloat();
                operation.MeasureDouble();
                operation.MeasureDecimal();

                Console.WriteLine();
            }
        }
    }
}
