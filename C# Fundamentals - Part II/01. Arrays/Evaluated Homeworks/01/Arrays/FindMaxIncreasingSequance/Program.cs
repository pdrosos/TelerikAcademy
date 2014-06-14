using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());
        int[] arr = new int[length];
        Console.WriteLine("Enter the array members:");
        for (int i = 0; i < length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int currentMember = arr[0];
        int currentCount = 1;
        int maxSequence = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            if (currentMember < arr[i])
            {
                currentCount++;
                currentMember = arr[i];
                if (currentCount > maxSequence)
                {
                    maxSequence = currentCount;
                }
            }
            else
            {
                currentMember = arr[i];
                currentCount = 1;
            }
        }
        Console.WriteLine("The maximal increasing sequence in array is: {0}", maxSequence);
    }
}