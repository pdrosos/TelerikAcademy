//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
//Display them in the standard date format for Canada.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

class DateInCanada
{
    static void Main()
    {
        string input = "The war in Europe ended with an invasion of Germany by the Western Allies and the Soviet Union culminating in the capture of Berlin by Soviet and Polish troops and the subsequent German unconditional surrender on 08.05.1945. Following the Potsdam Declaration by the Allies on 26.06.1945, the United States dropped atomic bombs on the Japanese cities of Hiroshima and Nagasaki on 06.08.1945 and 09.08.1945 respectively.";
        string pattern = @"\d{1,2}.\d{1,2}.\d{4}";
        Match date = Regex.Match(input, pattern);
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
        while (date.Success)
        {
            DateTime dateCa = Convert.ToDateTime(date.ToString());
            string finalDate = dateCa.ToString("MM/dd/yy");
            Console.WriteLine(finalDate);
            date = date.NextMatch();
        }
    }
}

