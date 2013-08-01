using System;
using System.Numerics;

class Secrets
{
    static void Main(string[] args)
    {
        var number = Console.ReadLine();

        BigInteger sum = 0;

        int oddNumber = 0;
        int evenNumber = 0;

        for (int i = 1, j = number.Length - 1; i <= number.Length; i++, j--)
        {
            if (i % 2 != 0)
            {
                switch (number[j])
                {
                   /* case '0':
                        oddNumber = 0;
                        break;*/
                    case '1':
                        oddNumber = 1;
                        break;
                    case '2':
                        oddNumber = 2;
                        break;
                    case '3':
                        oddNumber = 3;
                        break;
                    case '4':
                        oddNumber = 4;
                        break;
                    case '5':
                        oddNumber = 5;
                        break;
                    case '6':
                        oddNumber = 6;
                        break;
                    case '7':
                        oddNumber = 7;
                        break;
                    case '8':
                        oddNumber = 8;
                        break;
                    case '9':
                        oddNumber = 9;
                        break;
                    default:
                        oddNumber = 0;
                        break;
                }
               /* if (number[j].Equals('0'))
                {
                    oddNumber = 0;
                }
                else
                {
                    oddNumber = int.Parse(number[j].ToString());
                }*/
                sum += oddNumber * i * i;
            }
            else
            {
                switch (number[j])
                {
                  /*  case '0':
                        evenNumber = 0;
                        break;*/
                    case '1':
                        evenNumber = 1;
                        break;
                    case '2':
                        evenNumber = 2;
                        break;
                    case '3':
                        evenNumber = 3;
                        break;
                    case '4':
                        evenNumber = 4;
                        break;
                    case '5':
                        evenNumber = 5;
                        break;
                    case '6':
                        evenNumber = 6;
                        break;
                    case '7':
                        evenNumber = 7;
                        break;
                    case '8':
                        evenNumber = 8;
                        break;
                    case '9':
                        evenNumber = 9;
                        break;
                    default:
                        evenNumber = 0;
                        break;
                }
                /*if (number[j].Equals('0'))
                {
                    evenNumber = 0;
                }
                else
                {
                    evenNumber = int.Parse(number[j].ToString());
                }*/
                sum += evenNumber * evenNumber * i;
            }
  
        }

        BigInteger size = sum % 10;

        BigInteger r = sum % 26;

        BigInteger firstLetter = r + 65;
    

        if (size == 0)
        {
            Console.WriteLine(sum);
            Console.WriteLine("{0} has no secret alpha-sequence", number);
        }
        else
        {
            Console.WriteLine(sum);
            for (BigInteger i = 0; i < size; i++)
            {
                Console.Write("{0}",(char)firstLetter);
                firstLetter++;
                if (firstLetter == 91)
                {
                    firstLetter = 65;
                }
            }

        }

    
    }
}