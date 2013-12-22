using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {
        protected double attackPoints;
        protected double defensePoints;
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private IList<string> targets;

        protected Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Machine name cannot be empty string or a sequence of white spaces!");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Pilot of the machine cannot be null!");
                }

                this.pilot = value;
            }
        }
        
        public double HealthPoints  
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Machine's health points cannot be null!");
                }

                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("Machine's health points cannot be negative!");
                }

                this.healthPoints = value;
            }
        }
        public double AttackPoints
        {
            get 
            { 
                return this.attackPoints; 
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Machine's attack points cannot be null!");
                }

                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("Machine's attack points cannot be negative!");
                }

                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get 
            { 
                return this.defensePoints; 
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Machine's defense points cannot be null!");
                }

                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("Machine's defense points cannot be negative!");
                }

                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get 
            { 
                return this.targets; 
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Targets cannot be null!");
                }

                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            int countTargets = this.targets.Count;

            builder.AppendLine("- " + this.Name);
            builder.AppendLine(" *Type: " + this.GetType().Name);
            builder.AppendLine(" *Health: " + this.HealthPoints);
            builder.AppendLine(" *Attack: " + this.AttackPoints);
            builder.AppendLine(" *Defense: " + this.DefensePoints);
            builder.AppendLine(" *Targets: " + (countTargets == 0 ? "None" : string.Join(", ", this.targets)));

            return builder.ToString();
        }
    }
}
