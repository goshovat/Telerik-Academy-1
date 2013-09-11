// -----------------------------------------------------------------------
// <copyright file="HighScores.cs" company="Milhouse Game">
// TODO: HighScores class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    /// <summary>
    /// TODO: HighScores class
    /// </summary>
    public class HighScores
    {
        private static readonly int numberOfHighScores = 10;
        private static readonly int numberOfPoints = 6;
        private static readonly string filePath = @"scores.txt";
        private static List<string> currentScores;
        private static List<string> newScores;
        private static bool fileEmpty = true;
        
        private readonly string[] title = 
        {
                                "@@  @@ @@ @@@@@@ @@  @@     @@@@@@ @@@@@@ @@@@@@ @@@@@@ @@@@@@ @@@@@@",
                                "@@  @@ @@ @@  @@ @@  @@     @@  @@ @@  @@ @@  @@ @@  @@ @@     @@  @@",
                                "@@  @@ @@ @@     @@  @@     @@     @@     @@  @@ @@  @@ @@     @@    ",
                                "@@@@@@ @@ @@     @@@@@@     @@@@@@ @@     @@  @@ @@@@@@ @@@@@@ @@@@@@",
                                "@@  @@ @@ @@ @@@ @@  @@         @@ @@     @@  @@ @@     @@         @@",
                                "@@  @@ @@ @@  @@ @@  @@         @@ @@     @@  @@ @@@@   @@         @@",
                                "@@  @@ @@ @@  @@ @@  @@     @@  @@ @@  @@ @@  @@ @@ @@  @@     @@  @@",
                                "@@  @@ @@ @@@@@@ @@  @@     @@@@@@ @@@@@@ @@@@@@ @@  @@ @@@@@@ @@@@@@"
        };

        public HighScores()
        {
            ReadScore(filePath);
        }

        public void ShowHighScore()
        {
            if (fileEmpty)
            {
                for (int i = 0; i < this.title.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (this.title[0].Length / 2), 4 + i);
                    Console.Write(this.title[i]);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                string label = "N: | Points | Player name";
                Console.SetCursorPosition((Console.WindowWidth / 2) - (label.Length / 2), 20);
                Console.Write(label);
                Console.SetCursorPosition((Console.WindowWidth / 2) - (label.Length / 2), 21);
                Console.Write("---+--------+------------");
                int number = 1;
                foreach (var item in currentScores)
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (label.Length / 2), 21 + number);
                    Console.WriteLine("{0} | {1}", number.ToString().PadRight(2), item);
                    number++;
                }
            }
            else
            {
                Console.WriteLine("No results...");
            }
        }

        public bool CheckHighScore(int score)
        {
            if (fileEmpty)
            {
                foreach (var item in currentScores)
                {
                    if (score > Convert.ToInt32(item.Substring(0, numberOfPoints)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void AddScore(int playerScore, string playerName)
        {
            currentScores.Add(string.Format("{0} | {1}", playerScore.ToString().PadLeft(6, '0'), playerName));

            SortDesc();

            LimitScores();

            WriteScore(filePath);
        }

        private static void LimitScores()
        {
            if (newScores.Count > numberOfHighScores)
            {
                while (newScores.Count > numberOfHighScores)
                {
                    newScores.Remove(newScores.Last());
                }
            }
        }

        private static void SortDesc()
        {
            foreach (var item in currentScores.OrderByDescending(x => x))
            {
                newScores.Add(item);
            }
        }

        private static void ReadScore(string path)
        {
            StreamReader reader = new StreamReader(path, Encoding.GetEncoding("utf-8"));
            currentScores = new List<string>();
            newScores = new List<string>();

            try
            {
                using (reader)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        fileEmpty = false;
                        return;
                    }

                    line = reader.ReadLine();

                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            string valueToAdd = line.ToString().Substring(5);
                            currentScores.Add(valueToAdd);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can't not find the file with high scores!!!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The path to the file with high scores is incorrect!!!");
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error with the file with high scores!!!");
            }
        }

        private static void WriteScore(string path)
        {
            StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("utf-8"));
            using (writer)
            {
                int number = 1;
                currentScores.Clear();

                writer.WriteLine("N: | Points | Player name");
                writer.WriteLine("---+--------+--------------");

                foreach (var item in newScores)
                {
                    currentScores.Add(string.Format("{0} | {1}", item.ToString().Substring(0, 6), item.ToString().Substring(9)));
                    writer.WriteLine("{0} | {1} | {2}", number.ToString().PadRight(2), item.ToString().Substring(0, 6), item.ToString().Substring(9));
                    number++;
                }
            }
        }
    }
}