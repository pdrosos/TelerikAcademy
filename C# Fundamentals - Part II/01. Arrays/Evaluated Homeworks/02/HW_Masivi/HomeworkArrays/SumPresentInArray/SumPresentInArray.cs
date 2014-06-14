/* Write a program that finds in given array of
 * integers a sequence of given sum S (if present).
 * Example:      {4, 3, 1, 4, 2, 5, 8}, S=11 > {4, 2, 5} */
using System;
using System.Text;

class SumPresentInArray
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
        Console.Write("Please enter the sequence sum for search: ");
        int SearchSequenceSum = int.Parse(Console.ReadLine());
        string FoundSequence = "";
        StringBuilder SequenceBuild = new StringBuilder();
        for (int i = 0; i < Sequence.Length; i++)
        {
            int sum = 0;
            for (int j = i; j < Sequence.Length; j++)
            {
                sum = sum + Sequence[j];
                SequenceBuild.AppendFormat("{0}, ", Sequence[j]);

                if (sum > SearchSequenceSum)
                {
                    SequenceBuild.Clear();
                    sum = 0;
                    break;
                }
                if (sum == SearchSequenceSum)
                {
                    FoundSequence = SequenceBuild.ToString();
                    Console.WriteLine("S=" + SearchSequenceSum + " -> " + "{" + FoundSequence + "}");
                }
            }
        }
    }
}

