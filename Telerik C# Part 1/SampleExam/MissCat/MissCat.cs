using System;
using System.Linq;

class MissCat
{
    static void Main(string[] args)
    {
        uint n = uint.Parse(Console.ReadLine());
    
        uint[] cats = new uint[10];

        do
        {
            cats[byte.Parse(Console.ReadLine()) - 1]++;
            n--;
        } while (n > 0);

        uint max = cats.Max();

        for (int i = 0; i < 10; i++)
        {
            if (cats[i] == max)
            {
                Console.WriteLine(i+1);
                break;
            }
        }
    }
}