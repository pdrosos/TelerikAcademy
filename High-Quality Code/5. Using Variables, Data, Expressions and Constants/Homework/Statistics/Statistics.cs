namespace Statistics
{
    using System;

    public class Statistics
    {
        public static void Main(string[] args)
        {
            double[] numbers = new double[] { 1, 2.2, 4, 5, -3, 12 };
            PrintStatistics(numbers, numbers.Length);
        }

        public static void PrintStatistics(double[] numbers, int numbersCount)
        {
            double maxNumber = double.MinValue;

            for (int i = 0; i < numbersCount; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            PrintMaxNumber(maxNumber);

            double minNumber = double.MaxValue;

            for (int i = 0; i < numbersCount; i++)
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }

            PrintMinNumber(minNumber);

            double sum = 0;

            for (int i = 0; i < numbersCount; i++)
            {
                sum += numbers[i];
            }

            double averageNumber = sum / numbersCount;

            PrintAverageNumber(averageNumber);
        }

        public static void PrintMaxNumber(double number)
        {
            Console.WriteLine("Maximum number: {0}", number);
        }

        public static void PrintMinNumber(double number)
        {
            Console.WriteLine("Minimum number: {0}", number);
        }

        public static void PrintAverageNumber(double number)
        {
            Console.WriteLine("Average number: {0}", number);
        }
    }
}
