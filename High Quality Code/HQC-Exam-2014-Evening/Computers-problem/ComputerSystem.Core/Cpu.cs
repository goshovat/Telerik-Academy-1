namespace ComputerSystem.Core
{
    using System;

    public class Cpu
    {
        protected readonly byte NumberOfBits;

        private const int MinPowerNumberFor32 = 0;
        private const int MaxPowerNumberFor32 = 500;
        private const int MinPowerNumberFor64 = 0;
        private const int MaxPowerNumberFor64 = 1000;
        
        private static readonly Random Random = new Random();
        private readonly IMotherboard motherboard;

        public Cpu(byte numberOfCores, byte numberOfBits, IMotherboard motherboard)
        {
            this.NumberOfBits = numberOfBits;
            this.NumberOfCores = numberOfCores;
            this.motherboard = motherboard;
        }

        private byte NumberOfCores { get; set; }

        public virtual void SquareNumber()
        {
            if (this.NumberOfBits == (int)ArchitectureType.Bits32)
            {
                this.CalculateSquareNumber(MinPowerNumberFor32, MaxPowerNumberFor32);
            }

            if (this.NumberOfBits == (int)ArchitectureType.Bits64)
            {
                this.CalculateSquareNumber(MinPowerNumberFor64, MaxPowerNumberFor64);
            }
        }

        public void GenerateRandomNumber(int from, int to)
        {
            int randomNumber = Random.Next(from, to + 1);
            
            this.motherboard.SaveRamValue(randomNumber);
        }

        protected void CalculateSquareNumber(int powerFrom, int powerTo)
        {
            var number = this.motherboard.LoadRamValue();

            if (number < powerFrom)
            {
                this.motherboard.DrawOnVideoCard("Number too low.");
            }
            else if (number > powerTo)
            {
                this.motherboard.DrawOnVideoCard("Number too high.");
            }
            else
            {
                int squareNumber = number * number;

                this.motherboard.DrawOnVideoCard(string.Format("Square of {0} is {1}.", number, squareNumber));
            }
        }
    }
}
