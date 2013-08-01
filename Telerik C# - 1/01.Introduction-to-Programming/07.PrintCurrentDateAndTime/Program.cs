using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PrintCurrentDateAndTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentDateAndTime = DateTime.Now;
            Console.WriteLine("Current date and time is : {0}", currentDateAndTime);
        }
    }
}
