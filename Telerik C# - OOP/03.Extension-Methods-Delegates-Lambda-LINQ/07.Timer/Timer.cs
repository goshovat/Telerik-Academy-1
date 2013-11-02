namespace _07.Timer
{
    using System;
    using System.Linq;

    public delegate void Execute(Timer timer);
    public delegate void StarExecution(int milliSeconds, int stopSeconds);

    public class Timer
    {
        private long milliSeconds;

        public long MilliSeconds
        {
            get 
            { 
                return milliSeconds; 
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The milliseconds must be positive number !!!");
                }
                milliSeconds = value; 
            }
        }

        public Timer(long interval)
        {
            if (interval < 0)
            {
                throw new ArgumentOutOfRangeException("The interval must be positive number !!!");
            }
            this.milliSeconds = interval;
            Console.CursorVisible = false;
        }

        public static void PrintSeconds(Timer timer)
        {
            Console.SetCursorPosition(3, 3);
            Console.WriteLine(timer.milliSeconds / 1000.0);
            
        }

        public static void Starting(int interval, int stopMilliSeconds)
        {
            Timer timer = new Timer(interval);

            Execute execute = Timer.PrintSeconds;

            while (timer.MilliSeconds < stopMilliSeconds)
            {
                execute(timer);
                timer.MilliSeconds += interval;
                System.Threading.Thread.Sleep(interval);
            }
        }
    }
}
