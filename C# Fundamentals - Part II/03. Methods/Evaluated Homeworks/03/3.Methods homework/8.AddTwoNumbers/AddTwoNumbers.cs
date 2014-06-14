using System;

class AddTwoNumbers
{
    static int[] AddNumbers(int number1, int number2)
    {
        int[] arrNumber1 = new int[100000];
        int[] arrNumber2 = new int[100000];
        int[] result = new int[100000]; 

        int dividedNumber = number1;
        int remainder = 0;

        for (int i = 0; i < arrNumber1.Length; i++)
        {
            remainder = dividedNumber%10;
            dividedNumber = dividedNumber/10;
            arrNumber1[i] = remainder;
        }

        dividedNumber = number2;
        remainder = 0;
        for (int i = 0; i < arrNumber2.Length; i++)
        {
            remainder = dividedNumber % 10;
            dividedNumber = dividedNumber / 10;
            arrNumber2[i] = remainder;
        }
        int inMind = 0;
        for (int i = 0; i < result.Length; i++)
        {
            if (inMind == 1)
            {
                arrNumber1[i]++;
            }
            if (arrNumber1[i] + arrNumber2[i] >= 10)
            {
                result[i] = ((arrNumber1[i] + arrNumber2[i]) % 10);
                inMind = 1;
            }
            else
            {
                result[i] = (arrNumber1[i] + arrNumber2[i]);
                inMind = 0;
            }
        }

        return result;

    }
    static void Main()
    {
        int number1 =  123;
        int number2 = 1234;
        int[] result = new int[100000];
        result = AddNumbers(number1, number2);
        for (int i = result.Length-1; i >= 0; i--)
        {
            if (result[i] == 0)
            {
            }
            else
            {
                Console.Write(result[i]);
            }
        }
        Console.WriteLine();

    }
}
