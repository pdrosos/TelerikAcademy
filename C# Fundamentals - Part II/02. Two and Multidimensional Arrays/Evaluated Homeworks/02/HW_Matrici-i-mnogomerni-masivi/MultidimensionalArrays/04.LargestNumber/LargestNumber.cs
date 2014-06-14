//4.Write a program, that reads from the console an array of N integers and an integer K, 
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 


using System;

class LargestNumber
{
    static void Main()
    {

        Console.Write("Please enter how many integer you want to add in the array N=");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Please enter a value for K=");
        int k = int.Parse(Console.ReadLine());

        int [] array = new int[n];

        Console.WriteLine("Please enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        
        Array.Sort(array, (a, b) => a.CompareTo(b));
 
        int largestNumber = Array.BinarySearch(array, k);
       
        if (largestNumber < -1)
        {
            Console.WriteLine("The element {0} is <= K", array[~largestNumber - 1]);
        }
        else if (~largestNumber == 0)
        {
            Console.WriteLine("Can not be found smaller or equal to element K in the array!");
        }
        else Console.WriteLine("The element {0} is <= K", array[largestNumber]);
    }
    }


