namespace PrintStatistics
{
    using System;

    public class Demo
    {
        public static void Main(string[] args)
        {
            double[] numbers = { 1.2, -5.6, 5.67, 424.2 };
            Statistic statistic = new Statistic(numbers);

            Console.WriteLine("Max value: {0}", statistic.GetMaxValue());
            Console.WriteLine("Min value: {0}", statistic.GetMinValue());
            Console.WriteLine("Average value: {0}", statistic.GetAverageValue());
        }
    }
}
