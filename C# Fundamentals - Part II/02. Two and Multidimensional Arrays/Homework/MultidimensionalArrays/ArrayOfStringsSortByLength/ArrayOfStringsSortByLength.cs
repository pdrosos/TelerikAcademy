namespace ArrayOfStringsSortByLength
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArrayOfStringsSortByLength
    {
        /// <summary>
        /// You are given an array of strings. 
        /// Write a method that sorts the array by the length of its elements (the number of characters composing them).
        /// </summary>
        public static void Main(string[] args)
        {
            List<string> strings = new List<string> { "asd", "fgh", "1234", "56789", "fff", "23", "0101", "foobar" };
            Console.WriteLine("{" + String.Join(", ", strings) + "}");

            IEnumerable<string> sortedStrings = SortByLength(strings);
            Console.WriteLine("{" + String.Join(", ", sortedStrings) + "}");
        }

        public static IEnumerable<string> SortByLength(IEnumerable<string> list)
        {
            var sortedList = from str in list
                             orderby str.Length ascending
                             select str;

            return sortedList;
        }
    }
}
