using System;

class FirTree
{
    static void Main(string[] args)
    {
        byte rows = byte.Parse(Console.ReadLine());

        string lastRow = new string('.', rows - 2) + "*" + new string('.', rows - 2);

        byte pointer = 2;
        byte starsNumber = 1;

        for (byte i = 1; i < rows; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', rows - pointer), new string('*', starsNumber));
            pointer++;
            starsNumber += 2;
        }
        Console.WriteLine(lastRow);
    
    }
}