/*Write a program that finds the sequence of maximal sum in given array. Example:
 * 	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8} > {2, -1, 6, 4}
 * 	Can you do it with only one loop (with single scan through the elements of the array)?
 */
using System;
using System.Text;

class SequenceOfMaxSumInArray
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
        int CurrentSum = 0;
        int BestSum = int.MinValue;
        StringBuilder BestSequenceBuild = new StringBuilder();
        string BestSequnce = "";
        for (int i = 0; i < Sequence.Length; i++)
        {
            CurrentSum = CurrentSum + Sequence[i];
            BestSequenceBuild.AppendFormat("{0}, ", Sequence[i]);
            if (CurrentSum > BestSum)
            {
                BestSum = CurrentSum;
                BestSequnce = BestSequenceBuild.ToString();
            }
            if (CurrentSum < 0)
            {
                CurrentSum = 0;
                BestSequenceBuild.Clear();
            }
        }
        Console.WriteLine("The best sequence is: " + BestSequnce);
        Console.WriteLine("The best sum is: " + BestSum);
    }
}