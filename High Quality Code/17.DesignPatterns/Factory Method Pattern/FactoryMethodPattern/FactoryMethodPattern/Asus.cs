namespace FactoryMethodPattern
{
    public class Asus : Manufacturer
    {
        public override Laptop ManufactureLaptop()
        {
            var laptop = new AsusLaptop("Asus mouse", 6, 2048, 512, HardDriveType.HardDiskDrive, ProcessorType.AMD, 2, 700d);

            return laptop;
        }
    }
}
