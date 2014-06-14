using System;
using System.Collections.Generic;

    class SortByLength
    {      
        
        static void Main(string[] args)
        {
            string[] arr = { "asdc", "wdsc1", "as", "awe", "a" };
            foreach (string element in arr)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i].Length > arr[j].Length)
                    {
                        string temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }               
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            
        }
    }

