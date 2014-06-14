using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.KeywordEvent
{
    class MainProg
    {
        static void Main()
        {
            Publisher pub = new Publisher();                   //publisher is the class that causes an event at a set interval
            Subscriber sub = new Subscriber();                 //subscriber subcribes to event notifications and prints a message at each event

            pub.TimeInterval = 1000;              //sets the time-interval in ms.
            sub.Subscribe(pub);

            Console.WriteLine("This event will repeat 20 times");
            pub.Start();
        }
    }
}
