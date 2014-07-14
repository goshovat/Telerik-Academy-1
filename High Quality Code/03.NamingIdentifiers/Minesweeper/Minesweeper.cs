namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Game
    {
        private const int BoardRows = 5;
        private const int BoardColumns = 10;
        private const int Mines = 15;
        private const int MaxScore = 35;
        private const int TopResultsToKeep = 6;

        private static Random randomNumbersGenerator = new Random();

        private static void PrintHelp()
        {
            Console.WriteLine(
                "Lel's play MINESWEEPER.\n" +
                "Try to clear the minefield without detonating a mine.\nCommands:\n" +
                "\t- \"<row> <column>\": marks the space by entering its coordinates;\n" +
                "\t- \"top\": shows the top results;\n" +
                "\t- \"restart\": starts a new game;\n" +
                "\t- \"exit\": exits the application.\n");
        }

        private static char[,] InitGround(int rows, int cols, char cellCharacter)
        {
            char[,] ground = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    ground[row, col] = cellCharacter;
                }
            }

            return ground;
        }

        private static char[,] CreateBoard(int rows, int cols)
        {
            char[,] board = InitGround(rows, cols, '?');
            return board;
        }

        private static char[,] CreateMineField(int rows, int cols, int mines)
        {
            char[,] mineField = InitGround(rows, cols, '-');

            List<int> randomNumbers = new List<int>();

            while (randomNumbers.Count < mines)
            {
                int number = randomNumbersGenerator.Next(rows * cols);
                if (!randomNumbers.Contains(number))
                {
                    randomNumbers.Add(number);
                }
            }

            foreach (int number in randomNumbers)
            {
                int row = number / cols;
                int col = number % cols;
                mineField[row, col] = '*';
            }

            return mineField;
        }

        private static void PrintBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            StringBuilder colNumbersBuilder = new StringBuilder();
            StringBuilder dashedLineBuilder = new StringBuilder();
            for (int col = 0; col < cols; col++)
            {
                colNumbersBuilder.AppendFormat(" {0}", col);
                if (col < 10)
                {
                    dashedLineBuilder.Append("--");
                }
                else
                {
                    dashedLineBuilder.Append("---");
                }
            }

            dashedLineBuilder.Append("-");

            Console.WriteLine("\t\t\t{0}", colNumbersBuilder);
            Console.WriteLine("\t\t\t{0}", dashedLineBuilder);

            for (int row = 0; row < rows; row++)
            {
                Console.Write("\t\t     {0} | ", row);

                for (int col = 0; col < cols; col++)
                {
                    if (col < 10)
                    {
                        Console.Write("{0} ", board[row, col]);
                    }
                    else
                    {
                        Console.Write(" {0} ", board[row, col]);
                    }
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("\t\t\t{0}\n", dashedLineBuilder);
        }

        private static char CountAdjacentMines(char[,] mineField, int row, int col)
        {
            int adjacentMines = 0;
            int rows = mineField.GetLength(0);
            int cols = mineField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (mineField[row - 1, col] == '*')
                {
                    adjacentMines++;
                }
            }

            if (row + 1 < rows)
            {
                if (mineField[row + 1, col] == '*')
                {
                    adjacentMines++;
                }
            }

            if (col - 1 >= 0)
            {
                if (mineField[row, col - 1] == '*')
                {
                    adjacentMines++;
                }
            }

            if (col + 1 < cols)
            {
                if (mineField[row, col + 1] == '*')
                {
                    adjacentMines++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (mineField[row - 1, col - 1] == '*')
                {
                    adjacentMines++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (mineField[row - 1, col + 1] == '*')
                {
                    adjacentMines++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (mineField[row + 1, col - 1] == '*')
                {
                    adjacentMines++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (mineField[row + 1, col + 1] == '*')
                {
                    adjacentMines++;
                }
            }

            return char.Parse(adjacentMines.ToString());
        }

        private static void UpdateBoardPoint(char[,] board, char[,] mineField, int row, int col)
        {
            char adjacentMinesCount = CountAdjacentMines(mineField, row, col);
            board[row, col] = adjacentMinesCount;
            mineField[row, col] = adjacentMinesCount;
        }

        private static void PrintTopResults(List<Result> results)
        {
            Console.WriteLine("\nTop results:");

            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, results[i].Name, results[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The results list is empty!\n");
            }
        }

        private static void Main()
        {
            char[,] board = CreateBoard(BoardRows, BoardColumns);
            char[,] mineField = CreateMineField(BoardRows, BoardColumns, Mines);

            int row = 0;
            int col = 0;
            int score = 0;
            bool starting = true;
            bool explosion = false;
            bool hasReachedMaxScore = false;

            string command = string.Empty;
            List<Result> topResults = new List<Result>(TopResultsToKeep);

            do
            {
                if (starting)
                {
                    PrintHelp();
                    PrintBoard(board);
                    starting = false;
                }

                Console.Write("Row and column: ");
                command = Console.ReadLine().Trim();
                string[] coordinates = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (coordinates.Length == 2)
                {
                    if (int.TryParse(coordinates[0], out row) &&
                        int.TryParse(coordinates[1], out col) &&
                        row <= board.GetLength(0) &&
                        col <= board.GetLength(1))
                    {
                        command = "clear";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintTopResults(topResults);
                        break;
                    case "restart":
                        board = CreateBoard(BoardRows, BoardColumns);
                        mineField = CreateMineField(BoardRows, BoardColumns, Mines);
                        PrintBoard(board);
                        explosion = false;
                        break;
                    case "exit":
                        Console.WriteLine("You exited the game.");
                        break;
                    case "clear":
                        if (mineField[row, col] != '*')
                        {
                            if (mineField[row, col] == '-')
                            {
                                UpdateBoardPoint(board, mineField, row, col);
                                score++;
                            }

                            if (MaxScore == score)
                            {
                                hasReachedMaxScore = true;
                            }
                            else
                            {
                                PrintBoard(board);
                            }
                        }
                        else
                        {
                            explosion = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command.\n");
                        break;
                }

                if (explosion)
                {
                    PrintBoard(mineField);

                    Console.Write("\nYou've just hit a hidden mine! Your score: {0} points. ", score);

                    Console.Write("Your nickname: ");
                    string nickname = Console.ReadLine();
                    Result result = new Result(nickname, score);

                    if (topResults.Count < TopResultsToKeep - 1)
                    {
                        topResults.Add(result);
                    }
                    else
                    {
                        for (int i = 0; i < topResults.Count; i++)
                        {
                            if (topResults[i].Score < result.Score)
                            {
                                topResults.Insert(i, result);
                                topResults.RemoveAt(topResults.Count - 1);
                                break;
                            }
                        }
                    }

                    topResults.Sort((Result r1, Result r2) => r2.Name.CompareTo(r1.Name));
                    topResults.Sort((Result r1, Result r2) => r2.Score.CompareTo(r1.Score));
                    PrintTopResults(topResults);

                    board = CreateBoard(BoardRows, BoardColumns);
                    mineField = CreateMineField(BoardRows, BoardColumns, Mines);
                    score = 0;
                    starting = true;
                    explosion = false;
                }

                if (hasReachedMaxScore)
                {
                    Console.WriteLine("\nYou win! You have correctly identified all mines.");
                    PrintBoard(mineField);
                    Console.WriteLine("Your nickname: ");
                    string nickname = Console.ReadLine();

                    Result result = new Result(nickname, score);
                    topResults.Add(result);
                    PrintTopResults(topResults);

                    board = CreateBoard(BoardRows, BoardColumns);
                    mineField = CreateMineField(BoardRows, BoardColumns, Mines);
                    score = 0;
                    starting = true;
                    hasReachedMaxScore = false;
                }
            }
            while (command != "exit");
        }
    }
}
