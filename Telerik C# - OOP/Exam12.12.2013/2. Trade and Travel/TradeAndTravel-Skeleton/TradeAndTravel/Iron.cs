using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Iron : Item
    {
        public Iron(string name, string type, Location location = null)
            : base(name, 3, type, location) { }
    }
}
