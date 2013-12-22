using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : IPilot
    {
        private ICollection<IMachine> machineEngaged;
        private string name;

        public Pilot(string name)
        {
            this.Name = name;
            this.MachineEngaged = new List<IMachine>(); 
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }
            private set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Pilot name cannot be empty string or a sequence of white spaces!");
                }

                this.name = value;
            }
        }

        public ICollection<IMachine> MachineEngaged
        {
            get
            {
                return this.machineEngaged;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Engaged machines cannot be null!");
                }

                this.machineEngaged = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            this.machineEngaged.Add(machine);
            this.machineEngaged.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name);
        }

        public string Report()
        {
            StringBuilder builder = new StringBuilder();

            int countMachinces = this.machineEngaged.Count;
            builder.Append(this.Name);

            if (countMachinces == 0)
            {
                builder.AppendFormat(" - no machines");
                return builder.ToString();
            }
            else if (countMachinces == 1)
            {
                builder.AppendLine(" - 1 machine");
                foreach (var machine in this.machineEngaged)
                {
                    Fighter knownFighter;
                    Machine knownMachine;
                    if (machine is Fighter)
                    {
                        knownFighter = machine as Fighter;
                        builder.Append(knownFighter);
                    }
                    else
                    {
                        knownMachine = machine as Tank;
                        builder.Append(knownMachine);
                    }
                }
            }
            else
            {
                builder.AppendLine(" - " + countMachinces + " machines");
                foreach (var machine in this.machineEngaged)
                {
                    Fighter knownFighter;
                    Machine knownMachine;
                    if (machine is Fighter)
                    {
                        knownFighter = machine as Fighter;
                        builder.Append(knownFighter);
                        builder.AppendLine();
                    }
                    else
                    {
                        knownMachine = machine as Tank;
                        builder.Append(knownMachine);
                        builder.AppendLine();
                    }
                }
                builder.Length = builder.Length - 2;
            }

            return builder.ToString();
        }
    }
}
