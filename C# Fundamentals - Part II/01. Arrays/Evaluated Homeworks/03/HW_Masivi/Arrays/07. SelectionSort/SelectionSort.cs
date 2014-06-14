using System;

class SelectionSort
{
    static void Main()
    {
        //Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
        //Use the "selection sort" algorithm: Find the smallest element, move it at the first position, 
        //find the smallest from the rest, move it at the second position, etc.

        Console.WriteLine("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("array[{0}]: ", i);
            array[i] = Convert.ToInt32(Console.ReadLine());
        }


        for (int i = 0; i < array.Length - 1; i++)
        {
            int smallest = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[smallest])
                {
                    smallest = j;
                }
            }
            int temp = array[i];
            array[i] = array[smallest];
            array[smallest] = temp;
        }
        Console.WriteLine();
        Console.Write("Sorted array: ");
        foreach (var member in array)
        {
            Console.Write("{0} ", member);
        }
        Console.WriteLine();
    }
}