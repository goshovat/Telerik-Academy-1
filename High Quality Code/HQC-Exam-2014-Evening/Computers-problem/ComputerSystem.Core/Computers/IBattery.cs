namespace ComputerSystem.Core.Computers
{
    public interface IBattery
    {
        LaptopBattery LaptopBattery { get; set; }

        void ChargeBattery(int percentage);
    }
}
