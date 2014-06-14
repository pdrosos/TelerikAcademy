using System;
//Write a program that reads three integer numbers N, K and S and an array of N elements from the console.
//Find in the array a subset of K elements that have sum S or indicate about its absence
class Program
{
    static void Main()
    {
        Console.Write("Enter the length of the array: ");
        int arrayLength = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int limit = int.Parse(Console.ReadLine());
        Console.Write("Enter wanted sum: ");
        int wantedSum = int.Parse(Console.ReadLine());        
        int[] myArray = new int[arrayLength];
        Console.WriteLine("Enter the array members:");
        for (int i = 0; i < arrayLength; i++)
        {
            myArray[i] = int.Parse(Console.ReadLine());
        }
        

        int count = (int)Math.Pow(2, myArray.Length);

        
        int testSum = 0;
        int subsetMemberCount = 0;
        bool isExist = false;
        for (int i = 1; i <= count; i++)
        {
            for (int j = 0; j < myArray.Length; j++)
            {
                if ((i >> j & 1) == 1)
                {
                    testSum += myArray[j];
                    subsetMemberCount++;
                }
            }
            if (testSum == wantedSum && limit == subsetMemberCount)
            {
                isExist = true;
                break;
            }
            else
            {
                testSum = 0;
                subsetMemberCount = 0;
            }
        }
        if (isExist == false)
        {
            Console.WriteLine("Sum not exist");
        }
        else 
        {
            Console.WriteLine("Sum exist");
        }
    }
}

