using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _07.UseTimer
{
    class MainProg
    {
        static void Main()
        {
            int ticks = 10;
            int interval = 2000;// milliseconds

            TimerDelegate timerElapsed = new TimerDelegate(ShowTicksLeft);

            Timer timer = new Timer(ticks, interval, timerElapsed);

            Console.WriteLine("Timer started for {0} ticks, a tick occurring once every {1} second(s).", ticks, interval / 1000);

            Thread timerThread = new Thread(new ThreadStart(timer.Run));
            timerThread.Start();
        }

        static void ShowTicksLeft(int ticksLeft)
        {
            Console.WriteLine("Timer interval has elapsed. Ticks left: {0}.", ticksLeft);   
        }
    }
}
