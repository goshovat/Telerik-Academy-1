using System;

/*
    Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). 
    The cards should be printed with their English names. Use nested for loops and switch-case.
*/

class PrintAllCards
{
    static void Main(string[] args)
    {
        Console.Title = "Print all cards from a standard deck";

        string[] cardsType = { "Clubs", "Diamonds", "Hearts", "Spades" };
        char[] cardsTypeSymbol = { '\u2663', '\u2666', '\u2665', '\u2660' };

        Console.WriteLine("Standard deck cards :");
        Console.WriteLine(new string('-', 21));

        for (int color = 0; color < cardsType.Length; color++)
        {
            Console.WriteLine("\n{0} {1}", cardsType[color], cardsTypeSymbol[color]);
            Console.WriteLine(new string('-', 17));
            for (int card = 1; card <= 13; card++)
            {
                switch (card)
                {
                    case 1:
                        Console.WriteLine("Ace of {0}", cardsType[color]);
                        break;
                    case 2:
                        Console.WriteLine("Deuce of {0}", cardsType[color]);
                        break;
                    case 3:
                        Console.WriteLine("Three of {0}", cardsType[color]);
                        break;
                    case 4:
                        Console.WriteLine("Four of {0}", cardsType[color]);
                        break;
                    case 5:
                        Console.WriteLine("Five of {0}", cardsType[color]);
                        break;
                    case 6:
                        Console.WriteLine("Six of {0}", cardsType[color]);
                        break;
                    case 7:
                        Console.WriteLine("Seven of {0}", cardsType[color]);
                        break;
                    case 8:
                        Console.WriteLine("Eight of {0}", cardsType[color]);
                        break;
                    case 9:
                        Console.WriteLine("Nine of {0}", cardsType[color]);
                        break;
                    case 10:
                        Console.WriteLine("Ten of {0}", cardsType[color]);
                        break;
                    case 11:
                        Console.WriteLine("Jack of {0}", cardsType[color]);
                        break;
                    case 12:
                        Console.WriteLine("Queen of {0}", cardsType[color]);
                        break;
                    case 13:
                        Console.WriteLine("King of {0}", cardsType[color]);
                        break;
                }
            }
        }
    }
}