using System;

class ArrayMultiplyBy5
{
    static void Main()
    {
        //Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. 
        //Print the obtained array on the console.

        int[] array = new int[19];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i * 5;
        }
        foreach (var member in array)
        {
            Console.WriteLine(member);
        }
    }
}
