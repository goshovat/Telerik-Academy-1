// -----------------------------------------------------------------------
// <copyright file="Start.cs" company="Milhouse Game">
// TODO: Start class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Linq;
    using System.Media;
    using System.Threading;

    /// <summary>
    /// TODO: Start class
    /// </summary>
    public class Start
    {
        public static int ScreenWidth = 120;
        public static int ScreenHeight = 45;
        public static string NickName;
        
        public static void EffectsWithPrinting()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);

            for (int i = 0; i < ScreenHeight + 1; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine();
            }

            Console.Clear();
        }

        /*
        const int SWP_NOSIZE = 0x0001;
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr MyConsole = GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        

        private static void SetWindowResolution(int height, int width)
        private static void SetWindowResolution()
        {
            Console.Title = "WENT THE HORSE INTO THE RIVER";
            Console.BackgroundColor = ConsoleColor.Black;
            //Console.WindowHeight = height;
            //Console.WindowWidth = width;
            int width = Console.LargestWindowWidth;
            int height = Console.LargestWindowHeight;
            Console.SetWindowSize(width, height);
            Console.BufferWidth = width;
            Console.BufferHeight = height;
            //// Position the console to the center of the screen
            //// int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            //// int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            //// int consoleWidth = 980;
            //// int consoleHeight = 680;
            //// SetWindowPos(MyConsole, 0, screenWidth / 2 - consoleWidth / 2, screenHeight / 2 - consoleHeight / 2, 0, 0, SWP_NOSIZE);

            Console.CursorVisible = false;
        }
        */

        private static void SetWindowsResolution()
        {
            Console.SetWindowSize(ScreenWidth, ScreenHeight);
            Console.BufferWidth = ScreenWidth;
            Console.BufferHeight = ScreenHeight;
            Console.WindowWidth = ScreenWidth;
            Console.WindowHeight = ScreenHeight;
        }

        private static void Load()
        {
            Console.CursorVisible = false;
            
            Loading.Screen();
            
            for (int i = 1; i < 10000; i++)
            {
                int progress = i / 100;
                Loading.RenderConsoleProgress(progress / 2, '\u2592', ConsoleColor.Green, progress + 1 + " %");
            }

            Console.WriteLine();
        }

        private static void EnterNickName()
        {
            string message = "Enter your nickname: ";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((ScreenWidth / 2) - 21, Console.WindowHeight / 2);

            Console.Write(message);
            NickName = Console.ReadLine();
            Console.Clear();
        }

        private static void Main()
        {
            SetWindowsResolution();
            EnterNickName();
            Load();
            while (true)
            {
                EffectsWithPrinting();
                SoundPlayer menuSound = new SoundPlayer("menu.wav");
                menuSound.PlayLooping();
                Menu.Show();
            }
        }
    }
}
