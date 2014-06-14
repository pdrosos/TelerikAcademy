using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the length of the array:");
        int arrayLength = int.Parse(Console.ReadLine());
        int[] arr = new int[arrayLength];
        Console.WriteLine("Enter the array members:");
              
        int freqNumCount = 0;
        for (int i = 0; i < arrayLength; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
            if (arr[i] == 0) 
            {
                freqNumCount++;
            }
        }

        int frequentNumber = 0;
        int testNumber = 0;
        int testNumCount = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                testNumber = arr[i];
                testNumCount = 0;
            }
            else 
            {
                continue;
            }

            for (int j = i+1; j < arr.Length; j++)
            {
                if (testNumber == arr[j]) 
                {
                    testNumCount++;
                    arr[j] = 0;
                }
                if (testNumCount > freqNumCount) 
                {
                    frequentNumber = testNumber;
                    freqNumCount = testNumCount;
                }
            }
        }
        if (frequentNumber == 0) 
        {
            freqNumCount--;
        }
        Console.WriteLine("Most Frequent number is {0}({1} times)",frequentNumber,freqNumCount +1);
    }
}

