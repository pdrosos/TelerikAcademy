using System;

class SearchInString
{
    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        int counter = 0,
            start = 0,
            index = 0;
        while (index >-1)
        {
            index = text.IndexOf("in", start); 
            start = index + 1; 
            counter++;
        }
        Console.WriteLine(counter);
    }
}

