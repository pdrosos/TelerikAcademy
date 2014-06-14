namespace EventsTimers
{
    using System;
    using System.Threading;

    public class Timer
    {
        private int seconds;

        // Delegate
        public delegate void Callback();
        // Publish the event
        public event Callback ElapsedSeconds;

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

        // The method which fires the Event
        public void Start()
        {
            while (true)
            {
                Thread.Sleep(this.Seconds * 1000);

                // Make a temporary copy of the event to avoid possibility of 
                // a race condition if the last subscriber unsubscribes 
                // immediately after the null check and before the event is raised.
                Callback handler = ElapsedSeconds;

                // Event will be null if there are no subscribers 
                if (handler != null)
                {
                    // Use the () operator to raise the event.
                    handler();
                }
            }
        }
    }
}
