using System;

namespace SpecialValue
{
    class SpecialValue
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] field = ReadField(n);
            bool[][] visited;

            int maxSpecialValue = -1;
            int currentSpecialValue = -1;

            for (int i = 0; i < field[0].Length; i++)
            {
                visited = InitializeVisited(field);

                currentSpecialValue = CalculatePathSpecialValue(field, i, visited);

                if (currentSpecialValue > maxSpecialValue)
                {
                    maxSpecialValue = currentSpecialValue;
                }
            }

            Console.WriteLine(maxSpecialValue);
        }

        private static int[][] ReadField(int fieldLines)
        {
            int[][] field = new int[fieldLines][];

            for (int i = 0; i < fieldLines; i++)
            {
                string numbersStr = Console.ReadLine();
                string[] numbers = numbersStr.Split(new string[] { ", " }, StringSplitOptions.None);

                field[i] = new int[numbers.Length];

                for (int j = 0; j < numbers.Length; j++)
                {
                    field[i][j] = int.Parse(numbers[j]);
                }
            }

            return field;
        }

        private static bool[][] InitializeVisited(int[][] field)
        {
            bool[][] visited = new bool[field.GetLength(0)][];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                visited[i] = new bool[field[i].Length];
            }

            return visited;
        }

        private static int CalculatePathSpecialValue(int[][] field, int startColumnIndex, bool[][] visited)
        {
            int currentRowIndex = 0;
            int currentColumnIndex = startColumnIndex;
            int pathLength = 0;

            while (true)
            {
                pathLength++;

                // negative value in cell - return special value
                if (field[currentRowIndex][currentColumnIndex] < 0)
                {
                    return pathLength + Math.Abs(field[currentRowIndex][currentColumnIndex]);
                }

                // visited cell - no special value
                if (visited[currentRowIndex][currentColumnIndex] == true)
                {
                    return -1;
                }

                // mark cell as visited
                visited[currentRowIndex][currentColumnIndex] = true;

                // update indices                
                currentColumnIndex = field[currentRowIndex][currentColumnIndex];
                currentRowIndex++;
                if (currentRowIndex == field.GetLength(0))
                {
                    currentRowIndex = 0;
                }
            }
        }
    }
}