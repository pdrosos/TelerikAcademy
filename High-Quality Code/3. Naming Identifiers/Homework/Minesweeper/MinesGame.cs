namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class MinesGame
    {
        private const int ScoreLimit = 35;
        private const int TotalRows = 5;
        private const int TotalCols = 10;
        private const int TotalMines = 15;
        private const char UnknownField = '?';
        private const char EmptyField = '-';
        private const char MineField = '*';
        private static readonly Random randomGenerator = new Random();

        public static void Main(string[] args)
        {
            string action = string.Empty;
            char[,] playField = CreateGameField();
            char[,] mines = PlaceMines();
            int score = 0;
            bool gameStart = true;
            bool gameOver = false;
            bool gameWon = false;
            List<PlayerScore> leaderboard = new List<PlayerScore>(6);
            int row = 0;
            int col = 0;

            do
            {
                if (gameStart)
                {
                    Console.WriteLine("Lets play “Mines”. Try not to step on the mine fields." +
                        " The command 'top' shows the leaderboard, 'restart' starts new game, 'exit' quits the game!");
                    DrawPlayfield(playField);
                    gameStart = false;
                }

                Console.Write("Enter row and column: ");

                action = Console.ReadLine().Trim();
                if (action.Length >= 3)
                {
                    if (int.TryParse(action[0].ToString(), out row) &&
                        int.TryParse(action[2].ToString(), out col) &&
                        row <= playField.GetLength(0) &&
                        col <= playField.GetLength(1))
                    {
                        action = "turn";
                    }
                }

                switch (action)
                {
                    case "top":
                        ShowLeaderboard(leaderboard);
                        break;
                    case "restart":
                        playField = CreateGameField();
                        mines = PlaceMines();
                        DrawPlayfield(playField);
                        gameOver = false;
                        gameStart = true;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (mines[row, col] != MineField)
                        {
                            if (mines[row, col] == EmptyField)
                            {
                                NextTurn(playField, mines, row, col);
                                score++;
                            }

                            if (ScoreLimit == score)
                            {
                                gameWon = true;
                            }
                            else
                            {
                                DrawPlayfield(playField);
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine(Environment.NewLine + "Error! Invalid Command." + Environment.NewLine);
                        break;
                }

                if (gameOver)
                {
                    DrawPlayfield(mines);
                    Console.Write(
                        Environment.NewLine +
                        "Hrrrrrr! You played valiantly and your score is {0}. " +
                        "Please enter a nickname: ",
                        score);
                    string name = Console.ReadLine();
                    PlayerScore player = new PlayerScore(name, score);

                    if (leaderboard.Count < 5)
                    {
                        leaderboard.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < leaderboard.Count; i++)
                        {
                            if (leaderboard[i].Points < player.Points)
                            {
                                leaderboard.Insert(i, player);
                                leaderboard.RemoveAt(leaderboard.Count - 1);
                                break;
                            }
                        }
                    }

                    leaderboard.Sort((PlayerScore r1, PlayerScore r2) => r2.Name.CompareTo(r1.Name));
                    leaderboard.Sort((PlayerScore r1, PlayerScore r2) => r2.Points.CompareTo(r1.Points));
                    ShowLeaderboard(leaderboard);

                    playField = CreateGameField();
                    mines = PlaceMines();
                    score = 0;
                    gameOver = false;
                    gameStart = true;
                }

                if (gameWon)
                {
                    Console.WriteLine(Environment.NewLine + "BRAVOOO! You managed to clear all the {0} mines.", ScoreLimit);
                    DrawPlayfield(mines);
                    Console.WriteLine("Enter your name champ: ");

                    string name = Console.ReadLine();

                    PlayerScore player = new PlayerScore(name, score);
                    leaderboard.Add(player);
                    ShowLeaderboard(leaderboard);

                    playField = CreateGameField();
                    mines = PlaceMines();
                    score = 0;
                    gameWon = false;
                    gameStart = true;
                }
            }
            while (action != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("Cyaaaaaaaa.");
            Console.Read();
        }

        private static void ShowLeaderboard(List<PlayerScore> leaderboard)
        {
            Console.WriteLine(Environment.NewLine + "High Scores:");
            if (leaderboard.Count > 0)
            {
                for (int i = 0; i < leaderboard.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} points",
                        i + 1,
                        leaderboard[i].Name,
                        leaderboard[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Leaderboard is empty!" + Environment.NewLine);
            }
        }

        private static void NextTurn(char[,] playfield, char[,] mines, int row, int col)
        {
            char totalMines = CountMines(mines, row, col);
            mines[row, col] = totalMines;
            playfield[row, col] = totalMines;
        }

        private static void DrawPlayfield(char[,] playfield)
        {
            int row = playfield.GetLength(0);
            int col = playfield.GetLength(1);
            
            Console.WriteLine(Environment.NewLine + " 0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine(" ---------------------");
            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write(string.Format("{0} ", playfield[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine(" ---------------------" + Environment.NewLine);
        }

        private static char[,] CreateGameField()
        {
            char[,] playfield = new char[TotalRows, TotalCols];

            for (int i = 0; i < TotalRows; i++)
            {
                for (int j = 0; j < TotalCols; j++)
                {
                    playfield[i, j] = UnknownField;
                }
            }

            return playfield;
        }

        private static char[,] PlaceMines()
        {
            char[,] playfield = new char[TotalRows, TotalCols];

            for (int i = 0; i < TotalRows; i++)
            {
                for (int j = 0; j < TotalCols; j++)
                {
                    playfield[i, j] = EmptyField;
                }
            }

            List<int> mines = new List<int>();

            while (mines.Count < TotalMines)
            {
                int position = randomGenerator.Next(50);
                if (!mines.Contains(position))
                {
                    mines.Add(position);
                }
            }

            foreach (int mine in mines)
            {
                int row = mine / TotalCols;
                int col = mine % TotalCols;

                if (col == 0 && mine != 0)
                {
                    row--;
                    col = TotalCols;
                }
                else
                {
                    col++;
                }

                playfield[row, col - 1] = MineField;
            }

            return playfield;
        }

        private static char CountMines(char[,] playfield, int row, int col)
        {
            int count = 0;
            int totalRows = playfield.GetLength(0);
            int totalCols = playfield.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playfield[row - 1, col] == MineField)
                {
                    count++;
                }
            }

            if (row + 1 < totalRows)
            {
                if (playfield[row + 1, col] == MineField)
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (playfield[row, col - 1] == MineField)
                {
                    count++;
                }
            }

            if (col + 1 < totalCols)
            {
                if (playfield[row, col + 1] == MineField)
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (playfield[row - 1, col - 1] == MineField)
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < totalCols))
            {
                if (playfield[row - 1, col + 1] == MineField)
                {
                    count++;
                }
            }

            if ((row + 1 < totalRows) && (col - 1 >= 0))
            {
                if (playfield[row + 1, col - 1] == MineField)
                {
                    count++;
                }
            }

            if ((row + 1 < totalRows) && (col + 1 < totalCols))
            {
                if (playfield[row + 1, col + 1] == MineField)
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
