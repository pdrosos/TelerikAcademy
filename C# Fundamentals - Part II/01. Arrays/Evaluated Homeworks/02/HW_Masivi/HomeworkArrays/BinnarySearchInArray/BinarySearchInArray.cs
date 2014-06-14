/* Write a program that finds the index of
 * given element in a sorted array of integers
 * by using the binary search algorithm (find it in Wikipedia).
 */
using System;

class BinarySearchInArray
{
    static int BinarySearch(int[] BinarySequence, int SearchValue)
    {
        Array.Sort(BinarySequence);
        int BinaryMaximum = BinarySequence.Length - 1;
        int BinaryMinimum = 0;
        while (BinaryMaximum >= BinaryMinimum)
        {
            int BinaryPoint = (BinaryMinimum + BinaryMaximum) / 2;
            if (BinarySequence[BinaryPoint] < SearchValue)
            {
                BinaryMinimum = BinaryPoint + 1;
            }
            else if (BinarySequence[BinaryPoint] > SearchValue)
            {
                BinaryMaximum = BinaryPoint - 1;
            }
            else
            {
                return BinaryPoint;
            }
        }
        return -1;
    }
    static void Main()
    {
        Console.Write("Please enter array lenght: ");
        int ArrayLenght = int.Parse(Console.ReadLine());
        int[] Sequence = new int[ArrayLenght];
        for (int i = 0; i < Sequence.Length; i++)
        {
            Console.Write("Please enter element: " + i + " : ");
            Sequence[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Please enter element value: ");
        int SearchValue = int.Parse(Console.ReadLine());
        Console.WriteLine("The value is in the array at position: " + BinarySearch(Sequence, SearchValue));
    }
}

