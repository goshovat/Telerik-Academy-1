namespace ComputerSystem.Core
{
    public class AdvancedCpu : Cpu
    {
        private const int MinPowerNumberFor128 = 0;
        private const int MaxPowerNumberFor128 = 500;

        public AdvancedCpu(byte numberOfCores, byte numberOfBits, IMotherboard motherBoard)
            : base(numberOfCores, numberOfBits, motherBoard)
        {
        }

        public override void SquareNumber()
        {
            if (this.NumberOfBits == (int)ArchitectureType.Bits128)
            {
                this.CalculateSquareNumber(MinPowerNumberFor128, MaxPowerNumberFor128);
            }
            else
            {
                base.SquareNumber();
            }
        }
    }
}
