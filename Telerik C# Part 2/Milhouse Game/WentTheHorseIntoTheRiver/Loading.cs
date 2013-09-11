// -----------------------------------------------------------------------
// <copyright file="Loading.cs" company="Milhouse Game">
// TODO: Loading class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Media;
    using System.Speech.Synthesis;
    using System.Threading;

    /// <summary>
    /// TODO: Loading class
    /// </summary>
    public class Loading
    {
        public static void RenderConsoleProgress(int percentage, char progressBarCharacter, ConsoleColor color, string message)
        {
            Console.CursorVisible = false;
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.CursorLeft = 0;
            int width = Console.WindowWidth - 37;
            int newWidth = (int)((width * percentage) / 100d);
            string progBar = new string(progressBarCharacter, newWidth) + new string(' ', width - newWidth);
            Console.Write("                                   {0}", progBar);
            if (string.IsNullOrEmpty(message))
            {
                message = string.Empty;
            }

            Console.CursorTop++;
            OverwriteConsoleMessage(message);
            Console.CursorTop--;
            Console.ForegroundColor = originalColor;
            Console.CursorVisible = true;
        }

        //// <summary>
        //// Print on screen Team Name, Game Name, Game Logo and Loading.
        //// </summary>
        public static void Screen()
        {
            StreamReader screen = new StreamReader(@"Screen.txt");
            try
            {
                using (screen)
                {
                    List<string> startScreen = new List<string>();
                    string reader = screen.ReadLine();
                    while (reader != null)
                    {
                        startScreen.Add(reader);
                        reader = screen.ReadLine();
                    }
                    ////Team Name
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\n\n\n\n\n\n\n\n\n");

                    for (int i = 0; i < 8; i++)
                    {
                        Console.WriteLine(startScreen[i]);
                    }

                    Console.WriteLine("\n\n\n\n\n\n\n\n\n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    for (int i = 62; i < 70; i++)
                    {
                        Console.WriteLine(startScreen[i]);
                    }

                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    synth.SetOutputToDefaultAudioDevice();
                    synth.Speak("Team Milhouse               presents               ");

                    Thread.Sleep(1500);
                    ////Game Name
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    for (int i = 8; i <= 20; i++)
                    {
                        Console.WriteLine(startScreen[i]);
                    }
                    ////Game Logo
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    for (int i = 21; i <= 40; i++)
                    {
                        Console.WriteLine(startScreen[i]);
                    }
                    ////Loading
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 40; i < 45; i++)
                    {
                        Console.WriteLine(startScreen[i]);
                    }

                    SoundPlayer simpleSound = new SoundPlayer("start.wav");
                    simpleSound.Play();

                    Console.WriteLine();
                }
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can't not find the loading screen file!!!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The path to the loading screen file is incorrect!!!");
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error with the loading screen file!!!");
            }
        }

        private static void OverwriteConsoleMessage(string message)
        {
            Console.CursorLeft = 0;
            int maxCharacterWidth = Console.WindowWidth - 37;
            if (message.Length > maxCharacterWidth)
            {
                message = message.Substring(0, maxCharacterWidth - 3) + "...";
            }

            message = message + new string(' ', maxCharacterWidth - message.Length);
            Console.Write("                                   {0}", message);
        }

        //private void RenderConsoleProgress(int percentage)
        //{
        //    RenderConsoleProgress(percentage, '\u2590', Console.ForegroundColor, string.Empty);
        //}
    }
}
