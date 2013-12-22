using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine, IFighter
    {
        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
            this.HealthPoints = 200;
        }

        public bool StealthMode
        {
            get 
            { 
                return this.stealthMode; 
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Stealth mode of the fighter cannot be null!");
                }

                this.stealthMode = value;
            }
        }

        public void ToggleStealthMode()
        {
            this.stealthMode = !this.stealthMode;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.ToString());
            builder.Append(" *Stealth: " + (this.stealthMode ? "ON" : "OFF"));
            return builder.ToString();
        }
    }
}
