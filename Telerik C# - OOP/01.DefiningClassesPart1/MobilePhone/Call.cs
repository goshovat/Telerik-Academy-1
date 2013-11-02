namespace MobilePhone
{
    /*
       8.Create a class Call to hold a call performed through a GSM. It should contain date, time, dialed phone number and duration (in seconds).
    */
    using System;
    using System.Linq;

    public class Call
    {
        private DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        private string dialedPhone;

        public string DialedPhone
        {
            get { return dialedPhone; }
            set { dialedPhone = value; }
        }
        private int duration;

        public int Duration
        {
            get { return duration; }
            set 
            {
                if (value <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong duration!!!");
                }
                else
	            {
                    duration = value; 
	            }
            }
        }

        public Call(DateTime dateTime, string dialedPhone, int duration)
        {
            this.dateTime = dateTime;
            this.dialedPhone = dialedPhone;
            this.duration = duration;
        }
    }
}
