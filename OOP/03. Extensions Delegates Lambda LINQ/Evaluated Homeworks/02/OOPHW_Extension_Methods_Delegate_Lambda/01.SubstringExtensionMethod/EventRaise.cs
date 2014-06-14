///08.* Read in MSDN about the keyword event in C# and how to publish events.
///Re-implement the above using .NET events and following the best practices.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SubstringExtensionMethod
{
   
   public class EventRaiseTimer
    {
       //Create delegate
        public EventArgs e = null;
        public delegate void TimerDelegate(EventRaiseTimer time, EventArgs e);
        //Create event from TimerDelegate type
        public event TimerDelegate myEvent;
        

        public void RaiseMyEvent()
        {
            int repeat = 5;
            while (repeat>0)
            {
                System.Threading.Thread.Sleep(3000);
                if (myEvent != null)
                {
                    myEvent(this, e);
                    repeat--;
                }
            }
        }

       
   }
   public class EventListener
   {
       public void Subscribe(EventRaiseTimer time)
       {
           //Add 2 methods to event 
           time.myEvent += new EventRaiseTimer.TimerDelegate(HeardIt);
           time.myEvent += new EventRaiseTimer.TimerDelegate(ShowTime);
       }
       private void HeardIt(EventRaiseTimer time, EventArgs e)
       {
           System.Console.WriteLine("You raised event!");
       }
       private void ShowTime(EventRaiseTimer time, EventArgs e)
       {
           Console.WriteLine("Hello, the time is {0}", DateTime.Now.ToLongTimeString());

       }

   }
}
