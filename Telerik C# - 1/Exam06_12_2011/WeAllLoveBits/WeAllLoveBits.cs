using System;

class WeAllLoveBits
{
    static void Main(string[] args)
    {
        uint number = uint.Parse(Console.ReadLine());

        uint[] numbers = new uint[number];

        for (uint i = 0; i < number; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
            numbers[i] = MitkosMagic(numbers[i]);
        }

        for (uint i = 0; i < number; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }

    static uint MitkosMagic(uint number)
    {
        uint newNumber = 0;
        uint invertedNumber;
        uint reversedNumber;
        string reverse = Convert.ToString(number, 2);
        string invert = Convert.ToString(number, 2);
        invert = Invert(invert);
        reverse = ReverseString(reverse);
        reversedNumber = Convert.ToUInt32(reverse, 2);
        invertedNumber = Convert.ToUInt32(invert, 2);
        newNumber = (number ^ invertedNumber) & reversedNumber;
        return newNumber;
    }

    static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    static string Invert(string s)
    {
        int sLength = s.Length;
        string invertedString = "";
        for (int i = 0; i < sLength; i++)
        {
            if(s[i].Equals('0'))
            {
                invertedString += "1";
            }
            else
            {
                invertedString += "0";
            }
        }
        return invertedString;
    }

}