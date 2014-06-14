using System;

class CompareLexicographically 
{
    static void Main()
    {
        //Write a program that compares two char arrays lexicographically (letter by letter).

        Console.WriteLine("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        char[] firstArray = new char[n];
        char[] secondArray = new char[n];

        Console.WriteLine("-----------------First Array------------------");
        for (int i = 0; i < n; i++)
        {
            Console.Write("firstArray[{0}]: ", i);
            firstArray[i] = Convert.ToChar(Console.ReadLine());
        }
        Console.WriteLine("-----------------Second Array-----------------");
        for (int i = 0; i < n; i++)
        {
            Console.Write("secondArray[{0}]: ", i);
            secondArray[i] = Convert.ToChar(Console.ReadLine());
        }

        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("firstArray[{0}]: {1} = {2} :secondArray[{0}]", i, firstArray[i], secondArray[i]);
            }
            if (firstArray[i] != secondArray[i])
            {
                Console.WriteLine("firstArray[{0}]: {1} != {2} :secondArray[{0}]", i, firstArray[i], secondArray[i]);
            }
        }
    }
}
