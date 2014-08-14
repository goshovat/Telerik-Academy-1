namespace ComputerSystem.Core.Computers
{
    public class Laptop : IComputer, IBattery
    {
        private IMotherboard motherboard;
        private Cpu cpu;
        private HardDriveComponent hardDrive;
        private LaptopBattery laptopBattery;

        public Laptop(IMotherboard motherboard, Cpu cpu, HardDriveComponent hardDrive, LaptopBattery laptopBattery)
        {
            this.Motherboard = motherboard;
            this.Cpu = cpu;
            this.HardDrive = hardDrive;
            this.LaptopBattery = laptopBattery;
        }

        public LaptopBattery LaptopBattery
        {
            get
            {
                return this.laptopBattery;
            }

            set
            {
                this.laptopBattery = value;
            }
        }

        public HardDriveComponent HardDrive
        {
            get
            {
                return this.hardDrive;
            }

            set
            {
                this.hardDrive = value;
            }
        }

        public IMotherboard Motherboard
        {
            get
            {
                return this.motherboard;
            }

            set
            {
                this.motherboard = value;
            }
        }

        public Cpu Cpu
        {
            get
            {
                return this.cpu;
            }

            set
            {
                this.cpu = value;
            }
        }

        public void ChargeBattery(int percentage)
        {
            this.LaptopBattery.Charge(percentage);

            this.Motherboard.DrawOnVideoCard(string.Format("Battery status: {0}%", this.LaptopBattery.Percentage));
        }
    }
}
