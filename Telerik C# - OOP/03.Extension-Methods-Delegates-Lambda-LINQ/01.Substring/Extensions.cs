namespace _01.Substring
{
    using System;
    using System.Linq;
    using System.Text;

    /*
        Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder 
        and has the same functionality as Substring in the class String.
    */

    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder str, int index, int length = 0)
        {
            StringBuilder newString = new StringBuilder();
            int stopPoint;

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("StartIndex cannot be less than zero.");
            }
            else if (index >= str.Length)
            {
                throw new ArgumentOutOfRangeException("StartIndex cannot be larger than length of string.");
            }
            else if (length < 0)
            {
                throw new ArgumentOutOfRangeException("Length cannot be less than zero.");
            }
            else
            {
                if (length == 0)
                {
                    stopPoint = str.Length;
                }
                else
                {
                    stopPoint = index + length;

                    if (stopPoint > str.Length)
                    {
                        throw new ArgumentOutOfRangeException("Index and length must refer to a location within the string.");
                    }
                }

                for (int i = index; i < stopPoint; i++)
                {
                    newString.Append(str[i]);
                }
            }

            return newString;
        }
    }

    class ExtensionsTest
    {

        public static void Main()
        {
            Console.Title = "StringBuilder substring test";

                                          //Indexes 012345678901234
            StringBuilder test = new StringBuilder("Test message!!!");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("The whole message -> ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(test);    // The whole message
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nSubstring from index 5 with length 7 -> ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(test.Substring(5, 7)); // This will print message
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Substring from index 0 with length 4 -> ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(test.Substring(0, 4)); // Thisi will print Test
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Substring from index 5 without length -> ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(test.Substring(5));    // This will print message!!!

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}