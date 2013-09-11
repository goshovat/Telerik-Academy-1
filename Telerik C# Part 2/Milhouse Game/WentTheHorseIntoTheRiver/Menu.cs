// -----------------------------------------------------------------------
// <copyright file="Menu.cs" company="Milhouse Game">
// TODO: Menu class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;

    /// <summary>
    /// TODO: Menu class
    /// </summary>
    public class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.TreatControlCAsInput = true;

            string[] title = 
            {
                                "@@@@        @@@@@  @@@@@@@@@@@@  @@@@@      @@@@  @@@@    @@@@",
                                "@@@@        @@@@@  @@@@@@@@@@@   @@@@@@     @@@@  @@@@    @@@@",
                                "@@@@@       @@@@@  @@@@          @@@@ @@    @@@@  @@@@    @@@@",
                                "@@@@@@     @@@@@@  @@@@@@@@      @@@@  @@   @@@@  @@@@    @@@@",
                                "@@@@ @@   @@@@@@@  @@@@@@@@      @@@@   @@  @@@@  @@@@    @@@@",
                                "@@@@  @@ @@ @@@@@  @@@@          @@@@    @@ @@@@  @@@@    @@@@",
                                "@@@@   @@@  @@@@@  @@@@@@@@@@@   @@@@     @@@@@@   @@@    @@@",
                                "@@@@    @   @@@@@  @@@@@@@@@@@@  @@@@      @@@@@    @@@@@@@@",
                                "                                                              ",  
                                "                                                              ", 
                                "    ,,,        ,,,       ,,,        ,,,      ,,,        ,,,    ",
                                "  __//*)     __//*)    __//*)     __//*)   __//*)     __//*)   ", 
                                "~(__)      ~(__)     ~(__)      ~(__)    ~(__)      ~(__)       ",  
                                "//  \\\\      \\\\//     //  \\\\      \\\\//    //  \\\\      \\\\//     "
            };

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < title.Length - 4; i++)
            {
                Console.SetCursorPosition(26, Console.CursorTop);
                Console.WriteLine(title[i]);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = title.Length - 4; i < title.Length; i++)
            {
                Console.SetCursorPosition(26, Console.CursorTop);
                Console.WriteLine(title[i]);
            }

            string[] menu = new string[] 
            { 
                "            PLAY\n\n\n\n", 
                "            HOW TO PLAY\n\n\n\n", 
                "            HIGH SCORES\n\n\n\n", 
                "            EXIT\n\n\n\n" 
            };

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(44, Console.CursorTop + 4);
            Console.Write(menu[0]);
            for (int i = 1; i < 4; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(44, Console.CursorTop);
                Console.Write(menu[i]);
            }

            PrintHorseInFront(42, 18);
            int row = 1;

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.DownArrow && row == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, 20);
                    Console.Write(menu[0]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[1]);

                    PrintHorseInFront(42, 22);
                    DeleteHorse(42, 18);
                    row++;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow && row == 2)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(44, 20);
                    Console.Write(menu[0]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[1]);

                    DeleteHorse(42, 22);
                    PrintHorseInFront(42, 18);
                    row--;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow && row == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, 20);
                    Console.Write(menu[0]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[1]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[2]);
                    PrintHorseInFront(42, 26);
                    DeleteHorse(42, 22);
                    row++;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow && row == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, 20);
                    Console.Write(menu[0]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[1]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[2]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[3]);
                    PrintHorseInFront(42, 30);
                    DeleteHorse(42, 26);
                    row++;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow && row == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, 20);
                    Console.Write(menu[0]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[1]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[2]);
                    DeleteHorse(42, 26);
                    PrintHorseInFront(42, 22);
                    row--;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow && row == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, 20);
                    Console.Write(menu[0]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[1]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[2]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(44, Console.CursorTop);
                    Console.Write(menu[3]);
                    DeleteHorse(42, 30);
                    PrintHorseInFront(42, 26);
                    row--;
                }
                else if (keyInfo.Key == ConsoleKey.Enter && row == 1)
                {
                    Start.EffectsWithPrinting();
                    Game.Play();
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.Enter && row == 2)
                {
                    Start.EffectsWithPrinting();
                    Hints.Hint();
                    ExitSelection();
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.Enter && row == 3)
                {
                    Start.EffectsWithPrinting();
                    HighScores myScore = new HighScores();
                    myScore.ShowHighScore();
                    ExitSelection();
                    return;
                }
                else if (keyInfo.Key == ConsoleKey.Enter && row == 4)
                {
                    Environment.Exit(0);
                }
            }
        }

        public static void ExitSelection()
        {
            ConsoleKeyInfo keyInfo;
            string exit = "Press \"Escape\" to return to the Menu!";

            Console.SetCursorPosition((Console.WindowWidth / 2) - ((exit.Length / 2) - 2), Console.WindowHeight - 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(exit);

            do
            {
                keyInfo = Console.ReadKey();
                Console.SetCursorPosition((Console.WindowWidth / 2) - ((exit.Length / 2) - 2), Console.WindowHeight - 10);
                Console.Write(exit);
            }
            while (keyInfo.Key != ConsoleKey.Escape);
        }

        private static void PrintHorseInFront(int left, int top)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left, top);
            Console.WriteLine("      ,,, ");
            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine("    __//*)");
            Console.SetCursorPosition(left, top + 2);
            Console.WriteLine("  ~(__)");
            Console.SetCursorPosition(left, top + 3);
            Console.WriteLine("  //  \\\\");
        }

        private static void DeleteHorse(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine("          ");
            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine("          ");
            Console.SetCursorPosition(left, top + 2);
            Console.WriteLine("       ");
            Console.SetCursorPosition(left, top + 3);
            Console.WriteLine("          ");
        }
    }
}