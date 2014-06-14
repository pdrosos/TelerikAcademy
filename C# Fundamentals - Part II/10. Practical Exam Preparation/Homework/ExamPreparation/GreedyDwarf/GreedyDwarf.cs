using System;
using System.IO;

namespace GreedyDwarf
{
    class GreedyDwarf
    {
        static void Main(string[] args)
        {
            //Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

            int[] valley = ReadValley();
            int[][] patterns = ReadPatterns();

            int currentPatternCoins = int.MinValue;
            int maxCoins = int.MinValue;

            for (int i = 0; i < patterns.Length; i++)
            {
                currentPatternCoins = CalculatePatternCoins(valley, patterns[i]);

                if (currentPatternCoins > maxCoins)
                {
                    maxCoins = currentPatternCoins;
                }
            }

            Console.WriteLine(maxCoins);
        }
  
        private static int CalculatePatternCoins(int[] valley, int[] pattern)
        {
            int currentIndex = 0;
            int patternIndex = 0;
            int coins = 0;
            bool[] visited = new bool[valley.Length];

            while (true)
            {
                if (currentIndex >= valley.Length || currentIndex < 0)
                {
                    break;
                }

                if (visited[currentIndex] == true)
                {
                    break;
                }

                visited[currentIndex] = true;

                coins += valley[currentIndex];

                currentIndex += pattern[patternIndex];
                patternIndex++;
                if (patternIndex == pattern.Length)
                {
                    patternIndex = 0;
                }
            }
            
            return coins;
        }

        private static int[] ReadValley()
        {
            string numbersStr = Console.ReadLine();
            string[] numbers = numbersStr.Split(new string[] { ", " }, StringSplitOptions.None);
            int[] valley = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                valley[i] = int.Parse(numbers[i]);
            }

            return valley;
        }

        private static int[][] ReadPatterns()
        {
            int patternsNumber = int.Parse(Console.ReadLine());
            int[][] patterns = new int[patternsNumber][];

            for (int i = 0; i < patternsNumber; i++)
            {
                string numbersStr = Console.ReadLine();
                string[] numbers = numbersStr.Split(new string[] { ", " }, StringSplitOptions.None);
                patterns[i] = new int[numbers.Length];
                for (int j = 0; j < numbers.Length; j++)
                {
                    patterns[i][j] = int.Parse(numbers[j]);
                }
            }

            return patterns;
        }
    }
}
