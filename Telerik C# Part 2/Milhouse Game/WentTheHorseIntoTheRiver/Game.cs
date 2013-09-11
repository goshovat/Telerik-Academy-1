// -----------------------------------------------------------------------
// <copyright file="Game.cs" company="Milhouse Game">
// TODO: Game class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Media;
    using System.Speech.Synthesis;
    using System.Threading;

    /// <summary>
    /// TODO: Game class
    /// </summary>
    public class Game
    {
        private static readonly SoundPlayer horseMove = new SoundPlayer("horse.wav");
        private static int columns;
        private static int rows;
        private static int points = 0;
        private static int bonus;
        private static Horse horse;
        private static Areas area;
        private static River river;
        private static Bridge bridge;
        private static List<Column> column;
        private static Clouds clouds;
        private static List<Shot> shot;
        private static List<Mouse> mouse;
        private static Random generator;

        public static void DrawHorse()
        {
            if (horse.Number == 0)
            {
                horse.Number = 1;
                for (int y = horse.PositionY, part = 0; y < horse.PositionY + 4; y++, part++)
                {
                    PrintAtPosition(0, y, horse.GetHorse[part], ConsoleColor.Yellow, ConsoleColor.Black);
                }
            }
            else if (horse.Number == 1)
            {
                horse.Number = 2;
                for (int y = horse.PositionY, part = 0; y < horse.PositionY + 4; y++, part++)
                {
                    PrintAtPosition(0, y, horse.GetHorse[part], ConsoleColor.Yellow, ConsoleColor.Black);
                }
            }
            else
            {
                horse.Number = 0;
                for (int y = horse.PositionY, part = 0; y < horse.PositionY + 4; y++, part++)
                {
                    PrintAtPosition(0, y, horse.GetHorse[part], ConsoleColor.Yellow, ConsoleColor.Black);
                }
            }
        }

        public static void PrintAtPosition(int x, int y, string part, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.SetCursorPosition(x, y);
            Console.Write(part);
        }

        public static void ClearArea()
        {
            for (int index = 0; index < area.Elements.Count; index++)
            {
                if (area.Elements[index].PreviousPositionX > -1 && area.Elements[index].PreviousPositionX + area.Elements[index].Element[0].Length - 1 < columns)
                {
                    for (int part = 0; part < area.Elements[index].Element.Length; part++)
                    {
                        PrintAtPosition(area.Elements[index].PreviousPositionX + area.Elements[index].Element[part].Length - 1, area.Elements[index].PositionY + part, " ", ConsoleColor.Black, ConsoleColor.Black);
                    }
                }
            }
        }

        public static void Play()
        {
            GetInitialValues();

            PrintRow();
            DrawUpWallOfTheBridge();
            DrawDownWallOfTheBridge();
            PrintMessage();

            horseMove.PlayLooping();

            int currentPoint = points;

            while (true)
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        horse.MoveUp(area.PositionY);
                        ClearHorse();
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        horse.MoveDown(area.PositionY, area.Height);
                        ClearHorse();
                    }
                    else if (keyInfo.Key == ConsoleKey.E)
                    {
                        if (area.CheckForExit(bonus, horse.Height))
                        {
                            int position = area.Elements[area.Elements.Count - 1].PositionX - 2;
                            if (position < columns - 4)
                            {
                                for (int part = 0; part < horse.Height; part++)
                                {
                                    PrintAtPosition(position, area.Elements[area.Elements.Count - 1].PositionY - part - 1, "    ", ConsoleColor.Black, ConsoleColor.Black);
                                }
                            }
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        shot.Add(new Shot(horse.Width, horse.PositionY + 1));
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Pause();
                    }
                }

                CreateMouse();

                MoveColumn();
                CreateColumn();
                RemoveMouseAndShot();
                MoveShot();
                MoveMouse();
                area.Move();
                clouds.Move();
                river.Move();
                CountPoints();

                if (CheckForEndOfLevel())
                {
                    horseMove.Stop();
                    DrawRiver();
                    DrawColumn();
                    DrawHorse();
                    DrawLevelUp();

                    if (area.CheckForArea())
                    {
                        SoundPlayer gameFinishSound = new SoundPlayer("applause.wav");
                        gameFinishSound.Play();
                        Thread.Sleep(2000);
                        DrawGameFinish();
                        break;
                    }

                    GetNewLevel();
                    horseMove.PlayLooping();
                }

                PrintResult();
                PrintBonus();
                DrawClouds();
                ClearArea();
                CheckElement();
                ClearShot();
                DrawShot();
                ClearMouse();
                DrawMouse();
                DrawArea();
                DrawRiver();
                ClearColumns();
                DrawColumn();

                if (CheckForAccident())
                {
                    horseMove.Stop();
                    DrawWentTheHorseIntoTheRiver();
                    GameOver();
                    break;
                }
                else
                {
                    DrawHorse();
                }

                Thread.Sleep(45);
            }
        }
        
        private static void GetInitialValues()
        {
            Console.Clear();
            columns = Console.WindowWidth;
            rows = Console.WindowHeight;
            horse = new Horse(0, (rows / 2) - 1);
            area = new Areas(columns - 1, 15);
            river = new River((rows - area.PositionY - area.Height) - 5, columns, 0, (area.PositionY + area.Height) + 4);
            bridge = new Bridge(columns, 0, area.PositionY - 3, area.PositionY + area.Height);
            column = new List<Column>();
            column.Add(new Column(columns / 4, bridge.DownWallPositionY + Bridge.Height));
            column.Add(new Column(columns - (columns / 4) - 1, bridge.DownWallPositionY + Bridge.Height));
            clouds = new Clouds(0, bridge.UpWallPositionY - 6);
            bonus = 0;
            shot = new List<Shot>();
            mouse = new List<Mouse>();
            generator = new Random();
        }      

        private static void PrintBonus()
        {
            PrintAtPosition(2, 1, string.Format("Bonus = {0}", bonus), ConsoleColor.White, ConsoleColor.DarkMagenta);
        }

        private static void PrintResult()
        {
            PrintAtPosition((columns / 2) - 10, 1, string.Format("Points = {0:000000}", points), ConsoleColor.White, ConsoleColor.DarkMagenta);
        }

        private static void PrintMessage()
        {
            string message = string.Format("\"Esc\" = pause");
            PrintAtPosition(columns - message.Length - 2, 1, message, ConsoleColor.White, ConsoleColor.DarkMagenta);
        }

        private static void PrintRow()
        {
            PrintAtPosition(0, 0, new string(' ', columns), ConsoleColor.Black, ConsoleColor.DarkMagenta);
            PrintAtPosition(0, 1, new string(' ', columns), ConsoleColor.Black, ConsoleColor.DarkMagenta);
            PrintAtPosition(0, 2, new string(' ', columns), ConsoleColor.Black, ConsoleColor.DarkMagenta);
        }

        private static void DrawArea()
        {
            for (int index = 0; index < area.Elements.Count; index++)
            {
                if (area.Elements[index].PositionX > -1 && area.Elements[index].PositionX < columns - 1)
                {
                    for (int part = 0; part < area.Elements[index].Element.Length; part++)
                    {
                        PrintAtPosition(area.Elements[index].PositionX, area.Elements[index].PositionY + part, area.Elements[index].Element[part], ConsoleColor.Red, ConsoleColor.Black);
                    }
                }
            }
        }

        private static void ClearHorse()
        {
            if (horse.PreviousPositionY > horse.PositionY)
            {
                PrintAtPosition(0, horse.PreviousPositionY + horse.Height - 1, horse.GetHorse[horse.Height - 1], ConsoleColor.Black, ConsoleColor.Black);
            }
            else
            {
                PrintAtPosition(0, horse.PreviousPositionY, horse.GetHorse[0], ConsoleColor.Black, ConsoleColor.Black);
            }
        }

        private static void ClearShot()
        {
            for (int i = 0; i < shot.Count; i++)
            {
                PrintAtPosition(shot[i].PreviousPositionX, shot[i].PositionY, shot[i].GetShot.ToString(), ConsoleColor.Black, ConsoleColor.Black);
            }
        }

        private static void ClearMouse()
        {
            for (int index = 0; index < mouse.Count; index++)
            {
                if (mouse[index].PreviousPositionX + mouse[index].GetMouse[0].Length - 2 < columns)
                {
                    for (int part = 0; part < Mouse.Height(); part++)
                    {
                        PrintAtPosition(mouse[index].PreviousPositionX + mouse[index].GetMouse[part].Length - 2, mouse[index].PositionY + part, "  ", ConsoleColor.Black, ConsoleColor.Black);
                    }
                }
            }
        }

        private static void ClearColumns()
        {
            string blackRow = new string(' ', columns - 1);

            PrintAtPosition(0, column[0].PositionY, blackRow, ConsoleColor.Black, ConsoleColor.Black);
        }

        private static bool CheckForEndOfLevel()
        {
            if (Math.Abs(area.PositionX) == area.Width - 1)
            {
                return true;
            }

            return false;
        }

        private static void DrawUpWallOfTheBridge()
        {
            for (int part = 0; part < Bridge.Height; part++)
            {
                PrintAtPosition(bridge.UpWallPositionX, bridge.UpWallPositionY + part, bridge.UpWall[part], ConsoleColor.DarkMagenta, ConsoleColor.Black);
            }
        }

        private static void DrawDownWallOfTheBridge()
        {
            for (int part = 0; part < Bridge.Height; part++)
            {
                PrintAtPosition(bridge.DownWallPositionX, bridge.DownWallPositionY + part, bridge.DownWall[part], ConsoleColor.Magenta, ConsoleColor.Black);
            }
        }

        private static void DrawRiver()
        {
            for (int index = 0; index < River.Height; index++)
            {
                PrintAtPosition(river.PositionX, river.PositionY + index, river.GetRiver[index], ConsoleColor.Cyan, ConsoleColor.Black);
            }
        }

        /*
        static void DrawLine()
        {
            PrintAtPosition(0, 2, new string('_', columns), ConsoleColor.White, ConsoleColor.Black);
        }
        g*/

        private static void DrawClouds()
        {
            for (int part = 0; part < Clouds.Height; part++)
            {
                PrintAtPosition(clouds.PositionX, clouds.PositionY + part, clouds.GetCloud[part], ConsoleColor.Blue, ConsoleColor.Black);
            }
        }

        private static void DrawShot()
        {
            CheckShot();
            for (int i = 0; i < shot.Count; i++)
            {
                PrintAtPosition(shot[i].PositionX, shot[i].PositionY, shot[i].GetShot.ToString(), ConsoleColor.Magenta, ConsoleColor.Black);
            }
        }

        private static void CheckShot()
        {
            for (int index = 0; index < shot.Count; index++)
            {
                if (shot[index].PositionX == columns)
                {
                    shot.RemoveAt(index);
                    index--;
                }
            }
        }

        private static void MoveShot()
        {
            for (int i = 0; i < shot.Count; i++)
            {
                shot[i].PreviousPositionX = shot[i].PositionX;
                shot[i].PositionX++;
            }
        }

        private static bool CheckForAccident()
        {
            bool smash = false;

            for (int index = 0; index < mouse.Count; index++)
            {
                if (mouse[index].PositionX <= horse.Width)
                {
                    if (mouse[index].PositionY + Mouse.Height() - 1 >= horse.PositionY && mouse[index].PositionY < horse.PositionY + horse.Height)
                    {
                        smash = true;
                        return smash;
                    }
                }
                else
                {
                    break;
                }
            }

            if (area.PositionX >= 0 && area.PositionX < horse.Width)
            {
                for (int heightIndex = horse.PositionY - area.PositionY, rowIndex = 0; rowIndex < horse.Height; heightIndex++, rowIndex++)
                {
                    for (int widthIndex = 0, colIndex = area.PositionX; colIndex < horse.Width; widthIndex++, colIndex++)
                    {
                        if (horse.GetHorse[rowIndex][colIndex] != ' ' && area.GetArea[heightIndex][widthIndex] == '@')
                        {
                            area.RemoveBonus(heightIndex, widthIndex);
                            bonus++;
                        }
                        else if (horse.GetHorse[rowIndex][colIndex] != ' ' && area.GetArea[heightIndex][widthIndex] != ' ')
                        {
                            smash = true;
                            return smash;
                        }
                    }
                }
            }
            else if (area.PositionX < 0)
            {
                for (int heightIndex = horse.PositionY - area.PositionY, rowIndex = 0; rowIndex < horse.Height; heightIndex++, rowIndex++)
                {
                    for (int widthIndex = Math.Abs(area.PositionX), colIndex = 0; colIndex < horse.Width; widthIndex++, colIndex++)
                    {
                        if (widthIndex < area.GetArea[0].Length)
                        {
                            if (horse.GetHorse[rowIndex][colIndex] != ' ' && area.GetArea[heightIndex][widthIndex] == '@')
                            {
                                area.RemoveBonus(heightIndex, widthIndex);
                                points += 100;
                                bonus++;
                            }
                            else if (horse.GetHorse[rowIndex][colIndex] != ' ' && area.GetArea[heightIndex][widthIndex] != ' ')
                            {
                                smash = true;
                                return smash;
                            }
                        }
                    }
                }
            }

            return smash;
        }

        private static void DrawWentTheHorseIntoTheRiver()
        {
            PrintRow();
            PrintBonus();
            PrintResult();
            PrintMessage();
            DrawClouds();
            DrawUpWallOfTheBridge();

            while (horse.PositionY != column[0].PositionY + Column.Height + 1)
            {
                int difference = horse.PositionY + horse.Height - column[0].PositionY - Column.Height;
                ClearHorse();
                DrawArea();
                DrawDownWallOfTheBridge();
                DrawMouse();
                DrawShot();

                DrawRiver();
                ClearColumns();
                DrawColumn();

                if (difference < 0)
                {
                    for (int y = horse.PositionY, part = 0; y < horse.PositionY + horse.Height; y++, part++)
                    {
                        horse.Number = horse.Height - 1;
                        PrintAtPosition(0, y, horse.GetHorse[part], ConsoleColor.White, ConsoleColor.Black);
                    }
                }
                else
                {
                    SoundPlayer horseMove = new SoundPlayer("jump.wav");
                    horseMove.Play();
                    for (int y = horse.PositionY, part = 0; y < horse.PositionY + horse.Height - difference; y++, part++)
                    {
                        horse.Number = horse.Height - 1;
                        PrintAtPosition(0, y, horse.GetHorse[part], ConsoleColor.White, ConsoleColor.Black);
                    }
                }

                horse.PreviousPositionY = horse.PositionY;
                horse.PositionY++;
                Thread.Sleep(100);
            }

            Thread.Sleep(1000);
        }

        private static void CreateMouse()
        {
            int choice = generator.Next(20);

            if (choice == 1)
            {
                int positionY = generator.Next(area.Height - Mouse.Height() - 2) + area.PositionY;
                mouse.Add(new Mouse(columns - 1, positionY));
            }
        }

        private static void MoveMouse()
        {
            for (int index = 0; index < mouse.Count; index++)
            {
                mouse[index].PreviousPositionX = mouse[index].PositionX;
                mouse[index].PositionX -= 2;
            }
        }

        private static void DrawMouse()
        {
            CheckMouse();
            for (int index = 0; index < mouse.Count; index++)
            {
                for (int part = 0; part < Mouse.Height(); part++)
                {
                    PrintAtPosition(mouse[index].PositionX, mouse[index].PositionY + part, mouse[index].GetMouse[part], ConsoleColor.Gray, ConsoleColor.Black);
                }
            }
        }

        private static void CheckMouse()
        {
            for (int index = 0; index < mouse.Count; index++)
            {
                if (mouse[index].PositionX == 0 || mouse[index].PositionX == -1)
                {
                    for (int part = 0; part < mouse[index].GetMouse.Length; part++)
                    {
                        PrintAtPosition(mouse[index].PositionX + 1, mouse[index].PositionY + part, mouse[index].GetMouse[part], ConsoleColor.Black, ConsoleColor.Black);
                    }

                    mouse.RemoveAt(index);
                    index--;
                    points += 7;
                }
            }
        }

        private static void RemoveMouseAndShot()
        {
            for (int shotIndex = 0; shotIndex < shot.Count; shotIndex++)
            {
                for (int mouseIndex = 0; mouseIndex < mouse.Count; mouseIndex++)
                {
                    if ((shot[shotIndex].PositionX >= mouse[mouseIndex].PositionX && shot[shotIndex].PositionX <= mouse[mouseIndex].PositionX + Mouse.Width()) &&
                        (shot[shotIndex].PositionY >= mouse[mouseIndex].PositionY && shot[shotIndex].PositionY <= mouse[mouseIndex].PositionY + Mouse.Height()))
                    {
                        mouse[mouseIndex].PreviousPositionX = mouse[mouseIndex].PositionX;
                        shot[shotIndex].PreviousPositionX = shot[shotIndex].PositionX;

                        for (int part = 0; part < mouse[mouseIndex].GetMouse.Length; part++)
                        {
                            PrintAtPosition(mouse[mouseIndex].PositionX, mouse[mouseIndex].PositionY + part, mouse[mouseIndex].GetMouse[part], ConsoleColor.Black, ConsoleColor.Black);
                        }

                        PrintAtPosition(shot[shotIndex].PositionX, shot[shotIndex].PositionY, shot[shotIndex].GetShot.ToString(), ConsoleColor.Black, ConsoleColor.Black);

                        shot.RemoveAt(shotIndex);
                        mouse.RemoveAt(mouseIndex);
                        shotIndex--;
                        points += 10;
                        break;
                    }
                }
            }
        }

        private static void CreateColumn()
        {
            CheckColumn();

            if (column.Count < 2)
            {
                column.Add(new Column(columns - Column.Width - 1, bridge.DownWallPositionY + Bridge.Height));
            }
        }

        private static void CheckColumn()
        {
            if (column[0].PositionX == -1)
            {
                column.RemoveAt(0);
            }
        }

        private static void MoveColumn()
        {
            for (int index = 0; index < column.Count; index++)
            {
                column[index].Move();
            }
        }

        private static void DrawColumn()
        {
            for (int index = 0; index < column.Count; index++)
            {
                for (int part = 0; part < Column.Height; part++)
                {
                    PrintAtPosition(column[index].PositionX, column[index].PositionY + part, column[index].GetColumn[part], ConsoleColor.Magenta, ConsoleColor.Black);
                }
            }
        }

        private static void CheckElement()
        {
            for (int index = 0; index < area.Elements.Count; index++)
            {
                if (area.Elements[index].PositionX == -1)
                {
                    for (int part = 0; part < area.Elements[index].Element.Length; part++)
                    {
                        PrintAtPosition(area.Elements[index].PositionX + 1, area.Elements[index].PositionY + part, area.Elements[index].Element[part], ConsoleColor.Black, ConsoleColor.Black);
                    }

                    area.Elements.RemoveAt(index);
                    index--;
                }
            }
        }

        private static void CountPoints()
        {
            if (area.PositionX < 0)
            {
                for (int index = 0; index < area.Height; index++)
                {
                    if (area.GetArea[index][Math.Abs(area.PositionX)] != ' ')
                    {
                        points++;
                    }
                }
            }
        }

        private static void GetNewLevel()
        {
            area.PositionX = columns - 1;
            area.GetElements();
            bonus = 0;
        }

        private static void Pause()
        {
            ConsoleKeyInfo keyInfo;
            string pause = "Press \"Escape\" to unpause the game!";
            PrintAtPosition(columns / 2 - pause.Length / 2, rows / 2, pause, ConsoleColor.Cyan, ConsoleColor.Black);
            horseMove.Stop();
            do
            {
                keyInfo = Console.ReadKey();
                PrintAtPosition((columns / 2) - (pause.Length / 2), rows / 2, pause, ConsoleColor.Cyan, ConsoleColor.Black);
            } 
            while (keyInfo.Key != ConsoleKey.Escape);

            horseMove.PlayLooping();
        }

        private static void DrawLevelUp()
        {
            string message = string.Format("You finished level: \"{0}\"", area.Name);
            PrintAtPosition(columns / 2 - message.Length / 2, rows / 2, message, ConsoleColor.Yellow, ConsoleColor.Black);

            // Initialize a new instance of the SpeechSynthesizer.
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output. 
            synth.SetOutputToDefaultAudioDevice();

            // Speak a string.
            synth.Speak(string.Format("You finished level: \"{0}\"", area.Name));

            area.Number++;
            Thread.Sleep(1000);
        }

        private static void DrawGameFinish()
        {
            string message = string.Format("Congratulations! You completed The GAME !");
            PrintAtPosition(columns / 2 - message.Length / 2, rows / 2, message, ConsoleColor.Yellow, ConsoleColor.Black);

            // Initialize a new instance of the SpeechSynthesizer.
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output. 
            synth.SetOutputToDefaultAudioDevice();

            // Speak a string.
            synth.Speak(string.Format("Congratulations! You completed The GAME !"));

            Thread.Sleep(1000);

            HighScores score = new HighScores();

            if (score.CheckHighScore(points))
            {
                string highScore = "You make a highscore!";
                PrintAtPosition(columns / 2 - highScore.Length / 2, rows / 2 + 1, highScore, ConsoleColor.White, ConsoleColor.DarkMagenta);
                score.AddScore(points, Start.NickName);
                synth.Speak("You make a highscore!");
                Console.BackgroundColor = ConsoleColor.Black;
                Thread.Sleep(2000);

                Start.EffectsWithPrinting();
                
                HighScores myScore = new HighScores();

                myScore.ShowHighScore();
                Menu.ExitSelection();
            }

            Console.BackgroundColor = ConsoleColor.Black;
            points = 0;
        }

        private static void GameOver()
        {
            string gameOver = "GAME OVER!";
            string printPoint = string.Format("You won {0} points.", points);
            PrintAtPosition(columns / 2 - gameOver.Length / 2, rows / 2, gameOver, ConsoleColor.Black, ConsoleColor.Yellow);
            PrintAtPosition(columns / 2 - printPoint.Length / 2, rows / 2 + 1, printPoint, ConsoleColor.Black, ConsoleColor.Yellow);

            // Initialize a new instance of the SpeechSynthesizer.
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output. 
            synth.SetOutputToDefaultAudioDevice();

            // Speak a string.
            synth.Speak(string.Format("Game Over! You won {0} points.", points));

            Thread.Sleep(1000);

            HighScores score = new HighScores();

            if (score.CheckHighScore(points))
            {
                string highScore = "You make a highscore!";
                PrintAtPosition(columns / 2 - highScore.Length / 2, rows / 2 + 2, highScore, ConsoleColor.White, ConsoleColor.DarkMagenta);
                score.AddScore(points, Start.NickName);
                synth.Speak("You make a highscore!");
                Console.BackgroundColor = ConsoleColor.Black;
                Thread.Sleep(2000);

                Start.EffectsWithPrinting();
                HighScores myScore = new HighScores();
                myScore.ShowHighScore();
                Menu.ExitSelection();
            }

            Console.BackgroundColor = ConsoleColor.Black;
            points = 0;
        }
    }
}
