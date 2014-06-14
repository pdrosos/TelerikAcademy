namespace DateWithFormatForCanada
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public class DateWithFormatForCanada
    {
        /// <summary>
        /// Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
        /// Display them in the standard date format for Canada.
        /// </summary>
        public static void Main(string[] args)
        {
            string text = "This is text with two dates - 18.09.1615 and 20.09.1615.";

            MatchCollection dates = Regex.Matches(text, @"\d{2}\.\d{2}\.\d{4}");
            foreach (Match date in dates)
            {
                Console.WriteLine(DateTime.ParseExact(date.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString(new CultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
        }
    }
}
