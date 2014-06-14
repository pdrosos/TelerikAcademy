namespace Dictionary
{
    using System;
    using System.Collections.Generic;

    public class Dictionary
    {
        /// <summary>
        /// A dictionary is stored as a sequence of text lines containing words and their explanations.
        /// Write a program that enters a word and translates it by using the dictionary.
        /// </summary>
        public static void Main(string[] args)
        {
            // we could use a real Dictionary type here
            List<string> dictionary = new List<string>()
            {
                ".NET - platform for applications from Microsoft",
                "CLR - managed execution environment for .NET",
                "namespace - hierarchical organization of classes",
            };

            string word = "clr";

            int index = dictionary.FindIndex(dct => dct.StartsWith(word + " - ", StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                Console.WriteLine(dictionary[index]);
            }
            else Console.WriteLine("No match in the dictionary!");
        }
    }
}
