using System;

/*
    Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 -> true.
*/

class CheckIfThirdDigitIs7
{
    static void Main(string[] args)
    {
        int isValue7;
        Console.Write("Enter a number : ");
        isValue7 = int.Parse(Console.ReadLine());
        string checkNumber = isValue7.ToString();
        isValue7 = Math.Abs((isValue7 / 100) % 10); 
        Console.WriteLine("Is the third digit from right to left equals 7 ? ");
        Console.WriteLine(isValue7 == 7 ? true : false);
        // Another solution with finding the last but three character of the string and compare it with 7
        Console.WriteLine("Second check. Is the third digit from right to left equals 7 ? ");
        Console.WriteLine(checkNumber[checkNumber.Length - 3].Equals('7') ? true : false);
    }
}

