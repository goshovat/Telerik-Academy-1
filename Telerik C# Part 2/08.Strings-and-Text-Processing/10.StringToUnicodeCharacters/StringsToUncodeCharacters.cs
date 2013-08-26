using System;

/*
    Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:
    Hi!    

    Expected output:
    \u0048\u0069\u0021
*/

class StringsToUncodeCharacters
{
    static void Main(string[] args)
    {
        Console.Title = "Convert string to unicode characters";

        Console.Write("Enter a string: ");
        string text = Console.ReadLine(); //"Hi!";
        char[] unicode = text.ToCharArray();


        Console.Write("The unicode characters of the word are: ");

        for (int i = 0; i < unicode.Length; i++)
        {
            string tmp = string.Format("{0:X}", text[i] | 0);
            tmp = "\\u" + new string('0', 4 - tmp.Length) + tmp;
            Console.Write(tmp);
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}
