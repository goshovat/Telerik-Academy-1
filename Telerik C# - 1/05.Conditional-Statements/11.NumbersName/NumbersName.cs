using System;

/*
    Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
	0 -> "Zero"
	273 -> "Two hundred seventy three"
	400 -> "Four hundred"
	501 -> "Five hundred and one"
	711 -> "Seven hundred and eleven"
*/

class NumbersName
{
    static void Main(string[] args)
    {
        Console.Title = "Numbers name";
        short number = 1000;
        while (number < 0 || number > 999)
        {
            Console.Write("Enter a number in the range [0...999] : ");
            number = short.Parse(Console.ReadLine());
        }
        byte firstNumber = (byte)(number / 100);
        byte secondNumber = (byte)((number / 10) % 10);
        byte thirdNumber = (byte)(number % 10);

        Console.WriteLine("The text corresponding to number's English pronunciation is :");

        switch (firstNumber)
        {
            case 1:
                Console.Write("one hundred ");
                break;
            case 2:
                Console.Write("two hundred ");
                break;
            case 3:
                Console.Write("three hundred ");
                break;
            case 4:
                Console.Write("four hundred ");
                break;
            case 5:
                Console.Write("five hundred ");
                break;
            case 6:
                Console.Write("six hundred ");
                break;
            case 7:
                Console.Write("seven hundred ");
                break;
            case 8:
                Console.Write("eight hundred ");
                break;
            case 9:
                Console.Write("nine hundred ");
                break;
        }

        byte flagThirdNumbe = 0;

        if (thirdNumber == 0)
        {
            Console.Write("and ");
        }

        switch (secondNumber)
        {
            case 0:
                if (firstNumber != 0 && thirdNumber != 0)
                {
                    Console.Write("and ");
                }
                break;
            case 1:
                flagThirdNumbe = 1;
                if (firstNumber != 0)
                {
                    Console.Write("and ");
                }
                switch (thirdNumber)
                {
                    case 0:
                        Console.WriteLine("ten");
                        break;
                    case 1:
                        Console.WriteLine("eleven");
                        break;
                    case 2:
                        Console.WriteLine("twelve");
                        break;
                    case 3:
                        Console.WriteLine("thirteen");
                        break;
                    case 4:
                        Console.WriteLine("fourteen");
                        break;
                    case 5:
                        Console.WriteLine("fifteen");
                        break;
                    case 6:
                        Console.WriteLine("sixteen");
                        break;
                    case 7:
                        Console.WriteLine("seventeen");
                        break;
                    case 8:
                        Console.WriteLine("eighteen");
                        break;
                    case 9:
                        Console.WriteLine("nineteen");
                        break;
                }
                break;
            case 2:
                Console.Write("twenty ");
                break;
            case 3:
                Console.Write("thirty ");
                break;
            case 4:
                Console.Write("forty ");
                break;
            case 5:
                Console.Write("fifty ");
                break;
            case 6:
                Console.Write("sixty ");
                break;
            case 7:
                Console.Write("seventy ");
                break;
            case 8:
                Console.Write("eighty ");
                break;
            case 9:
                Console.Write("ninety ");
                break;
        }

        if (flagThirdNumbe == 0)
        {
            switch (thirdNumber)
            {
                case 0:
                    if (firstNumber == 0 && secondNumber == 0)
                    {
                        Console.Write("zero");
                    }
                    break;
                case 1:
                    Console.Write("one");
                    break;
                case 2:
                    Console.Write("two");
                    break;
                case 3:
                    Console.Write("three");
                    break;
                case 4:
                    Console.Write("four");
                    break;
                case 5:
                    Console.Write("five");
                    break;
                case 6:
                    Console.Write("six");
                    break;
                case 7:
                    Console.Write("seven");
                    break;
                case 8:
                    Console.Write("eight");
                    break;
                case 9:
                    Console.Write("nine");
                    break;
            }
        }
        Console.WriteLine();
    }
}