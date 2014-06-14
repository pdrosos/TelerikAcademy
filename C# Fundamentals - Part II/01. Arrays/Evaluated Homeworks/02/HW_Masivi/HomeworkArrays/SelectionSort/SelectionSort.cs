/*Sorting an array means to arrange its elements in increasing order. 
 * Write a program to sort an array. Use the "selection sort" algorithm:
 * Find the smallest element, move it at the first position, 
 * find the smallest from the rest, move it at the second position, etc.
 */
using System;

class SelectionSort
{
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
        for (int i = 0; i < Sequence.Length - 1; i++)
        {
            int LowestElement = i;
            for (int j = i + 1; j < Sequence.Length; j++)
            {
                if (Sequence[j] < Sequence[LowestElement])
                {
                    LowestElement = j;
                }
            }
            if (LowestElement != i)
            {
                int ChangingVariable = 0;
                ChangingVariable = Sequence[i];
                Sequence[i] = Sequence[LowestElement];
                Sequence[LowestElement] = ChangingVariable;
            }
        }
        for (int i = 0; i < Sequence.Length; i++)
        {
            Console.Write(Sequence[i] + ",");
        }
    }
}