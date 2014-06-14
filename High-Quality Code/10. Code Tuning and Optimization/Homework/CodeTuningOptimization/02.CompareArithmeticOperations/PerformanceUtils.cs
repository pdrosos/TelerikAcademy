namespace BasicArithmeticOperationsPerformance
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public static class PerformanceUtils
    {
        public static string GetEllapsedTime(Action method)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            method();
            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds.ToString();
        }
    }
}
