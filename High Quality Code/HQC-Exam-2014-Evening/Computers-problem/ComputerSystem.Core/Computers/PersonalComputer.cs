namespace ComputerSystem.Core.Computers
{
    public class PersonalComputer : IComputer, IPlayable
    {
        private IMotherboard motherboard;
        private Cpu cpu;
        private HardDriveComponent hardDrive;

        public PersonalComputer(IMotherboard motherboard, Cpu cpu, HardDriveComponent hardDrive)
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

        public void Play(int guessNumber)
        {
            this.Cpu.GenerateRandomNumber(1, 10);
            var number = this.Motherboard.LoadRamValue();
            if (number + 1 != guessNumber + 1)
            {
                this.Motherboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.Motherboard.DrawOnVideoCard("You win!");
            }
        }
    }
}
