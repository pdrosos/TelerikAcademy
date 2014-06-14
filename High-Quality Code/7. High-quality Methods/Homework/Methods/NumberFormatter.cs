namespace Methods
{
    using System;
    using System.Linq;

    public class NumberFormatter
    {
        public static string DigitToWord(int number)
        {
            string word;

            switch (number)
            {
                case 0:
                    word = "zero";
                    break;
                case 1:
                    word = "one";
                    break;
                case 2:
                    word = "two";
                    break;
                case 3:
                    word = "three";
                    break;
                case 4:
                    word = "four";
                    break;
                case 5:
                    word = "five";
                    break;
                case 6:
                    word = "six";
                    break;
                case 7:
                    word = "seven";
                    break;
                case 8:
                    word = "eight";
                    break;
                case 9:
                    word = "nine";
                    break;
                default:
                    throw new ArgumentException("Invalid digit!");
            }

            return word;
        }

        public static string FormatNumber(int number, string format)
        {
            return FormatNumber(Convert.ToDouble(number), format);
        }

        public static string FormatNumber(double number, string format)
        {
            string formattedNumber;

            switch (format)
            {
                case "fixedPoint":
                    formattedNumber = number.ToString("f2");
                    break;
                case "percentage":
                    formattedNumber = number.ToString("p0");
                    break;
                case "roundTrip":
                    formattedNumber = number.ToString("r");
                    break;
                default:
                    throw new ArgumentException("Incorrect format");
            }

            return formattedNumber;
        }
    }
}