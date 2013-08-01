using System;
using System.Text;

// Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

class Convertation
{
    public static char GetBaseLastFigure(int baseX)
    {
        char baseFigure = new char();

        switch (baseX)
        {
            case 10:
                baseFigure = 'a';
                break;
            case 11:
                baseFigure = 'b';
                break;
            case 12:
                baseFigure = 'c';
                break;
            case 13:
                baseFigure = 'd';
                break;
            case 14:
                baseFigure = 'e';
                break;
            case 15:
                baseFigure = 'f';
                break;
            default:
                baseFigure = (char)baseX;
                break;
        }

        return baseFigure;
    }

    private static int ToDecimal(string number, int baseX)
    {
        int decimalNumber = 0;

        number = number.ToLower();

        if (number.Length == 32 && number[0].Equals(GetBaseLastFigure(baseX))) // The number is negative
        {
            for (int i = number.Length - 1, power = 0; i >= 1; i--, power++)
            {
                switch (number[i])
                {
                    case 'a':
                        decimalNumber += 10 * (int)Math.Pow(baseX, power);
                        break;
                    case 'b':
                        decimalNumber += 11 * (int)Math.Pow(baseX, power);
                        break;
                    case 'c':
                        decimalNumber += 12 * (int)Math.Pow(baseX, power);
                        break;
                    case 'd':
                        decimalNumber += 13 * (int)Math.Pow(baseX, power);
                        break;
                    case 'e':
                        decimalNumber += 14 * (int)Math.Pow(baseX, power);
                        break;
                    case 'f':
                        decimalNumber += 15 * (int)Math.Pow(baseX, power);
                        break;
                    default:
                        decimalNumber += int.Parse(number[i].ToString()) * (int)Math.Pow(16, power);
                        break;
                }
            }
            decimalNumber = -(int)Math.Pow(baseX, 8) + decimalNumber;
        }
        else // The number is positive
        {
            for (int i = number.Length - 1, power = 0; i >= 0; i--, power++)
            {
                switch (number[i])
                {
                    case 'a':
                        decimalNumber += 10 * (int)Math.Pow(baseX, power);
                        break;
                    case 'b':
                        decimalNumber += 11 * (int)Math.Pow(baseX, power);
                        break;
                    case 'c':
                        decimalNumber += 12 * (int)Math.Pow(baseX, power);
                        break;
                    case 'd':
                        decimalNumber += 13 * (int)Math.Pow(baseX, power);
                        break;
                    case 'e':
                        decimalNumber += 14 * (int)Math.Pow(baseX, power);
                        break;
                    case 'f':
                        decimalNumber += 15 * (int)Math.Pow(baseX, power);
                        break;
                    default:
                        decimalNumber += int.Parse(number[i].ToString()) * (int)Math.Pow(baseX, power);
                        break;
                }
            }
        }

        return decimalNumber;
    }


    public static String GetBaseRepresentation(dynamic decNumber, int baseX)
    {
        StringBuilder number = new StringBuilder();

        do
        {
            int temp = (int)(decNumber % baseX);
            switch (temp)
            {
                case 10:
                    number.Append("a");
                    break;
                case 11:
                    number.Append("b");
                    break;
                case 12:
                    number.Append("c");
                    break;
                case 13:
                    number.Append("d");
                    break;
                case 14:
                    number.Append("e");
                    break;
                case 15:
                    number.Append("f");
                    break;
                default:
                    number.Append(temp);
                    break;
            }
            decNumber /= baseX;
        } while (decNumber > 0);

        return number.ToString();
    }

    public static string ConvertToBase(int decimalNumber, int baseX)
    {
        long negativeNumber = 0;
        char[] reversDigits;

        if (decimalNumber < 0)
        {
            negativeNumber = decimalNumber + (long)Math.Pow(baseX, 8);
            Console.WriteLine(negativeNumber);
            reversDigits = GetBaseRepresentation(negativeNumber, baseX).ToCharArray();
        }
        else
        {
            reversDigits = GetBaseRepresentation(decimalNumber, baseX).ToCharArray();
        }

        Array.Reverse(reversDigits);

        return new string(reversDigits);
    }

    static void Main(string[] args)
    {
        Console.Title = "Convertation";

        Console.ForegroundColor = ConsoleColor.Green;

        int firstBase = 0;
        do
        {
            Console.Write("Enter the base of the number: ");
            firstBase = int.Parse(Console.ReadLine());
        } while (firstBase < 2 || firstBase > 16);

        int secondBase = 0;
        do
        {
            Console.Write("Enter the base, which you want to convert the number to: ");
            secondBase = int.Parse(Console.ReadLine());
        } while (secondBase < 2 || secondBase > 16);

        Console.Write("Enter a number, which base is {0} : ", firstBase);
        string number = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThe number, which base is {0}, = {1}", firstBase, number);
        int decimalNumber = ToDecimal(number, firstBase);
        Console.WriteLine("\nThe {0} base representation of the number is {1}", secondBase, ConvertToBase(decimalNumber, secondBase));

        Console.WriteLine();
        Console.ResetColor();
    }
}