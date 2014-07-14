using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AbstractTaxiStation taxiStation = new TaxiStation();

            Person pesho = new TaxiDriver("Pesho", "Student city, flat 55");
            Person gosho = new TaxiDriver("Gosho", "Student city, Mega dance center");
            Person vankata = new TaxiDriver("Vankata", "Student city, Jim Beam");
            Person kircho = new Client("Kircho", "Student city, Mega dance center");
            Person mircho = new Client("Mircho", "Student city, Jim Beam");
            Person asencho = new Client("Asencho", "Student city, Play house");

            taxiStation.Register(pesho);
            taxiStation.Register(gosho);
            taxiStation.Register(vankata);
            taxiStation.Register(kircho);
            taxiStation.Register(mircho);
            taxiStation.Register(asencho);

            kircho.Call();
            Console.WriteLine();

            mircho.Call();
            Console.WriteLine();

            asencho.Call();
            Console.WriteLine();
        }
    }
}
