using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Wood : Item
    {
        public Wood(string name, string type, Location location = null)
            : base(name, 2, type, location) { }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.Value > 1)
            {
                this.Value--;
            }
        }
    }
}
