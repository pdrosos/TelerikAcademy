using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace JustSpaceship
{
    class Program
    {
        const int MaxHeight = 20;
        const int MaxWidth = 30;

        static int livesCount = 3;

        static int playerPosition = 0;
        static List<List<int>> enemies = new List<List<int>>();
        static List<List<int>> shots = new List<List<int>>();

        static Random rand = new Random();

        static char playerSymbol = '@';
        static char enemySymbol = '*';
        static char shotSymbol = '|';

        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = MaxHeight;
            Console.BufferWidth = Console.WindowWidth = MaxWidth;

            playerPosition = MaxWidth / 2;

            int steps = 0;
            int enemiesPause = 3;

            while (livesCount > 0)
            {
                UpdateField();

                if (steps % enemiesPause == 0)
                {
                    GenerateRandomEnemy();
                    UpdateEnemies();
                    HandleCollisionsEnemiesPlayer();
                    steps = 0;
                }

                steps++;

                Draw();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (playerPosition - 1 > 0)
                        {
                            playerPosition--;
                        }
                    }

                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (playerPosition + 1 < MaxWidth - 1)
                        {
                            playerPosition++;
                        }
                    }

                    if (pressedKey.Key == ConsoleKey.Spacebar)
                    {
                        Shoot();
                    }
                }

                Thread.Sleep(200);

                Console.Clear();
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("OH NO YOU ARE SOOOO DEAD!!!!");
        }

        private static void UpdateField()
        {
            UpdateShots();
            HandleCollisionsEnemiesShots();
        }

        private static void HandleCollisionsEnemiesPlayer()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i][0] == playerPosition &&
                    enemies[i][1] == MaxHeight - 1)
                {
                    livesCount--;
                }
            }
        }

        private static void HandleCollisionsEnemiesShots()
        {
            List<int> enemiesToRemove = new List<int>();
            List<int> shotsToRemove = new List<int>();

            for (int enemy = 0; enemy < enemies.Count; enemy++)
            {
                for (int shot = 0; shot < shots.Count; shot++)
                {
                    if (shots[shot][0] == enemies[enemy][0] &&
                        shots[shot][1] == enemies[enemy][1])
                    {
                        enemiesToRemove.Add(enemy);
                        shotsToRemove.Add(shot);
                    }
                }
            }

            List<List<int>> newEnemies = new List<List<int>>();
            List<List<int>> newShots = new List<List<int>>();

            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemiesToRemove.Contains(i))
                {
                    newEnemies.Add(enemies[i]);
                }
            }

            for (int i = 0; i < shots.Count; i++)
            {
                if (!shotsToRemove.Contains(i))
                {
                    newShots.Add(shots[i]);
                }
            }

            enemies = newEnemies;
            shots = newShots;
        }

        private static void UpdateEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i][1] = enemies[i][1] + 1;
            }

            int index = -1;

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i][1] >= MaxHeight)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)//we found enemy that is out of the boundaries and now we have to remove it
            {
                enemies.RemoveAt(index);
            }
        }

        private static void UpdateShots()
        {
            for (int i = 0; i < shots.Count; i++)
            {
                shots[i][1] = shots[i][1] - 1;
            }

            int index = -1;

            for (int i = 0; i < shots.Count; i++)
            {
                if (shots[i][1] <= 1)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1) //we found shot that is out of the boundaries and now we have to remove it
            {
                shots.RemoveAt(index);
            }
        }

        private static void GenerateRandomEnemy()
        {
            int randomEnemyPosition = rand.Next(1, MaxWidth);

            List<int> randomEnemyCoordinates = new List<int>()
            {
                randomEnemyPosition, 1
            };

            enemies.Add(randomEnemyCoordinates);
        }

        private static void Shoot()
        {
            shots.Add(new List<int>()
            {
                playerPosition,
                MaxHeight - 3
            });
        }

        private static void Draw()
        {
            DrawEnemies();
            DrawShots();
            DrawPlayer();
        }

        private static void DrawShots()
        {
            foreach (List<int> shot in shots)
            {
                ConsoleColor shotColor = ConsoleColor.Blue;
                DrawSymbolAtCoordinates(shot, shotSymbol, shotColor);
            }
        }

        private static void DrawEnemies()
        {
            foreach (List<int> enemy in enemies)
            {
                ConsoleColor enemyColor = ConsoleColor.Green;
                DrawSymbolAtCoordinates(enemy, enemySymbol, enemyColor);
            }
        }

        private static void DrawPlayer()
        {
            List<int> playerCoordinates = new List<int>() 
            { 
                playerPosition, 
                MaxHeight - 1 
            };

            ConsoleColor playerColor = ConsoleColor.Magenta;

            DrawSymbolAtCoordinates(playerCoordinates, playerSymbol, playerColor);
        }

        private static void DrawSymbolAtCoordinates(List<int> coordinates, char symbol, ConsoleColor color)
        {
            Console.SetCursorPosition(coordinates[0], coordinates[1]);
            Console.ForegroundColor = color;
            Console.WriteLine(symbol);
        }

    }
}
