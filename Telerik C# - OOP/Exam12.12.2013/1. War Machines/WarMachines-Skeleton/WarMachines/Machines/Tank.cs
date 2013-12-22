using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints) 
        {
            this.HealthPoints = 100;
            this.DefenseMode = true;
            ChangePointsAfterToggledTheMode();
        }

        public bool DefenseMode
        {
            get 
            { 
                return this.defenseMode; 
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Defense mode of the tank cannot be null!");
                }

                this.defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            this.defenseMode = !this.defenseMode;
            this.ChangePointsAfterToggledTheMode();
        }

        private void ChangePointsAfterToggledTheMode()
        {
            if (this.defenseMode)
            {
                this.defensePoints += 30;
                this.attackPoints -= 40;
            }
            else
            {
                this.defensePoints -= 30;
                this.attackPoints += 40;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.ToString());
            builder.Append(" *Defense: " + (this.defenseMode ? "ON" : "OFF"));
            return builder.ToString();
        }
    }
}
