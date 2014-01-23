using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Tron3d
{
    class Tron3d
    {
        static void Main(string[] args)
        {
            int[, ,] masiv = new int[2, 4, 5];

            masiv[1, 2, 1] = 1;
            masiv[0, 0, 0] = 11;
            masiv[0, 0, 1] = 321;


            Console.WriteLine(masiv);
        }
    }
}
