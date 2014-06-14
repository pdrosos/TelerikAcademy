using System;

class CheckBrackets
{
    static bool BracketsChecker(string input)
    {
        bool result = false;
        int check = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (check < 0)
            {
                result = false;
                return result;
            }
            if (input[i] == '(')
            {
                check++;
            }
            else if (input[i] == ')')
            {
                check--;
            }
        }
        if (check == 0)
        {
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }

    static void Main()
    {
        string right = "((a+b)/5-d)";
        string wrong = ")(a+b))";
        Console.WriteLine(BracketsChecker(right));
        Console.WriteLine(BracketsChecker(wrong));
    }
}

