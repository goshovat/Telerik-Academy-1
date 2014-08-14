namespace ComputerSystem
{
    using ComputerSystem.Core.Manufacturer;

    public abstract class TemplateFactory
    {
        public abstract ComputerFactory GetManufacturer(string manufacturer);
    }
}
