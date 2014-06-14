using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyDwarf
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string[] splittedPath = numbers.Split(new char[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] path = new int[splittedPath.Length];

            for (int i = 0; i < splittedPath.Length; i++)
            {
                path[i] = int.Parse(splittedPath[i]);
            }

            long bestSum = long.MinValue;
            int numOfPatterns = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfPatterns; i++)
            {
                long sumOfCoins = (ProcessPatterns(path));
                if (sumOfCoins>bestSum)
                {
                    bestSum = sumOfCoins;
                }
            }
            Console.WriteLine(bestSum);
           
        }
        static long ProcessPatterns(int[] valley)
        {
            string numbers = Console.ReadLine();
            string[] splittedNums = numbers.Split(new char[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] pattern = new int[splittedNums.Length];
            for (int i = 0; i < splittedNums.Length; i++)
            {
                pattern[i] = int.Parse(splittedNums[i]);
            }

            bool[] visited = new bool[valley.Length];
            long coinsSum = valley[0];
            visited[0] = true;
            int currentPos = 0;
            while (true)
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    int nextMove = currentPos + pattern[i];

                    if (nextMove >= 0 && nextMove < valley.Length && !visited[nextMove])
                    {
                        coinsSum += valley[nextMove];
                        visited[nextMove] = true;
                        currentPos = nextMove;
                    }
                    else
                    {
                        return coinsSum;
                    }

                }
            }

            return 0;
        }
    }
}
