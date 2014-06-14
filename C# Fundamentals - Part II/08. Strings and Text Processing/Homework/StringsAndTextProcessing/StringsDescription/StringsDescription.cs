namespace StringsDescription
{
    using System;

    public class StringsDescription
    {
        /// <summary>
        /// Describe the strings in C#. What is typical for the string data type? Describe the most important methods of the String class.
        /// </summary>
        public static void Main(string[] args)
        {
            string description = "The string data type is a string array of Unicode characters. \n" +
                                 "It is reference data type and its most important methods are: \n\n" +
                                 "Compare(str1, str2), IndexOf(str), LastIndexOf(str), \nSubstring(startIndex, length), \n" +
                                 "Replace(oldStr, newStr), Remove(startIndex, length), \nSplit(), ToLower(), ToUpper(), Trim(), \n" +
                                 "Split(params char[]), Insert(int index, string str), Append(str)";
            Console.WriteLine(description);
        }
    }
}
