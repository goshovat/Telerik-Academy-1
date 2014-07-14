using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public abstract class Person
    {
        private readonly string name;
        private readonly string location;
        private AbstractTaxiStation taxiStation;

        public Person(string name, string location)
        {
            this.name = name;
            this.location = location;
        }

        public string Location
        {
            get
            {
                return this.location;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public AbstractTaxiStation TaxiStation
        {
            get { return this.taxiStation; }
            set { this.taxiStation = value; }
        }

        public void Call()
        {
            this.taxiStation.Call(this.name);
        }

        public abstract void Receive(string from, string message);
    }
}
