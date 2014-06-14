using System;

class FindSubsetOfSum
{
    static void Main()
    {
        //* We are given an array of integers and a number S. Write a program to find if there exists 
        //a subset of the elements of the array that has a sum S. Example:
	    //arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)

        int[] array = { 2, 1, 2, 4, 3, 5, 2, 6 };
        int sum = 14;

        for (int i = 0; i < array.Length; i++)
        {
            int tempSum = array[i];
            for (int j = 0; j < array.Length; j++)
            {
                if (j != i)
                {
                    tempSum += array[j];
                    if (tempSum == sum)
                    {
                        Console.Write("yes(");
                        for (int k = i; k < j; k++)
                        {
                            Console.Write(array[k] + "+");
                        }
                        Console.Write("{0})", array[j]);
                        Console.WriteLine();
                    }
                }
            }
            tempSum = 0;
        }
    }
}
