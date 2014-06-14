using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the length of the array: ");
        int arrayLength = int.Parse(Console.ReadLine());
        int[] arr = new int[arrayLength];
        Console.Write("Enter wanted sum:");
        int wantedSum = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the array members:");
        for (int i = 0; i < arrayLength; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        bool isPresent = false;
        int testSum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i; j < arr.Length; j++)
                {
                    testSum += arr[j];
                    if (testSum == wantedSum) 
                    {
                        isPresent = true;
                    }
                }
                testSum = 0;
        }

        if (isPresent)
        {
            Console.WriteLine("Wanted sum is present");
        }
        else 
        {
            Console.WriteLine("Wanted sum is not present");
        }
        
    }
}

                