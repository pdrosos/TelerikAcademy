using System;
using System.Text;
using System.Collections.Generic;

class GSM
{
    private List<Call> callHistory = new List<Call>();

    public List<Call> CallHistory
    {
        get
        {
            return this.callHistory;
        }
        private set 
        {
            this.callHistory = value;
        }
    }

    public void AddCall(string dialedPhoneNumber, int duration)
    {
        this.CallHistory.Add(
            new Call(dialedPhoneNumber, duration));
    }

    public void DeleteCall(string dialedPhoneNumber, int duration)
    {
        List<Call> changedHistory = new List<Call>();

        foreach (var item in this.CallHistory)
        {
            if (item.DialedPhoneNumber != dialedPhoneNumber || item.Duration != duration)
            {
                changedHistory.Add(item);
            }
        }

        this.CallHistory = changedHistory;
    }

    public void ClearCalls()
    {
        this.CallHistory.Clear();
    }

    public decimal TotalPrice(decimal pricePerMinute)
    {
        decimal totalPrice = 0;

        foreach (var item in this.CallHistory)
        {
            totalPrice += ((item.Duration / 60.0m) * pricePerMinute);
        }

        return totalPrice;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        foreach (var item in this.CallHistory)
        {
            result.Append(item + "\n");
        }

        return result.ToString();
    }
}