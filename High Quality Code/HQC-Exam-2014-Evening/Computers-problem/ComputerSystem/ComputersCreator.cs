namespace ComputerSystem
{
    using ComputerSystem.Core.Manufacturer;

    public class ComputersCreator
    {
        private readonly TemplateFactory defaultFactory;

        public ComputersCreator(TemplateFactory factory = null)
        {
            this.defaultFactory = factory ?? new NewManufacturerFactory();
        }

        public ComputerFactory GetManufacturer(string manufacturer, TemplateFactory factory = null)
        {
            return (factory ?? this.defaultFactory).GetManufacturer(manufacturer);
        }
    }
}
