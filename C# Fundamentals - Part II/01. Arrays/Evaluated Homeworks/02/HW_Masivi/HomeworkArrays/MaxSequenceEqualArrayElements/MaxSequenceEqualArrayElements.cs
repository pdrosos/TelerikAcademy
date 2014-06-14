/* Write a program that finds the maximal
 * sequence of equal elements in an array.
                Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} > {2, 2, 2}.
 */
using System;

class MaxSequenceEqualArrayElements
{
    static void Main()
    {
        Console.Write("Please enter array lenght: ");
        int ArrayLenght = int.Parse(Console.ReadLine());
        int[] Sequence = new int[ArrayLenght];
        for (int i = 0; i < Sequence.Length; i++)
        {
            Console.Write("Enter Array Element Value: ");
            Sequence[i] = int.Parse(Console.ReadLine());
        }
        int Lenght = 1;
        int BestLenght = 0;
        int BestLenghtElement = 0;
        for (int i = 0; i < Sequence.Length - 1; i++)
        {
            if (Sequence[i] == Sequence[i + 1])
            {
                Lenght++;
            }
            else
            {
                if (Lenght > BestLenght)
                {
                    BestLenght = Lenght;
                    BestLenghtElement = Sequence[i];
                }
                Lenght = 1;
            }
        }
        if (Lenght > BestLenght)
        {
            BestLenght = Lenght;
            BestLenghtElement = Sequence[Sequence.Length - 1];
        }
        for (int i = 0; i < BestLenght; i++)
        {
            Console.Write(BestLenghtElement);
        }
    }
}

