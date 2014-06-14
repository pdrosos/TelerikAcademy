namespace MobilePhones.UI
{
    using System;
    using MobilePhones.Library.Hardware;

    class GsmTest
    {
        public static void Test()
        {
            Gsm[] gsmData = 
            {
                new Gsm("Lumia", "Nokia"),
                new Gsm("Galaxy S4", "Samsung", 1200, null, 
                    new Battery(Battery.BatteryTypes.LiIon, null, 12, 8), 
                    new Display(5, 16000000)),
            };

            foreach (Gsm gsm in gsmData)
            {
                Console.WriteLine(gsm);
                Console.WriteLine();
            }

            Console.WriteLine(Gsm.IPhone4S);
        }
    }
}
