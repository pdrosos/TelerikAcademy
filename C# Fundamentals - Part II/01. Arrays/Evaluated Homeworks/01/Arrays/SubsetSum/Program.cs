using System;
using System.Text;
//We are given an array of integers and a number S. Write a program to find if 
//there exists a subset of the elements of the array that has a sum S
class Program
{
    static void Main()
    {
        int[] myArray = {2, 1, 2, 4, 3, 5, 2, 6};
        int wantedSum = 14;

        int count = (int)Math.Pow(2, myArray.Length);

        StringBuilder builder = new StringBuilder();
        int testSum = 0;
        bool isExist = false;
        for (int i = 1; i <= count; i++)
        {
            for (int j = 0; j < myArray.Length; j++) 
            {
                if ((i >> j & 1) == 1) 
                {
                    if(testSum == 0)
                    {
                        builder.Append(myArray[j]);
                    }
                    else
                    {
                        builder.Append("+").Append(myArray[j]);
                    }
                    testSum += myArray[j];
                }
            }
            if (testSum == wantedSum)
            {
                Console.WriteLine("Yes({0})", builder);
                isExist = true;
            }
            else 
            {
                testSum = 0;
                builder.Clear();
            }
        }
        if (isExist == false)
        {
            Console.WriteLine("Sum not exist");
        }
    }
}

