namespace ComputerSystem.Core.Computers
{
    public class Server : IComputer, IRequestable
    {
        private IMotherboard motherboard;
        private Cpu cpu;
        private HardDriveComponent hardDrive;

        public Server(IMotherboard motherboard, Cpu cpu, HardDriveComponent hardDrive)
        {
            this.Motherboard = motherboard;
            this.Cpu = cpu;
            this.HardDrive = hardDrive;
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

        public void Process(int data)
        {
            this.Motherboard.SaveRamValue(data);
            this.Cpu.SquareNumber();
        }
    }
}
