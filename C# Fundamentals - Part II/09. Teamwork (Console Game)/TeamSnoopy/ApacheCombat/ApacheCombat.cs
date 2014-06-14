using System;
using System.Threading;

namespace ApacheCombat
{
    class ApacheCombat
    {
        public static int consoleWindowWidth = 120;
        public static int consoleWindowHeight = 46;
        static bool collisionExists = false;

        static void RemoveScrollBars()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void HandleCollision(Rock rock, Helicopter helicopter, out bool collision)
        {
            collision = false;

            if ((rock.StartX == helicopter.EndX && !(rock.EndY < helicopter.StartY || rock.StartY > helicopter.EndY))
                || ((rock.EndY == helicopter.StartY || rock.StartY == helicopter.EndY) && !(rock.EndX < helicopter.StartX || rock.StartX > helicopter.EndX)))
            {
                Console.Clear();
                Console.SetCursorPosition(consoleWindowWidth / 2 - 8, consoleWindowHeight / 2);
                collision = true;
                Console.Write("Crash!!!");
                Console.ReadLine();
            }
        }

        static void Main()
        {
            Console.SetWindowSize(consoleWindowWidth, consoleWindowHeight);
            RemoveScrollBars();
            Console.CursorVisible = false;
            StartScreen.DrawAsciiHelicopter("../../txt/01-StartScreen.txt");
            StartScreen.MenuChoice();

            string[,] rockElements = new string[,] { { " ", "P", " " }, { "P", " ", "P" } };

            Helicopter helicopter = new Helicopter();
            Helicopter.SetPosition(helicopter);
            Rock rock = new Rock(rockElements, consoleWindowWidth - 3, 13);

            while (true)
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        Helicopter.MoveUp(helicopter);
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        Helicopter.MoveDown(helicopter);
                    }
                }

                HandleCollision(rock, helicopter, out collisionExists);

                if (collisionExists == true)
                {
                    break;
                }
                Helicopter.Draw(helicopter);
                Rock.Draw(rock);
                Rock.MoveLeft(rock);
                Thread.Sleep(150);
                Console.Clear();
            }
        }
    }
}