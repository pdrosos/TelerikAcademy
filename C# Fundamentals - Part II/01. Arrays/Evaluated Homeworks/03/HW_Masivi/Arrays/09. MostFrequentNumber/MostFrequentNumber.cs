using System;

class MostFrequentNumber
{
    static void Main()
    {
        //Write a program that finds the most frequent number in an array. Example:
	    //{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

        Console.WriteLine("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("array[{0}]: ", i);
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        int mostCount = 1;
        int mostNumber = 0;
        int br = 1;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 1 + i; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    br++;
                }
            }
            if (br > mostCount)
            {
                mostCount = br;
                mostNumber = array[i];
                br = 1;
            }
            br = 1;
        }
        if (mostCount == 1)
        {
            Console.WriteLine();
            Console.WriteLine("The array contains only distinct numbers !");
            return;
        }
        Console.WriteLine();
        Console.WriteLine("{0} ({1} times)", mostNumber, mostCount);
    }
}
