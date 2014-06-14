using System;
using System.Collections.Generic;
//Write a program that sorts an array of strings using the quick sort algorithm 
class Program
{
    static void Main()
    {
        List<string> myList = new List<string>(new string[] { "f", "a", "b", "h", "m", "q", "c", "i", "l" });
        myList = QuickSort(myList, 0, myList.Count - 1);
        foreach (var item in myList)
        {
            Console.Write(item + " ");
        }
    }

    private static List<string> QuickSort(List<string> list, int left, int right)
    {
        int i = left;
        int j = right;
        string leftString = list[i];
        string rightString = list[j];
        string middle = list[(left + right) / 2]; 
        //double pivotValue = ((left + right) / 2);
        //string middle = a[Convert.ToInt32(pivotValue)];
        string temp = null;
        while (i <= j)
        {
            while (list[i].CompareTo(middle) < 0)
            {
                i++;
                leftString = list[i];
            }
            while (list[j].CompareTo(middle) > 0)
            {
                j--;
                rightString = list[j];
            }
            if (i <= j)
            {
                temp = list[i];
                list[i++] = list[j];
                list[j--] = temp;
            }
        }
        if (left < j)
        {
            QuickSort(list, left, j);
        }
        if (i < right)
        {
            QuickSort(list, i, right);
        }
        return list;
    }
}

