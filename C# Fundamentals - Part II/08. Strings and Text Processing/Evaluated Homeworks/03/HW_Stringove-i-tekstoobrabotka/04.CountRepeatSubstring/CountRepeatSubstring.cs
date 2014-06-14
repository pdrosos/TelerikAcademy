using System;
using System.Linq;

class CountRepeatSubstring
{
    static void Main()
    {
        string str = @"We are living in an yellow submarine. We don
        't have anything else. Inside the submarine is very tight. So
        we are drinking all the day. We will move out of it in 5 days.";
        string substr = "in";

        //Console.WriteLine("Type string: ");        
        //Console.WriteLine("Type string: ");
        //string str = Console.ReadLine();
        //Console.WriteLine("Type substring to search:");
        //string substr = Console.ReadLine();
        int count = 0;
        int index = -1;
        while (true)
        {
            index = str.IndexOf(substr, index + 1);
            if (index == -1 )
            {
                break;
            }
            count++;
        }
        Console.WriteLine("The string {0} in string is {1} times", substr, count);
    }
}
