namespace _08.Timer
{
    using System;
    using System.Linq;

    public class Timer
    {
        private int milliSeconds;
        private int interval;
        private int stopMilliSeconds;

        // The event that will be raised when the time changes
        public event TimeChangedEventHandler TimeChanged;

        public Timer(int interval, int stopMilliSeconds)
        {
            Console.CursorVisible = false;
            if (interval < 0)
            {
                throw new ArgumentOutOfRangeException("The interval must be positive number !!!");
            }
            this.milliSeconds = interval;
            this.stopMilliSeconds = stopMilliSeconds;
            this.interval = interval;
        }

        public int MilliSeconds
        {
            get
            {
                return milliSeconds;
            }
        }

        public int Interval
        {
            get
            {
                return interval;
            }
        }

        public int StopMilliSeconds
        {
            get
            {
                return stopMilliSeconds;
            }
        }

        // The method that invokes the event
        protected void OnTimeChanged(int aTick)
        {
            if (TimeChanged != null)
            {
                TimeChangedEventArgs args =
                new TimeChangedEventArgs(aTick);
                TimeChanged(this, args);
            }
        }

        public void Run()
        {
            while (milliSeconds < stopMilliSeconds)
            {
                System.Threading.Thread.Sleep(interval);
                OnTimeChanged(milliSeconds);
                milliSeconds += interval;
            }
        }
    }
}