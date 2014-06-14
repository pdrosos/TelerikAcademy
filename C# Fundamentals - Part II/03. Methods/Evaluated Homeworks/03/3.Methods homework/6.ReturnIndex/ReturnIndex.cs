using System;

class ReturnIndex
{
    static int CheckIfBigger(int position, int[] array)
    {
        if ((position == 0) || (position > array.Length - 1))
        {
            return -1;
        }
        else
        {
            if (array[position] > array[position - 1] && array[position] > array[position + 1])
            {
                return position;
            }
            else
            {
                return -1;
            }
        }
    }
    static int IndexOfBigger(int[] array)
    {
        for (int i = 1; i < array.Length-1; i++)
        {
            if (CheckIfBigger(i, array) != -1)
            {
                return i;
            }
        }
        return -1;
    }
    static void Main()
    {
        int[] array = new int[] {1, 2, 3, 4, 5, 8, 7 };
        Console.WriteLine(IndexOfBigger(array));
    }
}
