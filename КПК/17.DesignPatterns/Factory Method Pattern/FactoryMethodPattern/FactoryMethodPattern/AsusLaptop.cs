namespace FactoryMethodPattern
{
    public class AsusLaptop : Laptop
    {
        public AsusLaptop(string mouse, int batteryLife, int ram, int hardDriveSpace, 
            HardDriveType hardDrive, ProcessorType processor, uint core, double price)
            : base (batteryLife, ram, hardDriveSpace, hardDrive, processor, core, price)
        {
            this.Mouse = mouse;
        }

        public string Mouse { get; set; }

        public override string ToString()
        {
            string asusInfo = string.Format("Mouse: {0}\n{1}", this.Mouse, base.ToString());

            return asusInfo;
        }
    }
}
