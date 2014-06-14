namespace BasicArithmeticOperationsPerformance
{
    using System;
    using System.Linq;

    public static class MathOperations
    {
        public static void Add(double iterations, int addend)
        {
            int sum = int.MinValue;
            for (double i = 0; i < iterations; i++)
            {
                sum += addend;
            }
        }

        public static void Add(double iterations, long addend)
        {
            long sum = long.MinValue;
            for (double i = 0; i < iterations; i++)
            {
                sum += addend;
            }
        }

        public static void Add(double iterations, float addend)
        {
            float sum = float.MinValue;
            for (double i = 0; i < iterations; i++)
            {
                sum += addend;
            }
        }

        public static void Add(double iterations, double addend)
        {
            double sum = double.MinValue;
            for (double i = 0; i < iterations; i++)
            {
                sum += addend;
            }
        }

        public static void Add(double iterations, decimal addend)
        {
            decimal sum = decimal.MinValue;
            for (double i = 0; i < iterations; i++)
            {
                sum += addend;
            }
        }

        // Subtraction methods
        public static void Subtract(double iterations, int subtrahend)
        {
            int diference = int.MaxValue;
            for (double i = 0; i < iterations; i++)
            {
                diference -= subtrahend;
            }
        }

        public static void Subtract(double iterations, long subtrahend)
        {
            long diference = long.MaxValue;
            for (double i = 0; i < iterations; i++)
            {
                diference -= subtrahend;
            }
        }

        public static void Subtract(double iterations, float subtrahend)
        {
            float diference = float.MaxValue;
            for (double i = 0; i < iterations; i++)
            {
                diference -= subtrahend;
            }
        }

        public static void Subtract(double iterations, double subtrahend)
        {
            double diference = double.MaxValue;
            for (double i = 0; i < iterations; i++)
            {
                diference -= subtrahend;
            }
        }

        public static void Subtract(double iterations, decimal subtrahend)
        {
            decimal diference = decimal.MaxValue;
            for (double i = 0; i < iterations; i++)
            {
                diference -= subtrahend;
            }
        }

        // Multiplication methods
        public static void Multiply(double iterations, int factor)
        {
            int product = 1;
            for (double i = 0; i < iterations; i++)
            {
                product *= factor;
            }
        }

        public static void Multiply(double iterations, long factor)
        {
            long product = 1;
            for (double i = 0; i < iterations; i++)
            {
                product *= factor;
            }
        }

        public static void Multiply(double iterations, float factor)
        {
            float product = 1;
            for (double i = 0; i < iterations; i++)
            {
                product *= factor;
            }
        }

        public static void Multiply(double iterations, double factor)
        {
            double product = 1;
            for (double i = 0; i < iterations; i++)
            {
                product *= factor;
            }
        }

        public static void Multiply(double iterations, decimal factor)
        {
            decimal product = 1;
            for (double i = 0; i < iterations; i++)
            {
                product *= factor;
            }
        }

        // Division methods
        public static void Divide(double iterations, int divisor)
        {
            int quotient = int.MaxValue;

            for (double i = 0; i < iterations; i++)
            {
                quotient /= divisor;
            }
        }

        public static void Divide(double iterations, long divisor)
        {
            long quotient = long.MaxValue;

            for (double i = 0; i < iterations; i++)
            {
                quotient /= divisor;
            }
        }

        public static void Divide(double iterations, float divisor)
        {
            float quotient = float.MaxValue;
            for (double i = 0; i < iterations; i++)
            {
                quotient /= divisor;
            }
        }

        public static void Divide(double iterations, double divisor)
        {
            double quotient = double.MaxValue;
            for (double i = 0; i < iterations; i++)
            {
                quotient /= divisor;
            }
        }

        public static void Divide(double iterations, decimal divisor)
        {
            decimal quotient = decimal.MaxValue;
            for (double i = 0; i < iterations; i++)
            {
                quotient /= divisor;
            }
        }
        
        // Square root methods for running operation a number of times (iterations)
        public static void GetSquareRoot(double iterations, float baseNumber)
        {
            for (double i = 0; i < iterations; i++)
            {
                Math.Sqrt(baseNumber);
            }
        }

        public static void GetSquareRoot(double iterations, double baseNumber)
        {
            for (double i = 0; i < iterations; i++)
            {
                Math.Sqrt(baseNumber);
            }
        }

        public static void GetSquareRoot(double iterations, decimal baseNumber)
        {
            for (double i = 0; i < iterations; i++)
            {
                Math.Sqrt((double)baseNumber);
            }
        }

        // Natural logarithm methods for different input types 
        // which are running operation a number of times (iterations)
        public static void CalcNaturalLogarithm(double iterations, float number)
        {
            for (double i = 0; i < iterations; i++)
            {
                Math.Log(number);
            }
        }

        public static void CalcNaturalLogarithm(double iterations, double number)
        {
            for (double i = 0; i < iterations; i++)
            {
                Math.Log(number);
            }
        }

        public static void CalcNaturalLogarithm(double iterations, decimal number)
        {
            for (double i = 0; i < iterations; i++)
            {
                Math.Log((double)number);
            }
        }

        // Finding sinus from angle (in radians)
        public static void GetSinus(double iterations, float number)
        {
            for (double i = 0; i < iterations; i++)
            {
                Math.Sin(number);
            }
        }

        public static void GetSinus(double iterations, double number)
        {
            for (double i = 0; i < iterations; i++)
            {
                Math.Sin(number);
            }
        }

        public static void GetSinus(double iterations, decimal number)
        {
            for (double i = 0; i < iterations; i++)
            {
                Math.Sin((double)number);
            }
        }
    }
}