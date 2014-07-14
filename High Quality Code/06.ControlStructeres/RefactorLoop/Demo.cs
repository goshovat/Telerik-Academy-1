namespace RefactorLoop
{
    using System;

    public class Demo
    {
        public static void Main(string[] args)
        {
            int[] array = new int[100];

            for (int index = 0; index < array.Length; index++)
            {
                array[index] = index;
            }

            int expectedValue = 30;
            int valueToBeFound = expectedValue - 1;

            for (int index = 0; index < array.Length; index++)
            {
                if (index % 10 == 0)
                {
                    if (array[index] == expectedValue)
                    {
                        valueToBeFound = 666;
                    }
                }

                Console.WriteLine(array[index]);
            }

            Console.WriteLine();

            if (valueToBeFound == 666)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
