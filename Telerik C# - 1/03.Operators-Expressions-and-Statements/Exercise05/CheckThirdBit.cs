using System;

/*
    Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
 */

class CheckThirdBit
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number : ");
        int number = int.Parse(Console.ReadLine());
        int compareBit = 8; //Its representation in binary numeral system is 1000
        int result = number & compareBit; 
        /*
            Compare every bit from the entered number to the bits of the compareBit.
            Only these bits that are true in both variables and have the same position will be saved as 1 in result.
            In copareBit there is only one bit with true value and its position is 3, 
            so if the bit, which has a position 3 in the variable number, is 0 then all the bits in the result will have value 0.
            0000 in decimal is 0.
         */
        Console.WriteLine(result == 0 ? "The third bit is 0." : "The third bit is 1.");

    }
}
