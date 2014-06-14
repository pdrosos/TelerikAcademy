using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace _07.UseTimer
{
    public delegate void TimerDelegate(int ticks);

    class Timer
    {
        private int ticksCount;
        private int interval;
        private TimerDelegate callback;

        public int TicksCount
        {
            get { return this.ticksCount; }
        }

        public int Interval
        {
            get { return this.interval; }
        }

        public Timer(int ticksCount, int interval, TimerDelegate callback)
        {
            this.ticksCount = ticksCount;
            this.interval = interval;
            this.callback = callback;
        }

        public void Run()
        {
            int ticks = this.ticksCount;

            while (ticks > 0)
            {
                Thread.Sleep(this.interval);
                ticks--;
                this.callback(ticks);
            }
        }

    }
}
