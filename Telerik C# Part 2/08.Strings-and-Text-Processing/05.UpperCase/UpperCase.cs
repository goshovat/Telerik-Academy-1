using System;
using System.Text;

/*
    You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> 
    and </upcase> to uppercase. The tags cannot be nested. Example:
    We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
	The expected result:
    We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
*/

class UpperCase
{
    static void Main(string[] args)
    {
        Console.Title = "Change words to upper case";

        Console.ForegroundColor = ConsoleColor.Green;
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        Console.WriteLine("The text is ---> {0}", text);

        StringBuilder changedText = new StringBuilder();

        int indexStart = text.IndexOf("<upcase>");
        int indexFinish = text.IndexOf("</upcase>");

        changedText.Append(text.Substring(0, indexStart));  // Append the text before the first <upcase>
       
        while (indexStart != -1)
        {
            changedText.Append(text.Substring(indexStart + 8, indexFinish - indexStart - 8).ToUpper()); // Change the words surrounded by the tags
            indexStart = text.IndexOf("<upcase>", indexFinish);
            if (indexStart != -1)
            {
                changedText.Append(text.Substring(indexFinish + 9, indexStart - indexFinish - 9)); // Append the text after </upcase> to <upcase>
                indexFinish = text.IndexOf("</upcase>", indexFinish + 1);
            }
        }

        changedText.Append(text.Substring(indexFinish + 9, text.Length - indexFinish - 9)); // Append the text after the last </upcase>
        
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(changedText);

        Console.WriteLine();
        Console.ResetColor();
    }
}