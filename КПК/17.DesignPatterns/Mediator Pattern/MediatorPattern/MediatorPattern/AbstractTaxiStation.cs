using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public abstract class AbstractTaxiStation
    {
        public abstract void Register(Person person);

        public abstract void Call(string from);
    }
}
