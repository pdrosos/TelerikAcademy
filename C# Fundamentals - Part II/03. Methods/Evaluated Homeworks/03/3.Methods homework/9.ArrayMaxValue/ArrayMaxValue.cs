using System;

class ArrayMaxValue
{
    static int MaxValueIndx(int[] array, int startIndex)
    {
        int maxValue = int.MinValue;
        int maxValueIndex = startIndex;
        for (int i = startIndex; i < array.Length; i++)
        {
            if (maxValue < array[i])
            {
                maxValue = array[i];
                maxValueIndex = i;
            }
        }
        return maxValueIndex;
    }
    static void SortInDescendingOrder(int[] array)
    {
        int container;
        int maxIndex;
        for (int i = 0; i < array.Length; i++)
        {
            if (MaxValueIndx(array, i) != i)
            {
                container = array[i];
                maxIndex = MaxValueIndx(array, i);
                array[i] = array[maxIndex];
                array[maxIndex] = container;
            }
        }
    }
    static void SortInAscendingOrder(int[] array)
    {
        SortInDescendingOrder(array);
        int container;
        for (int i = 0; i < array.Length/2; i++)
        {
            container = array[i];
            array[i] = array[array.Length - i - 1];
            array[array.Length - i - 1] = container;
        }
        
    }
    static void Main()
    {
        int[] myArray = new int[] {55,13,85,4,2};
        Console.WriteLine("Sorted in descending order:");
        SortInDescendingOrder(myArray);
        foreach (var item in myArray)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Sorted in ascending order:");
        SortInAscendingOrder(myArray);
        foreach (var item in myArray)
        {
            Console.WriteLine(item);
        }
    }
}
