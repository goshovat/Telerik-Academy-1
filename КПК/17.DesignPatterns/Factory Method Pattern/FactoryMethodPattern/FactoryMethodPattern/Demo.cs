using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            var asus = new Asus();
            var hewlettPackard = new HewlettPackard();

            Laptop laptopFromAsus = asus.ManufactureLaptop();
            Laptop laptopFromHP = hewlettPackard.ManufactureLaptop();

            Console.WriteLine(laptopFromAsus);

            Console.WriteLine(laptopFromHP);
        }
    }
}
