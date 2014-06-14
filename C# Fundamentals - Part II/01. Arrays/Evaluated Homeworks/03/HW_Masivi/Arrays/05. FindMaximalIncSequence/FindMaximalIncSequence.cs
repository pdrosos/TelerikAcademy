using System;

class FindMaximalIncSequence
{
    static void Main()
    {
        //Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

        Console.WriteLine("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("array[{0}]: ", i);
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        int bestCount = 1;
        int bestPosition = -1;
        int br = 1;
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1])
            {
                br++;
            }
            else if (br > 1)
            {
                if (br > bestCount)
                {
                    bestPosition = i - br + 1;
                    bestCount = br;
                }
                br = 1;
            }
        }
        if (br > 1 && br > bestCount)
        {
            bestPosition = array.Length - br;
            bestCount = br;
        }
        if (bestPosition == -1)
        {
            Console.WriteLine();
            Console.WriteLine("No increasing sequence of numbers found !");
            return;
        }

        Console.WriteLine();
        Console.Write("{");
        for (int i = 0; i < bestCount - 1; i++)
        {
            Console.Write("{0}, ", array[bestPosition + i]);
        }
        Console.WriteLine("{0}}}", array[bestPosition + bestCount - 1]);
    }
}
