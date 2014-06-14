using System;

namespace JoroTheRabbit
{
    class JoroTheRabbit
    {
        static void Main(string[] args)
        {
            int[] path = ReadPath();

            int maxSteps = 1;
            int currentSteps = 1;

            for (int i = 0; i < path.Length; i++)
            {
                currentSteps = CalculatePathMaxSteps(path, i);

                if (currentSteps > maxSteps)
                {
                    maxSteps = currentSteps;
                }
            }

            Console.WriteLine(maxSteps);
        }

        private static int CalculatePathMaxSteps(int[] path, int startIndex)
        {
            // bool[] visited;
            int currentIndex;
            int nextIndex;

            int maxSteps = 1;
            int currentSteps;

            for (int step = 1; step < path.Length; step++)
            {
                // visited = new bool[path.Length];
                currentIndex = startIndex;
                currentSteps = 0;

                while (true)
                {
                    currentSteps++;
                    // visited[currentIndex] = true;

                    nextIndex = currentIndex + step;
                    if (nextIndex >= path.Length)
                    {
                        nextIndex -= path.Length;
                    }

                    // if (visited[nextIndex] == true || path[currentIndex] >= path[nextIndex])
                    if (path[currentIndex] >= path[nextIndex])
                    {
                        break;
                    }

                    currentIndex = nextIndex;
                }

                if (currentSteps > maxSteps)
                {
                    maxSteps = currentSteps;
                }
            }

            return maxSteps;
        }
  
        private static int[] ReadPath()
        {
            string numbersStr = Console.ReadLine();
            string[] numbers = numbersStr.Split(new string[] { ", " }, StringSplitOptions.None);
            int[] path = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                path[i] = int.Parse(numbers[i]);
            }

            return path;
        }
    }
}
