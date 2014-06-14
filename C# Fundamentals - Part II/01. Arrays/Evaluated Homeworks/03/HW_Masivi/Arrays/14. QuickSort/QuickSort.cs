using System;
using System.Collections.Generic;
using System.Text;

class QuickSort
{
    //Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

    static int Partition(int[] array, int left, int right)
    {
        int pivot = array[left];
        while (true)
        {
            while (array[left] < pivot)
                left++;

            while (array[right] > pivot)
                right--;

            if (left < right)
            {
                int temp = array[right];
                array[right] = array[left];
                array[left] = temp;
            }
            else
            {
                return right;
            }
        }
    }

    struct QuickPosInfo
    {
        public int left;
        public int right;
    };

    static public void quickSort(int[] array, int left, int right)
    {

        if (left >= right)
            return;

        List<QuickPosInfo> list = new List<QuickPosInfo>();

        QuickPosInfo info;
        info.left = left;
        info.right = right;
        list.Insert(list.Count, info);

        while (true)
        {
            if (list.Count == 0)
                break;

            left = list[0].left;
            right = list[0].right;
            list.RemoveAt(0);

            int pivot = Partition(array, left, right);

            if (pivot > 1)
            {
                info.left = left;
                info.right = pivot - 1;
                list.Insert(list.Count, info);
            }

            if (pivot + 1 < right)
            {
                info.left = pivot + 1;
                info.right = right;
                list.Insert(list.Count, info);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("array[{0}]: ", i);
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        quickSort(array, 0, array.Length - 1);

        foreach (var item in array)
        {
            Console.WriteLine(item);
        }

    }
}