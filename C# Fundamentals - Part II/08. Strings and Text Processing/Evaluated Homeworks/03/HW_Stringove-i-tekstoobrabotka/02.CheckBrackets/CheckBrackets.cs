using System;
using System.Linq;

class CheckBrackets
{
    static void Main()
    {
        Console.WriteLine("Type expression:");
        string str = Console.ReadLine();

        int count = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '(')
            {
                count++;
            }
            if (str[i] == ')')
            {
                count--;   
            }
            if (count < 0)
            {
                break;
            }
        }
        if (count == 0)
        {
            Console.WriteLine("The expression is correct");
        }
        else
        {
            Console.WriteLine("The expression is incorrect");
        } 
    }
}
