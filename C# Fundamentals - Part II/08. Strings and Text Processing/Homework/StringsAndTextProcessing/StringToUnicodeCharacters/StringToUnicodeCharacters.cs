namespace StringToUnicodeCharacters
{
    using System;
    using System.Text;

    public class StringToUnicodeCharacters
    {
        /// <summary>
        /// Write a program that converts a string to a sequence of C# Unicode character literals. 
        /// Use format strings.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine(ConvertToUnicode("Hi!"));
        }

        public static string ConvertToUnicode(string text)
        {
            StringBuilder unicodeText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
			{ 
                unicodeText.AppendFormat("\\u{0:X4}", Convert.ToUInt16(text[i]));
            }

            return unicodeText.ToString();
        }
    }
}
