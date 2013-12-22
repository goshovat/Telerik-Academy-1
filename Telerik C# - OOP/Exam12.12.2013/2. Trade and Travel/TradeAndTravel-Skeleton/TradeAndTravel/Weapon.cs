using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Weapon : Item
    {
        public Weapon(string name, string type, Location location = null)
           : base(name, 10, type, location) {}
    }
}
