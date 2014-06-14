/*Write a program that finds the most frequent number in an array. Example:
 * 	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} > 4 (5 times)
 */
using System;
using System.Collections.Generic;

class MostFrequentNumberInArray
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
        Dictionary<int, int> MostFrequent = new Dictionary<int, int>();
        int Element = 0;
        int Frequnecy = int.MinValue;
        for (int i = 0; i < Sequence.Length; i++)
        {
            int ChangingValue;
            if (MostFrequent.TryGetValue(Sequence[i], out ChangingValue))
            {
                MostFrequent[Sequence[i]] = ChangingValue + 1;
            }
            else
            {
                MostFrequent.Add(Sequence[i], 1);
            }
        }
        foreach (var element in MostFrequent)
        {
            if (element.Value > Frequnecy)
            {
                Element = element.Key;
                Frequnecy = element.Value;
            }
        }
        Console.WriteLine(Element + " " + "({0} times)", Frequnecy);
    }
}