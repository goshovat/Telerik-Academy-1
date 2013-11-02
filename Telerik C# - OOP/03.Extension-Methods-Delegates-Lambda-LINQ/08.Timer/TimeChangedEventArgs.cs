namespace _08.Timer
{
    using System;
    using System.Linq;

    public delegate void TimeChangedEventHandler(object sender, TimeChangedEventArgs eventArgs);

    public class TimeChangedEventArgs : EventArgs
    {
        private int currentSeconds;

        public TimeChangedEventArgs(int currentSeconds)
        {
            this.currentSeconds = currentSeconds;
        }

        public int CurrentSeconds
        {
            get { return this.currentSeconds; }
        }
    }
}
