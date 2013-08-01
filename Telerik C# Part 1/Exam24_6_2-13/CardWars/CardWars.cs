using System;
using System.Numerics;
class CardWars
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int currentScore1 = 0;
        int currentScore2 = 0;
        BigInteger finalScore1 = 0;
        BigInteger finalScore2 = 0;
        int firstWin = 0;
        int secondWin = 0;

        int flag1 = 0;
        int flag2 = 0;

        for (int i = 0; i < n; i++)
        {
            string player1Card1 = Console.ReadLine();
            string player1Card2 = Console.ReadLine();
            string player1Card3 = Console.ReadLine();
            string[] cards1 = new string[3];
            cards1[0] = player1Card1;
            cards1[1] = player1Card2;
            cards1[2] = player1Card3;
            currentScore1 = Score(player1Card1, player1Card2, player1Card3);
            string player2Card1 = Console.ReadLine();
            string player2Card2 = Console.ReadLine();
            string player2Card3 = Console.ReadLine();
            string[] cards2 = new string[3];
            cards2[0] = player2Card1;
            cards2[1] = player2Card2;
            cards2[2] = player2Card3;
            currentScore2 = Score(player2Card1, player2Card2, player2Card3);
            for (int j = 0; j < 3; j++)
            {
                //first
                if (cards1[j].Equals("Z"))
                {
                    finalScore1 *= 2;
                }
                else if (cards1[j].Equals("Y"))
                {
                    finalScore1 -= 200;
                }
                else if (cards1[j].Equals("X"))
                {
                    flag1 = 1;
                }

                //second
                if (cards2[j].Equals("Z"))
                {
                    finalScore2 *= 2;
                }
                else if (cards2[j].Equals("Y"))
                {
                    finalScore2 -= 200;
                }
                else if (cards2[j].Equals("X"))
                {
                    flag2 = 1;
                }
            }

            if (flag1 == 1 && flag2 == 1)
            {
                finalScore1 += 50;
                finalScore2 += 50;
                flag1 = 0;
                flag2 = 0;
            }

            if (flag1 == 1)
            {
                break;
            }
            else if (flag2 == 1)
            {
                break;
            }
            else
            {
                if (currentScore1 > currentScore2)
                {
                    firstWin++;
                    finalScore1 += currentScore1;

                }
                else if (currentScore1 < currentScore2)
                {
                    secondWin++;
                    finalScore2 += currentScore2;
                }
            
            }

        }

        if (flag1 == 1 && flag2 == 1)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", finalScore1);
        }
        else if (flag1 == 1)
        {
            Console.WriteLine("X card drawn! Player one wins the match!");
        }
        else if (flag2 == 1)
        {
            Console.WriteLine("X card drawn! Player two wins the match!");
        }
        else if (finalScore1 > finalScore2)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", finalScore1);
            Console.WriteLine("Games won: {0}", firstWin);
        }
        else if (finalScore1 < finalScore2)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", finalScore2);
            Console.WriteLine("Games won: {0}", secondWin);
        }
        else
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", finalScore1);
        }

    }

    static int Score(string a, string b, string c)
    {
        int result = 0;
        string[] cards = new string[3];
        cards[0] = a;
        cards[1] = b;
        cards[2] = c;
        for (int i = 0; i < 3; i++)
        {
            switch (cards[i])
            {
                case "2":
                    result += 10;
                    break;
                case "3":
                    result += 9;
                    break;
                case "4":
                    result += 8;
                    break;
                case "5":
                    result += 7;
                    break;
                case "6":
                    result += 6;
                    break;
                case "7":
                    result += 5;
                    break;
                case "8":
                    result += 4;
                    break;
                case "9":
                    result += 3;
                    break;
                case "10":
                    result += 2;
                    break;
                case "A":
                    result += 1;
                    break;
                case "J":
                    result += 11;
                    break;
                case "Q":
                    result += 12;
                    break;
                case "K":
                    result += 13;
                    break;
            }
        }
        return result;
    }
}