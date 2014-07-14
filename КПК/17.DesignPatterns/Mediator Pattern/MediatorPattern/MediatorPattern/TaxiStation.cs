using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class TaxiStation : AbstractTaxiStation
    {
        private readonly Dictionary<string, Person> people =
            new Dictionary<string, Person>();

        private readonly Dictionary<string, Person> drivers =
          new Dictionary<string, Person>();

        public override void Register(Person person)
        {
            if (person is TaxiDriver)
            {
                if (!this.people.ContainsValue(person))
                {
                    this.drivers[person.Name] = person;
                }
            }
            else
            {
                if (!this.people.ContainsValue(person))
                {
                    this.people[person.Name] = person;
                }
            }

            person.TaxiStation = this;
        }

        public override void Call(string from)
        {
            var client = people[from];
            bool hasNearDriver = false;

            foreach (var driver in drivers)
            {
                if (driver.Value.Location == client.Location)
                {
                    driver.Value.Receive(from, string.Format("at {0} pick up the guy", client.Location));
                    client.Receive(driver.Value.Name, "will pick you up in 2 minutes");
                    hasNearDriver = true;
                    break;
                }
            }

            if (!hasNearDriver)
            {
                var theChoosenDriver = drivers.First().Value;

                theChoosenDriver.Receive(from, string.Format("at {0} pick up the guy", client.Location));
                client.Receive(theChoosenDriver.Name, "will pick you up in 8 minutes");
            }
        }
    }
}
