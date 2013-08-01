using System;

    /*
         Find online more information about ASCII (American Standard Code for Information Interchange) 
         and write a program that prints the entire ASCII table of characters on the console.
    */

class PrintASCIITable
{
    static void Main(string[] args)
    {
        char item;
        for (byte itemNumber = 0; itemNumber <= 127; itemNumber++)
        {
            item = (char)itemNumber;
            Console.WriteLine("Character decimal number - {0}, character - {1}", itemNumber, item);
        }
    }
}