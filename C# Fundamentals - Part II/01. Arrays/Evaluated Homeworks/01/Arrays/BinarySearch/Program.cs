using System;
//Binary search
class Program
{
    static void Main()
    {
        
        int[] myArray = { 2, 4, 7, 9, 15, 23, 45, 67, 90, 103 };
        int index; //result index;
        int search = 90; //what to find;
        index = binarySearch(myArray, search);
        Console.WriteLine(index);
        
    }

    private static int binarySearch(int[] myArray, int search)
    {
        int start = 0;
        int end = myArray.Length - 1;
        int mid;
        while (start <= end) 
        {
            mid = (start + end) / 2;
            if (myArray[mid] == search) 
            {
                return mid;
            }
            else if (myArray[mid] < search)
            {
                start = mid + 1;
            }
            else 
            {
                end = mid - 1;
            }
        }
        return -1; //if not found
    }
}

