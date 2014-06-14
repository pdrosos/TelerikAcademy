/* Write a program that finds the maximal
 * increasing sequence in an array. Example: 
 * {3, 2, 3, 4, 2, 2, 4} > {2, 3, 4}.
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
        int LastIndex = 0;
        for (int i = 0; i < Sequence.Length - 1; i++)
        {
            if (Sequence[i] < Sequence[i + 1])
            {
                Lenght++;
            }
            else
            {
                if (Lenght > BestLenght)
                {
                    BestLenght = Lenght;
                    LastIndex = i;
                }
                Lenght = 1;
            }
        }
        // checking a special last case
        if (Lenght > BestLenght)
        {
            BestLenght = Lenght;
            LastIndex = Sequence.Length - 1;
        }
        // output
        Lenght = 1;
        Console.WriteLine("The longest sequence of increasing elemints is:");
        Console.Write("{");
        for (int i = LastIndex - BestLenght + 1; i < LastIndex + 1; i++)
        {
            Console.Write("{0},", Sequence[i]);
        }
        Console.WriteLine("}");
    }
}

