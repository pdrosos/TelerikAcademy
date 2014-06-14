using System;

class Program
{
    static void Main()
    {
            Console.Write("Enter the length of the array: ");
            int arrayLength = int.Parse(Console.ReadLine());
            int[] arr = new int[arrayLength];
            Console.WriteLine("Enter the array members:");
            for (int i = 0; i < arrayLength; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int maxSum = 0;
            int testSum = 0;
            for (int i = 0; i < arr.Length; i++ )
            {
                testSum += arr[i];

                if (testSum > maxSum) 
                {
                    maxSum = testSum;
                }
                if (testSum < 0) 
                {
                    testSum = 0;
                }
            }
            Console.WriteLine("Max sum is: {0} ",maxSum);
    }
}
