namespace SumOfPolynomials
{
    using System;
    using System.Text;

    public class SumOfPolynomials
    {
        /// <summary>
        /// Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
		/// x2 + 5 = 1x2 + 0x + 5 -> { 5, 0, 1 }
        /// </summary>
        public static void Main(string[] args)
        {
            decimal[] polynomialOneCoefficients = { 2, 3, -4, 5, 1 };
            decimal[] polynomialTwoCoefficients = { -2, 4, 3, -3 };

            Console.WriteLine("{ " + string.Join(", ", polynomialOneCoefficients) + " }");
            Console.WriteLine("{ " + string.Join(", ", polynomialTwoCoefficients) + " }");

            decimal[] sum = PolynomialsSum(polynomialOneCoefficients, polynomialTwoCoefficients);
            Console.Write("Sum = " + PolynomialToString(sum));
            Console.WriteLine();
        }

        public static decimal[] PolynomialsSum(decimal[] polynomialOne, decimal[] polynomialTwo)
        {
            decimal[] sum = new decimal[Math.Max(polynomialOne.Length, polynomialTwo.Length)];

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = (i < polynomialOne.Length ? polynomialOne[i] : 0) + (i < polynomialTwo.Length ? polynomialTwo[i] : 0);
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
