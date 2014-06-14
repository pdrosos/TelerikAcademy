using System;

class CompareTwoArrays
{
    static void Main()
    {
        //Write a program that reads two arrays from the console and compares them element by element.

        Console.WriteLine("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] firstArray = new int[n];
        int[] secondArray = new int[n];

        Console.WriteLine("-----------------First Array------------------");
        for (int i = 0; i < n; i++)
        {
            Console.Write("firstArray[{0}]: ", i);
            firstArray[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("-----------------Second Array-----------------");
        for (int i = 0; i < n; i++)
        {
            Console.Write("secondArray[{0}]: ", i);
            secondArray[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("firstArray[{0}]: {1} = {2} :secondArray[{0}]", i, firstArray[i], secondArray[i]);
            }
            if (firstArray[i] < secondArray[i])
            {
                Console.WriteLine("firstArray[{0}]: {1} < {2} :secondArray[{0}]", i, firstArray[i], secondArray[i]);
            }
            if (firstArray[i] > secondArray[i])
            {
                Console.WriteLine("firstArray[{0}]: {1} > {2} :secondArray[{0}]", i, firstArray[i], secondArray[i]);
            }
        }
    }
}
