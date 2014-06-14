namespace EventsTimers
{
    using System;

    /// <summary>
    /// Read in MSDN about the keyword event in C# and how to publish events. 
    /// Re-implement the above using .NET events and following the best practices.
    /// </summary>
    class Test
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(1);

            // Subscribe to event
            timer.ElapsedSeconds += new Timer.Callback(() =>
                Console.WriteLine(DateTime.Now)
            );
            timer.Start();
        }
    }
}
