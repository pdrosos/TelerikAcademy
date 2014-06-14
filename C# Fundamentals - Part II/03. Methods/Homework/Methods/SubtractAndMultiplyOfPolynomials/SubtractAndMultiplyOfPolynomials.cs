namespace SubtractAndMultiplyOfPolynomials
{
    using System;
    using System.Text;

    public class SubtractAndMultiplyOfPolynomials
    {
        /// <summary>
        /// Extend the program to support also subtraction and multiplication of polynomials.
        /// </summary>
        public static void Main(string[] args)
        {
            decimal[] polynomialOneCoefficients = { 2, 3, -4, 5, 1 };
            decimal[] polynomialTwoCoefficients = { -2, 4, 3, -3 };

            Console.WriteLine("{ " + string.Join(", ", polynomialOneCoefficients) + " }");
            Console.WriteLine("{ " + string.Join(", ", polynomialTwoCoefficients) + " }");

            decimal[] subtraction = PolynomialsSubtract(polynomialOneCoefficients, polynomialTwoCoefficients);
            decimal[] multiplication = PolynomialsMultiply(polynomialOneCoefficients, polynomialTwoCoefficients);

            Console.Write("Subtraction = " + PolynomialToString(subtraction));
            Console.WriteLine();
            Console.Write("Multiplication = " + PolynomialToString(multiplication));
            Console.WriteLine();
        }

        public static decimal[] PolynomialsMultiply(decimal[] polynomialOne, decimal[] polynomialTwo)
        {
            decimal[] multiplication = new decimal[polynomialOne.Length + polynomialTwo.Length];

            for (int i = 0; i < polynomialOne.Length; i++)
            {
                for (int j = 0; j < polynomialTwo.Length; j++)
                {
                    multiplication[i + j] += polynomialOne[i] * polynomialTwo[j];
                }
            }

            return multiplication;
        }

        public static decimal[] PolynomialsSubtract(decimal[] polynomialOne, decimal[] polynomialTwo)
        {
            decimal[] sum = new decimal[Math.Max(polynomialOne.Length, polynomialTwo.Length)];

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = (i < polynomialOne.Length ? polynomialOne[i] : 0) - (i < polynomialTwo.Length ? polynomialTwo[i] : 0);
            }

            return sum;
        }

        public static string PolynomialToString(decimal[] polynomial)
        {
            StringBuilder returnString = new StringBuilder();

            for (int i = polynomial.Length - 1; i >= 0; i--)
            {
                if (polynomial[i] != 0)
                {
                    returnString.Append(polynomial[i] > 0 ? " + " : " - ");
                    returnString.Append(Math.Abs(polynomial[i]));
                    if (i != 0)
                    {
                        returnString.Append(i > 1 ? "x^" + i : "x");
                    }
                }
            }

            if (returnString[1] != '-')
            {
                returnString.Remove(0, 3);
            }
            else
            {
                returnString.Remove(0, 1);
            }

            return returnString.ToString();
        }
    }
}
