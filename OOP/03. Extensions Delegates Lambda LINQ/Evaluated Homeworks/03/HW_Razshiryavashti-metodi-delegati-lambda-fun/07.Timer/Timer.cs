using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace _07.Timer
{
    public delegate void MessageDelegate(string message);

    class Timer
    {
        //07.Using delegates write a class Timer that has can execute \
        //certain method at each t seconds.

        public int MilisecondsDelay { get; set; }
        public MessageDelegate messageDelegate { get; set; }

        public Timer(int milisecondsDelay, MessageDelegate method)
        {
            this.MilisecondsDelay = milisecondsDelay;
            this.messageDelegate = method;

            //initialize new thread for the Worker method
            Thread th = new Thread(new ThreadStart(NewThreadWorker));
            th.Start();
        }

        private void NewThreadWorker()
        {
            while (true)
            {
                Thread.Sleep(MilisecondsDelay);
                if (this.messageDelegate != null)
                    this.messageDelegate("");
            }
        }
    }
}
