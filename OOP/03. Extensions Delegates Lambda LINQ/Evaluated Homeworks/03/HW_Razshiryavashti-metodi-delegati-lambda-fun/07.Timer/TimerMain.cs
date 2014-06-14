using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07.Timer
{
    class TimerMain
    {
        //a method to be executed
        private static void WriteMessageMethod(string message)
        {
            Console.WriteLine("Hello");
        }

        static void Main(string[] args)
        {
            Timer t = new Timer(1000, new MessageDelegate(WriteMessageMethod));

            while (true)
            {
                Console.WriteLine("Enter something:");
                string p = Console.ReadLine();
                Console.WriteLine("You entered: {0}", p);
            }
        }
    }
}
