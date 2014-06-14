using System;

class FindASequenceOfGivenSum
{
    static void Main()
    {
        //Write a program that finds in given array of integers a sequence of given sum S (if present). 
        //Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}

        Console.Write("N: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("array[{0}]: ", i);
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("Enter sum to search for: ");
        int sum = Convert.ToInt32(Console.ReadLine());

       
        
        for (int i = 0; i < array.Length - 1; i++)
        { 
            int tempSum = 0;
            for (int j = i; j < array.Length; j++)
            {
                tempSum = tempSum + array[j];
                if (tempSum == sum)
                {
                    Console.Write("Example of a sequnce: {");
                    for (int k = i; k < j; k++)
                    {
                        Console.Write("{0}, ", array[k]);
                    }
                    Console.Write("{0}}}", array[j]);
                    Console.WriteLine();
                }
                
            }
        }
    }
}
