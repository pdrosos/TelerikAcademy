//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
using System;
using System.Collections.Generic;

class QuickSortArray
{
    static List<int> QuickSort(List<int> PrimaryList)
    {
        if (PrimaryList.Count <= 1)
        {
            return PrimaryList;
        }
        int PivotElement = PrimaryList.Count / 2;
        int PivotValue = PrimaryList[PivotElement];
        PrimaryList.RemoveAt(PivotElement);
        List<int> FirstHalf = new List<int>();
        List<int> SecondHalf = new List<int>();
        foreach (int Element in PrimaryList)
        {
            if (Element <= PivotValue)
            {
                FirstHalf.Add(Element);
            }
            else
            {
                SecondHalf.Add(Element);
            }
        }
        List<int> Result = new List<int>();
        Result.AddRange(QuickSort(FirstHalf));
        Result.Add(PivotValue);
        Result.AddRange(QuickSort(SecondHalf));
        return Result;

    }
    static void Main()
    {
        Console.Write("Please enter array lenght: ");
        int ArrayLenght = int.Parse(Console.ReadLine());
        List<int> Sequence = new List<int>(ArrayLenght);
        for (int i = 0; i < Sequence.Capacity; i++)
        {
            Console.Write("Please enter element: " + i + " : ");
            Sequence.Add(int.Parse(Console.ReadLine()));
        }
        List<int> ResultantArray = QuickSort(Sequence);
        foreach (var Element in ResultantArray)
        {
            Console.Write(Element + " ");
        }
    }
}