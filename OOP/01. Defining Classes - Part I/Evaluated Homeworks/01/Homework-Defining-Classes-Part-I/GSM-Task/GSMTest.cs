using System;

class GSMTest
{
    static void Main()
    {
        try
        {
            GSM phone1 = new GSM("A30", "Alcatel");
            GSM phone2 = new GSM("N30", "Nokia");
            GSM phone3 = new GSM("S30", "Samsung");
            GSM[] phones = new GSM[] { phone1, phone2, phone3 };

            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
                Console.WriteLine();
            }

            Console.WriteLine(GSM.IPhone4S);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }

    }
}