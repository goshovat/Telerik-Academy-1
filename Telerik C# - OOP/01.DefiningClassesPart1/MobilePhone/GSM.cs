namespace MobilePhone
{
    /*
        1.Define a class that holds information about a mobile phone device: model, manufacturer, price, 
        owner, battery characteristics (model, hours idle and hours talk) and display characteristics 
        (size and number of colors). Define 3 separate classes (class GSM holding instances of the classes 
        Battery and Display).
        
        2.Define several constructors for the defined classes that take different sets of arguments 
        (the full information for the class or part of it). Assume that model and manufacturer are 
        mandatory (the others are optional). All unknown data fill with null.
      
        4.Add a method in the GSM class for displaying all information about it. Try to override ToString().

        5.Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. 
        Ensure all fields hold correct data at any given time.
    
        6.Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
        
        9.Add a property CallHistory in the GSM class to hold a list of the performed calls. Try to use the 
        system class List<Call>.
     
        10.Add methods in the GSM class for adding and deleting calls from the calls history. Add a method 
        to clear the call history.

        11.Add a method that calculates the total price of the calls in the call history. Assume the price 
        per minute is fixed and is provided as a parameter.

     */

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private string manufacturer;

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        private double? price;

        public double? Price
        {
            get { return price; }
            set 
            {
                if (value <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong price!!!");
                }
                else
                {
                    price = value;
                }
            }
        }

        private string owner;

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        private Battery battery;

        internal Battery Battery
        {
            get { return battery; }
            set { battery = value; }
        }

        private Display display;

        internal Display Display
        {
            get { return display; }
            set { display = value; }
        }

        private static readonly GSM iPhone4S = new GSM("iPhone 4s", "Apple", 1000.00, "No owner", "Non-removable Li-Po 1432 mAh battery (5.3 Wh)", 200, 14, BatteryType.LiPo, 3.5, 16000000); 

        public static GSM IPhone4S
        {
           get { return GSM.iPhone4S; }
        }

        private List<Call> callHistory;

        public List<Call> CallHistory
        {
            get { return callHistory; }
        }

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void DeleteCall(int index)
        {
            this.callHistory.RemoveAt(index);
        }

        public void ClearHistory()
        {
            this.callHistory.Clear();
        }

        public double TotalPriceOfCalls(double pricePerMinute)
        {
            double totalPrice = 0;

            for (int index = 0; index < this.callHistory.Count; index++)
            {
                double minutes = callHistory[index].Duration / 60.0;
                totalPrice += Math.Ceiling(minutes) * pricePerMinute; //Math.Ceiling returns the smallest integral value that is greater than or equal to minutes.
            }

            return totalPrice;
        }

        public string CallsInformation()
        {
            StringBuilder calls = new StringBuilder();

            calls.Append("\t\t\tCalls history\n");
            for (int index = 0; index < callHistory.Count; index++)
			{
			    calls.Append(new string('*',Console.WindowWidth));  
                calls.Append(string.Format("\tDate and time: {0}\n", callHistory[index].DateTime));
                calls.Append(string.Format("\tDialed phone: {0}\n", callHistory[index].DialedPhone));
                calls.Append(string.Format("\tDuration: {0}\n", callHistory[index].Duration));
			}

            calls.Append(new string('*', Console.WindowWidth));

            return calls.ToString();
        }

        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = null;
            this.owner = null;
            this.battery = new Battery();
            this.display = new Display();
            this.callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, double price, string owner)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = new Battery();
            this.display = new Display();
            this.callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, double price, string owner, string batteryModel, int hoursIdle, int hoursTalk, BatteryType batteryType)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = new Battery(batteryModel, hoursIdle, hoursTalk, batteryType);
            this.display = new Display();
            this.callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, double price, string owner, string batteryModel, int hoursIdle, int hoursTalk, BatteryType batteryType, double size, long colors)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = new Battery(batteryModel, hoursIdle, hoursTalk, batteryType);
            this.display = new Display(size, colors);
            this.callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, double price, string owner, double size, long colors)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = new Battery();
            this.display = new Display(size, colors);
            this.callHistory = new List<Call>();
        }

        public override string ToString()
        {
            StringBuilder gsmInformation = new StringBuilder();

            gsmInformation.Append("\t\t\tMobile Phone Characteristics\n");
            gsmInformation.Append(new string('*', Console.WindowWidth));

            string phoneInformation = "Phone Information";
            gsmInformation.Append(phoneInformation);
            gsmInformation.Append(new string('-', Console.WindowWidth - phoneInformation.Length));
            gsmInformation.Append(string.Format("\tModel: {0}\n", this.model));
            gsmInformation.Append(string.Format("\tManufacturer: {0}\n", this.manufacturer));
            gsmInformation.Append(string.Format("\tPrice: {0}\n", this.price));
            gsmInformation.Append(string.Format("\tOwner: {0}\n", this.owner));
            gsmInformation.Append(new string('-', Console.WindowWidth) + "\n");

            string batteryInformation = "Battery Information";
            gsmInformation.Append(batteryInformation);
            gsmInformation.Append(new string('-', Console.WindowWidth - batteryInformation.Length));
            gsmInformation.Append(string.Format("\tModel: {0}\n", this.battery.Model));
            gsmInformation.Append(string.Format("\tType: {0}\n", this.battery.BatteryType));
            gsmInformation.Append(string.Format("\tHours idle: {0}\n", this.battery.HoursIdle));
            gsmInformation.Append(string.Format("\tHours talk: {0}\n", this.battery.HoursTalk));
            gsmInformation.Append(new string('-', Console.WindowWidth) + "\n");

            string displayInformation = "Display Information";
            gsmInformation.Append(displayInformation);
            gsmInformation.Append(new string('-', Console.WindowWidth - displayInformation.Length));
            gsmInformation.Append(string.Format("\tSize: {0}\n", this.display.Size));
            gsmInformation.Append(string.Format("\tColors: {0}\n", this.display.Colors));
            gsmInformation.Append(new string('-', Console.WindowWidth));

            gsmInformation.Append(new string('*', Console.WindowWidth));

            return gsmInformation.ToString();
        }

    }
}
