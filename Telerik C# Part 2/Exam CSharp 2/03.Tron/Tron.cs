using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Tron
{
    class Tron
    {
        static void Main(string[] args)
        {
            string[] str = new string[] { "RED", "BLUE", "DRAW" };

            for (int i = 0; i < 3; i++)
            {
                Console.ReadLine();
            }
            Random rand = new Random();
            Console.WriteLine(str[rand.Next(3)]);
           
            Console.WriteLine(rand.Next(10));


            Console.WriteLine("RED");
            Console.WriteLine(8);
        }
    }
}
