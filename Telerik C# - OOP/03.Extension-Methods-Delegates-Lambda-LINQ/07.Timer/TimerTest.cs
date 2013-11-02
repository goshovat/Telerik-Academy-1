namespace _07.Timer
{
    using System;
    using System.Linq;
    using System.Speech.Synthesis;

    // Using delegates write a class Timer that has can execute certain method at each t seconds.

    public class TimerTest
    {
        private static void showFinalMessage()
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

        static void Main(string[] args)
        {
            Console.Title = "Timer";

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Enter interval (in milliseconds) = ");
            int interval = int.Parse(Console.ReadLine());

            Console.Write("Enter stop milliseconds = ");
            int finishSeconds = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Cyan;

            StarExecution startExecution = Timer.Starting;
            startExecution(interval, finishSeconds);

            showFinalMessage();
        }
    }
}
