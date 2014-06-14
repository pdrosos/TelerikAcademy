namespace Timers
{
    using System;

    /// <summary>
    /// Using delegates write a class Timer that has can execute certain method at each t seconds.
    /// </summary>
    class Test
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(1);

            timer.Start(new Action(() => 
                Console.WriteLine(DateTime.Now)
            ));
        }
    }
}
