using System;

class RepetitionsOfNumberInArr
{
    static void GetRepetitions(int number, int[] array)
    {
        int repetitions = 0;
        foreach (var arrayNumber in array)
        {
            if (arrayNumber == number)
            {
                repetitions++;
            }
        }
        Console.WriteLine("The number of repetitions of number {0} is {1}", number, repetitions);
    }
    static void Main()
    {
        int[] myArray = new int[] { 1, 5, 7, 1, 1, 2, 7, 9, 3};
        int myNumber = 7;

        GetRepetitions(myNumber, myArray);
    }
}
