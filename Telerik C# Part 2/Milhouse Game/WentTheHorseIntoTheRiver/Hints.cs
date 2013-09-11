// -----------------------------------------------------------------------
// <copyright file="Hints.cs" company="Milhouse Game">
// TODO: Hints class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// TODO: Hints class
    /// </summary>
    public class Hints
    {
        public static void Hint()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Hints.HowToPlay();
        }

        private static void HowToPlay()
        {
            Hints.DrawHintsOnConsole();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(string.Concat(new object[] 
            {
                " ",
                '↑',
                "\n ",
                '↓'
            }));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  You move with the arrows.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" []\n []");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  Do not touch it.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" []\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" <'");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('@');
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("'> Colect this, it is a bouns.\n");
            Console.Write(" You fire missiles <'");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write('o');
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("'> with Space bar.\n");
            Console.Write(" You can open the door at the end of the map with <'");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('E');
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("'>,\n if you got the same number of bonuses like the number of the current level.\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("       ,,, \n     __//*)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   This is you");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n   ~(__)   \n   //  \\\\  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("   ,,\n   <>~");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   Kill those sons of a bitch(mice) with missiles.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n   ''");
            Console.ForegroundColor = ConsoleColor.White;
            Hints.DrawPointsOnConsole();
            Console.WriteLine(" Collect bonus give you a HUNDRED points.");
            Console.WriteLine(" Killing mouse give you TEN points.");
            Console.WriteLine(" Every element from the area that move behind you, give you ONE point.");
        }

        //private static void GoToMenu()
        //{
        //    Console.WriteLine("\n\n To go back to press Escape.");
        //    while (Console.ReadKey().Key != ConsoleKey.Escape)
        //    {
        //        Console.SetCursorPosition(0, Console.CursorTop);
        //        Console.Write(' ');
        //        Console.SetCursorPosition(0, Console.CursorTop);
        //    }

        //    Menu.Show();
        //}

        private static void DrawHintsOnConsole()
        {
            StreamReader streamReader = new StreamReader("Screen.txt");
            using (streamReader)
            {
                List<string> list = new List<string>();
                for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
                {
                    list.Add(text);
                }
                
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 46; i < 53; i++)
                {
                    Console.WriteLine(list[i]);
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void DrawPointsOnConsole()
        {
            StreamReader streamReader = new StreamReader("Screen.txt");
            using (streamReader)
            {
                List<string> list = new List<string>();
                for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
                {
                    list.Add(text);
                }

                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 54; i < 61; i++)
                {
                    Console.WriteLine(list[i]);
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //private static void EffectsWithPrinting()
        //{
        //    for (int i = 0; i < 51; i++)
        //    {
        //        Thread.Sleep(15);
        //        Console.WriteLine();
        //    }

        //    Console.Clear();
        //}
    }
}
