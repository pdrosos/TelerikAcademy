namespace MobilePhones.UI
{
    using System;
    using MobilePhones.Library.Hardware;
    using MobilePhones.Library.Software;

    class GsmCallHistoryTest
    {
        public static void Test()
        {
            Gsm gsm = new Gsm("Galaxy S4", "Samsung", 1200, "Me", 
                new Battery(Battery.BatteryTypes.LiIon, null, 18, 6), 
                new Display(5, 16000000));
            Console.WriteLine(gsm);
            Console.WriteLine();

            // add calls
            gsm.CallsManager.AddCall(new Call(new DateTime(2013, 9, 29, 21, 35, 14), "+359888111222", 75));
            gsm.CallsManager.AddCall(new Call(new DateTime(2013, 8, 16, 9, 12, 45), "+359896111222", 10));
            gsm.CallsManager.AddCall(new Call(DateTime.Now, "+359878111222", 157));

            // print calls history
            Console.WriteLine("Calls history:");
            Console.WriteLine(gsm.CallsManager);
            Console.WriteLine();

            decimal pricePerMinute = 0.37m;

            // calls total price
            Console.WriteLine("Total price: " + gsm.CallsManager.GetTotalPrice(pricePerMinute));

            // remove longest call
            Call longestCall = GetLongestCall(gsm);
            gsm.CallsManager.RemoveCall(longestCall);
            Console.WriteLine("Total price after removing the longest call: " + gsm.CallsManager.GetTotalPrice(pricePerMinute));

            // clear calls history
            gsm.CallsManager.ClearCallsHistory();
            Console.WriteLine("Total price after clearing the calls history: " + gsm.CallsManager.GetTotalPrice(pricePerMinute));
            Console.WriteLine("Calls history:");
            Console.WriteLine(gsm.CallsManager);
        }

        private static Call GetLongestCall(Gsm gsm)
        {
            if (gsm.CallsManager.CallsHistory.Count == 0)
            {
                throw new Exception("Calls history is empty");
            }

            decimal duration = -1;
            Call longestCall = new Call(DateTime.Now, "dummy", 0);

            foreach (Call call in gsm.CallsManager.CallsHistory)
            {
                if (call.Duration > duration)
                {
                    duration = call.Duration;
                    longestCall = call;
                }
            }

            return longestCall;
        }
    }
}
