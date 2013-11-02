namespace MobilePhone
{
    /*
       3.Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries. 
    */
    using System;
    using System.Linq;

    public enum BatteryType {
        LiIon, 
        NiMH, 
        NiCd,
        LiPo
    };

    public class Battery
    {
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private int? hoursIdle;

        public int? HoursIdle
        {
            get { return hoursIdle; }
            set 
            {
                if (value <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong hours idle!!!");
                }
                else
                {
                    hoursIdle = value; 
                }
            }
        }
        private int? hoursTalk;

        public int? HoursTalk
        {
            get { return hoursTalk; }
            set 
            {
                if (value <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong hours talk!!!");
                }
                else
                {
                    hoursTalk = value;
                }
            }
        }
        private BatteryType? batteryType;

        internal BatteryType? BatteryType
        {
            get { return batteryType; }
            set { batteryType = value; }
        }

        public Battery(string model, int hoursIdle, int hoursTalk, BatteryType batteryType)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.batteryType = batteryType;
        }

        public Battery()
        {
            this.model = null;
            this.hoursIdle = null;
            this.hoursTalk = null;
            this.batteryType = null;
        }
    }
}
