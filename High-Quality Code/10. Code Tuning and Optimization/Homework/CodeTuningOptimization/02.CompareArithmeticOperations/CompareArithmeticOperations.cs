namespace BasicArithmeticOperationsPerformance
{
    using System;
    using System.Linq;

    public class CompareArithmeticOperations
    {
        public static void Main(string[] args)
        {
            double iterations = 1000000;

            Console.WriteLine("Iterations number: {0}", iterations);

            // Addition
            Console.WriteLine(
                "Addition (int), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Add(iterations, 2)));
            
            Console.WriteLine(
                "Addition (long), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Add(iterations, 2L)));

            Console.WriteLine(
                "Addition (float), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Add(iterations, 0.5f)));

            Console.WriteLine(
                "Addition (double), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Add(iterations, 0.5d)));

            Console.WriteLine(
                "Addition (decimal), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Add(iterations, 0.5m)));

            // Subtraction
            Console.WriteLine(
                "Subtraction (int), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Subtract(iterations, 2)));

            Console.WriteLine(
                "Subtraction (long), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Subtract(iterations, 2L)));

            Console.WriteLine(
                "Subtraction (float), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Subtract(iterations, 0.5f)));

            Console.WriteLine(
                "Subtraction (double), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Subtract(iterations, 0.5d)));

            Console.WriteLine(
                "Subtraction (decimal), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Subtract(iterations, 0.5m)));

            // Increment
            Console.WriteLine(
                "Increment (int), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Add(iterations, 1)));

            Console.WriteLine(
                "Increment (long), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Add(iterations, 1L)));

            Console.WriteLine(
                "Increment (float), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Add(iterations, 1f)));

            Console.WriteLine(
                "Increment (double), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Add(iterations, 1d)));

            Console.WriteLine(
                "Increment (decimal), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Add(iterations, 1m)));

            // Multiplication
            Console.WriteLine(
                "Multiplication (int), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Multiply(iterations, 2)));

            Console.WriteLine(
                "Multiplication (long), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Multiply(iterations, 2L)));

            Console.WriteLine(
                "Multiplication (float), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Multiply(iterations, 0.5f)));

            Console.WriteLine(
                "Multiplication (double), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Multiply(iterations, 0.5d)));

            Console.WriteLine(
                "Multiplication (decimal), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Multiply(iterations, 0.5m)));

            // Division
            Console.WriteLine(
                "Division (int), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Divide(iterations, 2)));

            Console.WriteLine(
                "Division (long), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Divide(iterations, 2L)));

            Console.WriteLine(
                "Division (float), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Divide(iterations, 1.2f)));

            Console.WriteLine(
                "Division (double), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Divide(iterations, 1.2d)));

            Console.WriteLine(
                "Division (decimal), Elapsed time: {0} ms",
                PerformanceUtils.GetEllapsedTime(() => MathOperations.Divide(iterations, 1.2m)));
        }
    }
}
