using System;

    /*
        Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
        Use Windows Character Map to find the Unicode code of the © symbol. 
        Note: the © symbol may be displayed incorrectly.
    */

class PrintIsoscelesTriangle
{
    static void Main(string[] args)
    {
        //sample solution
        string symbol = "\u00A9";
        Console.WriteLine("  {0}  ", symbol);
        Console.WriteLine(" {0}{0}{0} ", symbol);
        Console.WriteLine("{0}{0}{0}{0}{0}", symbol);
        
        //Solution with option to enter the lengths of the equal sides
        Console.Write("\nEnter the lengths of the equal sides : ");
        int rows = int.Parse(Console.ReadLine());
        string emptySymbol = "";
        for (int i = 0; i < rows; i++)
        {
            emptySymbol = emptySymbol.Insert(0, " ");
        }
        
        for (int row = 0; row < rows; row++)
        {
            emptySymbol = emptySymbol.Remove(0, 1);
            Console.WriteLine("{0}{1}", emptySymbol, symbol);
            symbol = symbol.Insert(1, "\u00A9\u00A9");
        }
    }
}
