using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace ActionGame
{
    public class ActionGame
    {
        public const int SideBarWidth = 20;
        public const int gameTime = 60000;

        static int GameWindowWidth = 100; // shirina
        static int GameWindowHeight = 50; // visochina

        public static int counter;

        public static int fishesHit;
        public static int fishesMissed;

        static SafeFileHandle h;

        static void Main(string[] args)
        {
            Play();
        }

        public static void Play()
        {
            Console.ResetColor();
            h = Imports.CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            counter = 0;
            fishesHit = 0;
            fishesMissed = 0;
            Stopwatch sw = new Stopwatch();
            int gameScore = 0;

            Random r = new Random(255);
            Imports.CharInfo[] matrix = new Imports.CharInfo[GameWindowWidth * GameWindowHeight];

            Console.SetWindowSize(GameWindowWidth + SideBarWidth, GameWindowHeight);
            Console.SetBufferSize(GameWindowWidth + SideBarWidth, GameWindowHeight);

            int difficulty = SelectDifficulty();
            Console.Clear();

            int weapon = SelectWeapon();
            Console.Clear();

            PrintChoices(weapon, difficulty);

            StartScreen();

            int weaponDiff = 0;
            switch (weapon)
            {
                case 1: weaponDiff = 5; break;
                case 2: weaponDiff = 7; break;
                case 3: weaponDiff = 15; break;
            }

            int gameDiff = 0;
            switch (difficulty)
            {
                case 1: gameDiff = 5; break;
                case 2: gameDiff = 3; break;
                case 3: gameDiff = 2; break;
            }

            List<object> shoots = new List<object>();
            List<object> fishes = new List<object>();

            Felix f = new Felix();
            f.setFelixPos();
            Sidebar(gameScore, fishesMissed, fishesHit);
            sw.Start();

            while (true)
            {
                if (sw.ElapsedMilliseconds >= gameTime)
                {
                    break;
                }
                counter++;
                if (counter % gameDiff == 0)
                {
                    int size = NumberOfFishes(r);
                    for (int i = 0; i < size; i++)
                    {
                        Fish fish = new Fish();
                        fish.Position(matrix, r, GameWindowWidth);
                        fishes.Add(fish);
                    }
                }

                if ((Imports.GetKeyState(VirtualKeyStates.VK_SPACE) & 0x8000) > 0)
                {
                    if (counter % weaponDiff == 0)
                    {
                        Weapon w = new Weapon();
                        w.WeaponKind(weapon);
                        w.SetWeaponPos(f);
                        shoots.Add(w);
                    }
                }

                if (shoots.Count > 0)
                {

                    foreach (Weapon w in shoots)
                    {
                        w.Shoot();
                    }

                }

                foreach (Fish fish in fishes)
                {
                    if (counter % 5 == 0)
                    {
                        fish.Move(matrix);
                    }
                }

                f.Move(matrix, GameWindowWidth);
                int timeLeft = (int)Math.Abs(60 - (sw.ElapsedMilliseconds / 1000));
                PrintGame(f, matrix, shoots, fishes, weapon, ref gameScore, timeLeft);

                Thread.Sleep(20 - (int)((20.0 / gameTime) * sw.ElapsedMilliseconds));
            }

            GameEnd(gameScore);
            // AFTER GAME ENDS
            h.Close();
        }

        static void GameEnd(int score)
        {
            string[] highScore = new string[5];
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            StreamReader readScore = new StreamReader("../../../../../textFiles/HighScores.txt");
            using (readScore)
            {
                int i = 0;
                for (string line; (line = readScore.ReadLine()) != null; i++)
                {
                    highScore[i] = line;
                }
            }
            if (Convert.ToInt32(highScore[4]) < score)
            {
                highScore[4] = score.ToString();
                StreamWriter newscore = new StreamWriter("../../../../../textFiles/HighScores.txt");
                using (newscore)
                {
                    for (int i = 0; i < highScore.Length; i++)
                    {
                        newscore.WriteLine(highScore[i]);
                    }
                }
            }
            Console.SetCursorPosition(GameWindowWidth / 2, GameWindowHeight / 2);
            Console.WriteLine("Your current score is {0}", score);
            Console.SetCursorPosition(GameWindowWidth / 2, (GameWindowHeight / 2) + 1);
            Console.WriteLine("Your highest score is {0}", highScore[4]);
            Thread.Sleep(5000);
            Console.Clear();
        }

        static int NumberOfFishes(Random r)
        {
            int maxNumber = ((GameWindowWidth - 1) / 5) / 2;

            return r.Next(2);
        }

        static void PrintGame(Felix f, Imports.CharInfo[] matrix, List<object> list, List<object> fishes, int weapon, ref int score, int time)
        {
            List<object> temp = new List<object>();
            ClearMatrix(matrix);

            //weapon
            foreach (Weapon w in list)
            {
                if (w.y <= 0)
                {
                    temp.Add(w);
                }
                else
                {
                    matrix[w.x + (w.y * GameWindowWidth)] = w.weapon;

                    if (weapon == 3 || weapon == 2)
                    {
                        double hitPoints = 0;
                        int range = 0;
                        if (weapon == 3) { range = 8; hitPoints = 3; }
                        if (weapon == 2) { range = 4; hitPoints = 4.5; }
                        int x = w.x - range;
                        int y = w.y - range;
                        int width = range * 2;
                        int heith = range;

                        List<object> DeadFishes = new List<object>();
                        foreach (Fish fish in fishes)
                        {
                            if (fish.x <= w.x && fish.x + fish.width > w.x && fish.y <= w.y && fish.y + fish.height > w.y)
                            {
                                fish.health -= hitPoints;
                                if (fish.health == 0)
                                {
                                    DeadFishes.Add(fish);
                                    score++;
                                    fishesHit++;
                                }

                                foreach (Fish fish_ in fishes)
                                {
                                    if (fish_ == fish)
                                    {
                                        continue;
                                    }
                                    if (!(x >= fish_.x + fish_.width ||
                                        fish_.x > x + width ||
                                        y >= fish_.y + fish_.height ||
                                        fish_.y > y + heith
                                        ))
                                    {
                                        fish_.health -= hitPoints;
                                        if (fish_.health == 0)
                                        {
                                            DeadFishes.Add(fish_);
                                            score++;
                                            fishesHit++;
                                        }
                                    }
                                }
                                temp.Add(w);

                                break;
                            }
                        }
                        foreach (Fish deadfish in DeadFishes)
                        {
                            fishes.Remove(deadfish);
                        }
                    }
                    else
                    {
                        List<object> DeadFishes = new List<object>();
                        foreach (Fish fish in fishes)
                        {
                            if (fish.x <= w.x && fish.x + fish.width > w.x && fish.y <= w.y && fish.y + fish.height > w.y)
                            {
                                DeadFishes.Add(fish);
                                score++;
                                fishesHit++;
                                temp.Add(w);
                                break;
                            }
                        }
                        foreach (Fish deadfish in DeadFishes)
                        {
                            fishes.Remove(deadfish);
                        }
                    }
                }
            }

            foreach (Weapon w in temp)
            {
                list.Remove(w);
            }
            temp.Clear();

            //fish
            List<Fish> missedFishes = new List<Fish>();
            foreach (Fish fish in fishes)
            {
                if (fish.y >= GameWindowHeight)
                {
                    missedFishes.Add(fish);
                    continue;
                }
                //  Trace.WriteLine(fish.x);
                for (int i = fish.y, l = 0; i < fish.y + fish.height; i++, l++)
                {

                    if (i >= GameWindowHeight)
                    {
                        break;
                    }

                    for (int j = fish.x, k = 0; j < fish.x + fish.width; j++, k++)
                    {
                        if (fish.health == 9)
                        {
                            matrix[j + (i * GameWindowWidth)].Attributes = 10;
                        }
                        if (fish.health == 4.5)
                        {
                            matrix[j + (i * GameWindowWidth)].Attributes = 11;//
                        }
                        if (fish.health == 3)
                        {
                            matrix[j + (i * GameWindowWidth)].Attributes = 7;//
                        }
                        if (fish.health == 6)
                        {
                            matrix[j + (i * GameWindowWidth)].Attributes = 11;//
                        }
                        matrix[j + (i * GameWindowWidth)].Char.UnicodeChar = fish.fish[l, k];
                    }
                }
            }

            foreach (Fish missed in missedFishes)
            {
                fishes.Remove(missed);
                score = score - 2;
                fishesMissed++;
            }

            //felix
            matrix[f.x + (f.y * GameWindowWidth)].Char.UnicodeChar = f.felix;
            PrintMatrix(matrix);

            SidebarScoreRefresh(score, fishesMissed, fishesHit, time);
        }

        static void ClearMatrix(Imports.CharInfo[] matrix)
        {
            for (int i = 0; i < GameWindowWidth * GameWindowHeight; i++)
            {
                matrix[i].Attributes = 15;
                matrix[i].Char.UnicodeChar = ' ';
            }
        }

        static void PrintMatrix(Imports.CharInfo[] matrix)
        {
            if (!h.IsInvalid)
            {
                Imports.SmallRect rect = new Imports.SmallRect() { Left = 0, Top = 0, Right = (short)GameWindowWidth, Bottom = (short)GameWindowHeight };

                bool b = Imports.WriteConsoleOutput(h, matrix,
                new Imports.Coord() { X = (short)GameWindowWidth, Y = (short)GameWindowHeight },
                new Imports.Coord() { X = 0, Y = 0 },
                ref rect);
            }
        }

        static void Sidebar(int score, int fishesMissed, int fishedHitted)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int row = 0; row < GameWindowHeight; row++)
            {
                Console.SetCursorPosition(GameWindowWidth, row);
                Console.Write("█");
            }
            Console.ResetColor();
            Console.SetCursorPosition(GameWindowWidth + 3, 10);
            Console.Write("Score:");
            Console.SetCursorPosition(GameWindowWidth + 3, 11);
            Console.Write(score);
            Console.SetCursorPosition(GameWindowWidth + 3, 15);
            Console.Write("Hit:");
            Console.SetCursorPosition(GameWindowWidth + 3, 16);
            Console.Write(fishedHitted);
            Console.SetCursorPosition(GameWindowWidth + 3, 20);
            Console.Write("Miss:");
            Console.SetCursorPosition(GameWindowWidth + 3, 21);
            Console.Write(fishesMissed);
            Console.SetCursorPosition(GameWindowWidth + 3, 5);
            Console.Write("Time Left:");
            Console.SetCursorPosition(GameWindowWidth + 3, 6);
            Console.Write("60");


        }

        static void SidebarScoreRefresh(int score, int fishesMissed, int fishedHitted, int time)
        {
            Console.SetCursorPosition(GameWindowWidth + 3, 10);
            Console.Write("Score:");
            Console.SetCursorPosition(GameWindowWidth + 3, 11);
            Console.Write(score);
            Console.SetCursorPosition(GameWindowWidth + 3, 15);
            Console.Write("Hit:");
            Console.SetCursorPosition(GameWindowWidth + 3, 16);
            Console.Write(fishedHitted);
            Console.SetCursorPosition(GameWindowWidth + 3, 20);
            Console.Write("Miss:");
            Console.SetCursorPosition(GameWindowWidth + 3, 21);
            Console.Write(fishesMissed);
            Console.SetCursorPosition(GameWindowWidth + 3, 5);
            Console.Write("Time Left:");
            Console.SetCursorPosition(GameWindowWidth + 3, 6);
            Console.Write(time + " ");
        }

        static void StartScreen()
        {
            Console.WriteLine();

            Console.Write("Use the");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Left Arrow");
            Console.ResetColor();
            Console.Write(" and");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Right Arrow");
            Console.ResetColor();
            Console.Write(" keys to move and");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Space");
            Console.ResetColor();
            Console.Write(" to shoot!");
            Console.WriteLine();

            Console.WriteLine("To Start the game press ENTER.");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        static void PrintChoices(int wep, int diff)
        {
            string weapon = "";
            string difficulty = "";
            if (wep == 1) weapon = "Bow";
            else if (wep == 2) weapon = "Shotgun";
            else if (wep == 3) weapon = "Bomb";
            if (diff == 1) difficulty = "Easy";
            else if (diff == 2) difficulty = "Normal";
            else if (diff == 3) difficulty = "Hard";

            Console.Write("Your weapon of choice is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(weapon);
            Console.WriteLine();
            Console.ResetColor();
            Console.Write("And your difficulty is:  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(difficulty);
            Console.WriteLine();
            Console.ResetColor();
        }

        static int SelectWeapon()
        {

            Console.WriteLine("Select a weapon!");
            char[,] bow = new char[7, 11]
            {
                {' ', ' ', ' ', '(', ' ', ' ', ' ',' ',' ',' ',' ' },
                {' ', ' ', ' ', ' ', '\\', ' ', ' ',' ',' ',' ',' '},
                {' ', ' ', ' ', ' ', ' ', ')', ' ',' ',' ',' ',' ',},
                {'#','#','-','-','-','-','-','-','-','-','>'},
                {' ', ' ', ' ', ' ', ' ', ')', ' ',' ',' ',' ',' ' },
                {' ', ' ', ' ', ' ', '/', ' ', ' ',' ',' ',' ',' ',},
                {' ', ' ', ' ', '(', ' ', ' ', ' ',' ',' ',' ',' ',}
            };

            Console.WriteLine();
            Console.WriteLine("1: Bow \n[Shoots fast but hits one target]");
            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(bow[i, j]);
                }
                Console.WriteLine();
            }

            char[,] shotgun = new char[3, 11]
            {
                {' ', '_', ' ', '_', '_', '_', '_', '_', '_', '_', ','},
                {' ', '>', '`', '(', '=', '=', '(', '-', '-', '-', '`'},
                {'(', '_', '_', '/', '~', '~', '`', ' ', ' ', ' ', ' '}
            };

            Console.WriteLine();
            Console.WriteLine("2: Shotgun \n[Shoots slower but hits in 10 range radius]");
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(shotgun[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("3: Bomb \n[Shoots slowest but hits in 20 range radius]");
            Console.WriteLine();
            Console.WriteLine("        \\|/");
            Console.WriteLine("       .-*-       ");
            Console.WriteLine("      / /|\\     ");
            Console.WriteLine("     _L_       ");
            Console.WriteLine("    ,\"   \".      ");
            Console.WriteLine("(\\ /  O O  \\ /)");
            Console.WriteLine(" \\|    _    |/  ");
            Console.WriteLine("  \\   (_)  /     ");
            Console.WriteLine("   _/.___,\\_       ");
            Console.WriteLine("  (_/    \\_)       ");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                {
                    return 1;
                }
                else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
                {
                    return 2;
                }
                else if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad3)
                {
                    return 3;
                }
            }
        }

        static int SelectDifficulty()
        {
            Console.SetCursorPosition(GameWindowWidth / 2, (GameWindowHeight / 2)-1);
            Console.WriteLine("Select difficulty:");
            Console.SetCursorPosition(GameWindowWidth / 2, (GameWindowHeight / 2) + 1);
            Console.WriteLine("1: EASY ");
            Console.SetCursorPosition(GameWindowWidth / 2, (GameWindowHeight / 2) + 2);
            Console.WriteLine("2: NORMAL ");
            Console.SetCursorPosition(GameWindowWidth / 2, (GameWindowHeight / 2) + 3);
            Console.WriteLine("3: HARD ");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                {
                    return 1;
                }
                else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
                {
                    return 2;
                }
                else if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad3)
                {
                    return 3;
                }
            }
        }
    }
}
