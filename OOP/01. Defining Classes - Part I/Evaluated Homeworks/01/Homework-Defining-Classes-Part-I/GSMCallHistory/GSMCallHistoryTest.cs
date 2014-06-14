using System;

class GSMCallHistoryTest
{
    static void Main()
    {
        decimal pricePerMinute = 0.37M;

        GSM tel = new GSM();
        tel.AddCall("0888688", 100);
        tel.AddCall("0888848", 50);
        tel.AddCall("0888688", 150);
        Console.WriteLine("The call history is:\n" + tel);

        decimal totalPrice = tel.TotalPrice(pricePerMinute);
        Console.WriteLine("The total price of calls is: {0:c2}", totalPrice);
        Console.WriteLine();

        int max = int.MinValue;
        string dialedNumber = null;

        foreach (var item in tel.CallHistory)
        {
            if (item.Duration > max)
            {
                max = item.Duration;
                dialedNumber = item.DialedPhoneNumber;
            }
        }

        tel.DeleteCall(dialedNumber, max);
        totalPrice = tel.TotalPrice(pricePerMinute);
        Console.WriteLine("The call history after removing the longest call is:\n" + tel);
        Console.WriteLine("The total price of calls is: {0:c2}", totalPrice);

        tel.ClearCalls();
        Console.WriteLine(tel);
    }
}