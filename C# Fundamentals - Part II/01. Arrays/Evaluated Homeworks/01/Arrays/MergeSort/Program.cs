using System;
//Merge sort
class Program
{
    static void Main()
    {
        int[] myArray = { 2, 9, 5, 1, 3, 4, 8, 7, 6 };
        int[] result = MergeSort(myArray);
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }

    }

    private static int[] MergeSort(int[] myArray)
    {

        if (myArray.Length == 1)
        {
            return myArray;
        }

        int mid = myArray.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[myArray.Length - mid];

        for (int i = 0; i < mid; i++)
        {
            left[i] = myArray[i];
        }
        for (int i = 0; i < myArray.Length - mid; i++)
        {
            right[i] = myArray[i + mid];
        }

        left = MergeSort(left);
        right = MergeSort(right);

        int[] result = new int[myArray.Length];
        int leftPoint = 0;
        int rightPoint = 0;

        for (int i = 0; i < result.Length; i++)
        {
            if (rightPoint == right.Length || ((leftPoint < left.Length) && (left[leftPoint] <= right[rightPoint])))
            {
                result[i] = left[leftPoint];
                leftPoint++;
            }
            else if (leftPoint == left.Length || ((rightPoint < right.Length) && (right[rightPoint] <= left[leftPoint])))
            {
                result[i] = right[rightPoint];
                rightPoint++;
            }
        }
        return result;
    }
}



