using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.PrintMyAge10YearsLater
{
    class PrintMyAgeTenYearsLater
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the year when you were born : ");
            int birthYear = int.Parse(Console.ReadLine());
            DateTime currentDate = DateTime.Now;
            DateTime tenYearsLaterFromNow = currentDate.AddYears(10);
            Console.WriteLine("Now, I am {0} years old, after ten years I will be {1} years old.", 
                currentDate.Year - birthYear, tenYearsLaterFromNow.Year - birthYear);
        }
    }
}
