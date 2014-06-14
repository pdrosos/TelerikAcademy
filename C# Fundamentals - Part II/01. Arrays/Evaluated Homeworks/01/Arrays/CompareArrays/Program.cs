using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the length of the first array: ");
        int length1 = int.Parse(Console.ReadLine());       
        Console.Write("Enter the length of the second array: ");
        int length2 = int.Parse(Console.ReadLine());        

        if (length1 == length2)
        {
            int[] arr1 = new int[length1];
            Console.WriteLine("Enter the first array members:");
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = int.Parse(Console.ReadLine());
            }

            int[] arr2 = new int[length2];
            Console.WriteLine("Enter the second array members:");
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = int.Parse(Console.ReadLine());
            }

            bool areEqual = CompareArrays(arr1, arr2);

            if (areEqual)
            {
                Console.WriteLine("The arrays are equal");
            }
            else 
            {
                Console.WriteLine("The arrays are not equal");
            }
        }
        else 
        {
            Console.WriteLine("The arrays are not equal");
        }
    }

    private static bool CompareArrays(int[] arr1, int[] arr2)
    {
        for (int i = 0; i < arr1.Length; i++) 
        {
            if (arr1[i] != arr2[i]) 
            {
                return false;
            }
        }
        return true;
    }
}

