using System.Text;
namespace FactoryMethodPattern
{
    public abstract class Laptop
    {
        public Laptop (int batteryLife, 
            int ram, int hardDriveSpace, HardDriveType hardDrive,
            ProcessorType processor, uint core, double price)
        {
            this.BatteryLife = batteryLife;
            this.Ram = ram;
            this.HardDriveSpace = hardDriveSpace;
            this.HardDrive = hardDrive;
            this.Processor = processor;
            this.Core = core;
            this.Price = price;
        }

        public int BatteryLife { get; set; }

        public int Ram { get; set; }

        public int HardDriveSpace { get; set; }

        public HardDriveType HardDrive { get; set; }

        public ProcessorType Processor { get; set; }

        public uint Core { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Processor: {0}\n", this.Processor);
            builder.AppendFormat("Core: {0}\n", this.Core);
            builder.AppendFormat("RAM: {0} MB\n", this.Ram);
            builder.AppendFormat("Hard drive: {0}\n", this.HardDrive);
            builder.AppendFormat("Hard drive space: {0} GB\n", this.HardDriveSpace);
            builder.AppendFormat("Battery life: {0} H\n", this.BatteryLife);
            builder.AppendFormat("Price {0} $\n", this.Price);

            return builder.ToString();
        }
    }
}