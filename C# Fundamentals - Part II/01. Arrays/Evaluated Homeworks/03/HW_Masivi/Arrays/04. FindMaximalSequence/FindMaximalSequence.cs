using System;

class FindMaximalSequence
{
    static void Main()
    {
        //Write a program that finds the maximal sequence of equal elements in an array.
        //Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

        Console.WriteLine("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("array[{0}]: ", i);
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        int bestCount = 1;
        int bestNumber = -1;
        int br = 1;
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] == array[i + 1])
            {
                br++;
            }
            else if (br > 1)
            {
                if (br > bestCount)
                {
                    bestNumber = array[i];
                    bestCount = br;
                }
                br = 1;
            }
        }
        if (br > 1 && br > bestCount)
        {
            bestNumber = array[array.Length - 1];
            bestCount = br;
        }
        if (bestNumber == -1)
        {
            Console.WriteLine();
            Console.WriteLine("No sequence of numbers found !");
            return;
        }

        int[] maxSequence = new int[bestCount];
        for (int i = 0; i < maxSequence.Length; i++)
        {
            maxSequence[i] = bestNumber;
        }
        Console.WriteLine();
        Console.Write("{");
        for (int i = 0; i < bestCount - 1; i++)
        {
            Console.Write("{0}, ", bestNumber);
        }
        Console.WriteLine("{0}}}", bestNumber);
    }
}
