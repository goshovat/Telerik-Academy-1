namespace _08.Timer
{
    using System;
    using System.Linq;
    using System.Speech.Synthesis;

    /*
        Using delegates write a class Timer that has can execute certain method at each t seconds.
        Read in MSDN about the keyword event in C# and how to publish events. Re-implement the above 
        using .NET events and following the best practices.
    */

    public class TimerTest
    {
        public class TimerDemo
        {
            private static void Timer_TimeChanged(object sender, TimeChangedEventArgs eventArgs)
            {
                Console.SetCursorPosition(3, 3);
                Console.WriteLine(eventArgs.CurrentSeconds / 1000.0);
            }

            private static void ShowFinalMessage()
            {
                string message = "-----> Time is up <-----";

                Console.Clear();
                Console.Beep();

                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2);

                Console.WriteLine(message);

                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SetOutputToDefaultAudioDevice();
                synth.Speak("Time is up");

                Console.ResetColor();
            }

            public static void Main()
            {
                Console.Title = "Timer";

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write("Enter interval (in milliseconds) = ");
                int interval = int.Parse(Console.ReadLine());

                Console.Write("Enter stop milliseconds = ");
                int finishSeconds = int.Parse(Console.ReadLine());

                Timer timer = new Timer(interval, finishSeconds);
                timer.TimeChanged += new TimeChangedEventHandler(Timer_TimeChanged);

                Console.ForegroundColor = ConsoleColor.Cyan;

                timer.Run();

                ShowFinalMessage();
            }
        }
    }
}
