namespace ComputerSystem
{
    using System;
    using ComputerSystem.Core;
    using ComputerSystem.Core.Manufacturer;

    public class ManufacturerFactory : TemplateFactory
    {
        public override ComputerFactory GetManufacturer(string manufacturer)
        {
            switch (manufacturer)
            {
                case Manufacturers.HP:
                    return new HP();
                case Manufacturers.Dell:
                    return new Dell();
                default:
                    throw new InvalidArgumentException("Invalid manufacturer!");
            }
        }
    }
}
