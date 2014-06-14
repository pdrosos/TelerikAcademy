namespace Timers
{
    using System;
    using System.Threading;

    public class Timer
    {
        private int seconds;

        public Timer(int seconds)
        {
            this.Seconds = seconds;
        }

        public int Seconds
        {
            get
            {
                return this.seconds;
            }
            set
            {
                this.seconds = value;
            }
        }

        public void Start(Action userMethod)
        {
            while (true)
            {
                Thread.Sleep(this.Seconds * 1000);
                userMethod();
            }
        }
    }
}
