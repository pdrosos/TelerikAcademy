using System;
using System.Collections.Generic;
using System.Text;
//Write a program that reads an array of integers and removes from it a minimal number of elements in such way that the 
//remaining array is sorted in increasing order. Print the remaining sorted array. 
//Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} => {1, 3, 3, 4, 5}

class Program
{
    static void Main()
    {
        int[] myArray = {6, 1, 4, 3, 0, 3, 6, 4, 5};
        StringBuilder builder = new StringBuilder();

        string bestSubset = "";
        int bestCount = 0;
        string currentSubset = "";
        int currentCount = 0;
        int test = 0;
        int subsetCount = (int)Math.Pow(2, myArray.Length);

        for (int i = 1; i <= subsetCount; i++)
        {
                if (currentCount > bestCount)
                {
                    bestCount = currentCount;
                    bestSubset = currentSubset;
                }
                currentSubset = "";
                currentCount = 0;
                builder.Clear();

            for (int j = 0; j < myArray.Length; j++)
            {
               
                if ((i >> j & 1) == 1)
                {                                        
                    if (currentSubset == "")
                    {
                        test = myArray[j];
                        builder.Append(myArray[j]);
                        currentSubset = builder.ToString();
                        currentCount++;                   
                    }
                    else if (test <= myArray[j])
                    {
                        builder.Append(",").Append(myArray[j]);
                        currentSubset = builder.ToString();
                        currentCount++;
                    }
                    else
                    {
                        continue;
                    }
                    test = myArray[j];
                }

            }
            
        }
        Console.WriteLine("Remining sorted array:({0})", bestSubset);
    }
}

