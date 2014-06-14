using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace _08.KeywordEvent
{
    class Publisher
    {
        public delegate void TimerDelegate(Publisher pub, EventArgs e);   //delegate to which the event attaches
        public event TimerDelegate RaiseCustomEvent;                      //event with custom event message

        public EventArgs e = null;                                      //event arguments
        public int TimeInterval { get; set; }
        private int counter = 0;

        public void Start()
        {
            while (counter < 20)
            {
                if (RaiseCustomEvent != null)
                {
                    RaiseCustomEvent(this, e);
                }
                Thread.Sleep(TimeInterval);
                counter++;
            }
        }
    }
}
