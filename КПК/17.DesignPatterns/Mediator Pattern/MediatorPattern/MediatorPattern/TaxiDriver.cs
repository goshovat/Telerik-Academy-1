using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class TaxiDriver : Person
    {
        public TaxiDriver(string name, string location)
            : base(name, location)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine("{0}, {1} {2} ", this.Name, message, from);
        }
    }
}
