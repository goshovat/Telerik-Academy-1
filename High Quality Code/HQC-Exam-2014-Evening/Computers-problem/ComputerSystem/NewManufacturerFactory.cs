namespace ComputerSystem
{
    using ComputerSystem.Core;
    using ComputerSystem.Core.Manufacturer;

    public class NewManufacturerFactory : ManufacturerFactory
    {
        public override ComputerFactory GetManufacturer(string manufacturer)
        {
            switch (manufacturer)
            {
                case Manufacturers.Lenovo:
                    return new Lenovo();
                default:
                    return base.GetManufacturer(manufacturer);
            }
        }
    }
}
