using System;

class BiggerThanNeighbors
{
    static void CheckIfBigger(int position, int[] array)
    {
        if ((position == 0) || (position >= array.Length))
        {
            Console.WriteLine("The number at this position don't have two neighbours.");
        }
        else
        {
            if (array[position] > array[position - 1] && array[position] > array[position + 1])
            {
                Console.WriteLine("The number at position {0} is bigger than its neighbors.", position);
            }
        }
    }
    static void Main()
    {
        int[] array = new int[] { 1,5,3,2,6,4,6,8,7,3,};
        int index = 4;
        foreach (var item in array)
        {
            Console.Write(item +" ");
        }
        Console.WriteLine();
        CheckIfBigger(index, array);
    }
}
