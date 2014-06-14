using System;
//Array - Selection sort
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
            
            for (int i = 0; i < arr.Length; i++) 
            {
                for (int j = i + 1; j < arr.Length; j++) 
                {
                    if (arr[i] > arr[j]) 
                    {
                        arr[i] ^= arr[j];
                        arr[j] ^= arr[i];
                        arr[i] ^= arr[j];
                    }               
                }
            }
            Console.WriteLine("Sorted array:");
            foreach (int item in arr)
            {
                Console.Write("{0} ",item);
            }
            Console.WriteLine();

           
        }
    }

