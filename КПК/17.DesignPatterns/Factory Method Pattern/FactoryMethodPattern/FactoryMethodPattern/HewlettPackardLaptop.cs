namespace FactoryMethodPattern
{
    public class HewlettPackardLaptop : Laptop
    {


        public HewlettPackardLaptop(string joystick, int batteryLife, int ram, int hardDriveSpace, 
            HardDriveType hardDrive, ProcessorType processor, uint core, double price)
            : base (batteryLife, ram, hardDriveSpace, hardDrive, processor, core, price)
        {
            this.Joystick = joystick;
        }

        public string Joystick { get; set; }

        public override string ToString()
        {
            string asusInfo = string.Format("Joystick: {0}\n{1}", this.Joystick, base.ToString());

            return asusInfo;
        }
    }
}
