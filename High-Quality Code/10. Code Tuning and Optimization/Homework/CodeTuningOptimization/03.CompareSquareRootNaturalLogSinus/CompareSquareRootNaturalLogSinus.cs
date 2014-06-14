namespace SquareRootNaturalLogSinusPerformance
{
    using System;
    using System.Linq;
    using BasicArithmeticOperationsPerformance;

    public class CompareSquareRootNaturalLogSinus
    {
        public static void Main(string[] args)
        {
            double iterations = 1000000;

            Console.WriteLine("Iterations number: {0}", iterations);

            Console.WriteLine(
                "Square root (float), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.GetSquareRoot(iterations, 50f)));

            Console.WriteLine(
                "Square root (double), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.GetSquareRoot(iterations, 50d)));

            Console.WriteLine(
                "Square root (decimal), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.GetSquareRoot(iterations, 50m)));

            Console.WriteLine(
                "Natural logarithm (float), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.CalcNaturalLogarithm(iterations, 50f)));

            Console.WriteLine(
                "Natural logarithm (double), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.CalcNaturalLogarithm(iterations, 50d)));

            Console.WriteLine(
                "Natural logarithm (decimal), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.CalcNaturalLogarithm(iterations, 50m)));

            Console.WriteLine(
                "Sinus (float), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.GetSinus(iterations, 20f)));

            Console.WriteLine(
                "Sinus (double), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.GetSinus(iterations, 20d)));

            Console.WriteLine(
                "Sinus (decimal), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.GetSinus(iterations, 20m)));
        }
    }
}
