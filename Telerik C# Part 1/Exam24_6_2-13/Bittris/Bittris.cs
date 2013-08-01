using System;

class Bittris
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] number = new int[n];
        string[,] position = new string[3,n];

        char[,] bitsMatrix = new char[4, 8];


        int points = 0;

        for (int i = 0; i < n; i++)
        {
        
            number[i] = int.Parse(Console.ReadLine());
            position[0,i] = Console.ReadLine();
            position[1,i] = Console.ReadLine();
            position[2,i] = Console.ReadLine();

            string stringNumber = Convert.ToString(number[i], 2);
            if (stringNumber.Length % 8 != 0)
            {
                int length = stringNumber.Length % 8;
                stringNumber = new string('0', 8 - stringNumber.Length) + stringNumber;
            }

            for (int p = 0; p < 8; p++)
            {
                if (stringNumber[p].Equals("1"))
                {
                    points++;
                }
    
            }
        }
     
        Console.WriteLine(points - 8);
    }
}