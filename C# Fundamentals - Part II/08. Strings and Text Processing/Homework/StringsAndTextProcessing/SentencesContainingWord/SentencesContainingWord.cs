namespace SentencesContainingWord
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SentencesContainingWord
    {
        /// <summary>
        /// Write a program that extracts from a given text all sentences containing given word.
        /// </summary>
        public static void Main(string[] args)
        {
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            Console.WriteLine(ExtractSentenceWithWord(text, "in"));
            Console.WriteLine();
            Console.WriteLine(ExtractSentenceWithWord(text, "submarine"));
        }

        public static string ExtractSentenceWithWord(string text, string word)
        {
            text = text.Insert(0, ". ");

            int start = 0;
            List<int> sentences = new List<int>();
            int index = 0;
            int position = 0;

            while (text.IndexOf(". ", start) > -1)
            {
                position = text.IndexOf(". ", start);
                sentences.Add(position + 2);
                start = sentences[index];
                index++;
            }

            sentences.Add(text.Length);

            StringBuilder resultSentences = new StringBuilder();
            for (int i = 0; i < sentences.Count - 1; i++)
            {
                string sentence = text.Substring(sentences[i], sentences[i + 1] - sentences[i]);
                if (sentence.Contains(" " + word + " ") || sentence.Contains(" " + word + ".") || sentence.Contains(" " + word + ","))
                {
                    resultSentences.Append(sentence);
                }
            }

            return resultSentences.ToString();
        }
    }
}
