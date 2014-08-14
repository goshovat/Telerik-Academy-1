namespace ComputerSystem.Core
{
    public class LaptopBattery
    {
        private const int InitialPowerLeft = 50;

        public LaptopBattery()
        {
            this.Percentage = InitialPowerLeft;
        }

        public int Percentage { get; set; }

        public void Charge(int chargePercentage)
        {
            this.Percentage += chargePercentage;

            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }

            if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}
