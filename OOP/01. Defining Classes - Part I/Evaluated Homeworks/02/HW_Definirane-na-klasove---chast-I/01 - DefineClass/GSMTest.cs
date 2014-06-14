using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    class GSMTest
    {
  
        static void Main()
        {
        GSM[] arrayOfPhones = new GSM[3];
        Battery battery1 = new Battery("b1", 5, 8, BatteryType.NiMH);
        Display display1 = new Display(3, 2560000);
        arrayOfPhones[0] = new GSM("E6-00", "Nokia", 700, "Pesho", battery1, display1);
        arrayOfPhones[1] = new GSM("3310", "Nokia");
        arrayOfPhones[2] = GSM.iPhone4S;
        

        Call call1 = new Call(new DateTime(2013,10,7,10,17,28),"+3591111222333",54);
        Call call2 = new Call(new DateTime(2013, 12, 10, 15, 47, 26), "+359885222654", 170);
        Call call3 = new Call(new DateTime(2012, 2, 5, 15, 47, 26), "+359883242674", 10);

        foreach (var phone in arrayOfPhones)
        {
            Console.WriteLine(phone.ToString());
        }

        arrayOfPhones[0].AddCall(call1);
        arrayOfPhones[0].AddCall(call2);
        arrayOfPhones[0].AddCall(call3);

        arrayOfPhones[0].showHistory(arrayOfPhones[0].callHistory);
        arrayOfPhones[0].showBill(arrayOfPhones[0].calcCost(0.37m));
        int longestCall = 0;
        int maxDuration = 0;
        for (int i = 0; i < arrayOfPhones[0].callHistory.Count; i++)
        {
            
            if (maxDuration < arrayOfPhones[0].callHistory[i].Duration)
            {
                maxDuration = arrayOfPhones[0].callHistory[i].Duration;
                longestCall = i;
            }
        }
        arrayOfPhones[0].DeleteCalls(longestCall);
        arrayOfPhones[0].showHistory(arrayOfPhones[0].callHistory);
        arrayOfPhones[0].showBill(arrayOfPhones[0].calcCost(0.37m));
        arrayOfPhones[0].clearCalls();
        arrayOfPhones[0].showHistory(arrayOfPhones[0].callHistory);
        
        }
    }
}
