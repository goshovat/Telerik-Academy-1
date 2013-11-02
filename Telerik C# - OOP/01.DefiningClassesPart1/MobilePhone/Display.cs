namespace MobilePhone
{
    using System;
    using System.Linq;

    public  class Display
    {
        private double? size;

        public double? Size
        {
            get { return size; }
            set 
            {
                if (value <= 1 || value > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong double!!!");
                }
                else
                {
                    size = value;
                } 
            }
        }

        private long? colors;

        public long? Colors
        {
            get { return colors; }
            set 
            {
                if (value <= 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong color!!!");
                }
                else
                {
                    colors = value; 
                }
            }
        }

        public Display(double size, long colors)
        {
            this.size = size;
            this.colors = colors;
        }

        public Display()
        {
            this.size = null;
            this.colors = null;
        }
    }
}
