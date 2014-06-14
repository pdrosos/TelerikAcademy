using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the first char array elements:");
        string first = Console.ReadLine();
        char[] arr1 = first.ToCharArray();
        Console.WriteLine("Enter the second char array elements:");
        string second = Console.ReadLine();
        char[] arr2 = second.ToCharArray();

        int minLenght = Math.Min(arr1.Length, arr2.Length);

        for (int i = 0; i < minLenght; i++) 
        {
            if (arr1[i] < arr2[i]) 
            {
                Console.WriteLine("The first char array is lexicografically before the second.");
                return;
            }
            if(arr1[i] > arr2[i])
            {
                Console.WriteLine("The second char array is lexicografically before the first.");
                return;
            }
        }

        if (arr1.Length == arr2.Length) 
        {
            Console.WriteLine("The arrays are equal");
        }
        else if(arr1.Length < arr2.Length)
        {
            Console.WriteLine("The first char array is lexicografically before the second.");
        }
        else if (arr1.Length > arr2.Length)
        {
            Console.WriteLine("The second char array is lexicografically before the first.");
        }
    }
}

