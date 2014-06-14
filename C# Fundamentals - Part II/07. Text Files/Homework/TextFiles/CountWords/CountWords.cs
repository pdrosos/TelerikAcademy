namespace CountWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Text;

    public class CountWords
    {
        /// <summary>
        /// Write a program that reads a list of words from a file words.txt and finds how many times each of the words 
        /// is contained in another file text.txt. The result should be written in the file result.txt and the words should be 
        /// sorted by the number of their occurrences in descending order. 
        /// Handle all possible exceptions in your methods.
        /// </summary>
        public static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            StreamReader wordsReader;
            StreamReader textReader;
            StreamWriter writer;

            OpenFile("../../words.txt", out wordsReader);
            OpenFile("../../text.txt", out textReader);
            CreateFile("../../result.txt", out writer);

            if (wordsReader != null && textReader != null && writer != null)
            {
                // Read words. We assume that each word is on separate line
                using (wordsReader)
                {
                    string line = wordsReader.ReadLine();
                    while (line != null)
                    {
                        words.Add(line.Trim().ToLower(), 0);
                        line = wordsReader.ReadLine();
                    }
                }

                List<string> wordsList = new List<string>(words.Keys);

                // Count words
                using (textReader)
                {
                    string line = textReader.ReadLine();
                    while (line != null)
                    {
                        // Count words in current line
                        foreach (string word in wordsList)
                        {
                            words[word] += Regex.Matches(line.ToLower(), @"\b" + word + @"\b").Count;
                        }
                        line = textReader.ReadLine();
                    }
                }

                words = SortDictionaryDesc(words);

                // Save the result
                using (writer)
                {
                    StringBuilder line = new StringBuilder();
                    foreach (KeyValuePair<string, int> word in words)
                    {
                        line.Append(word.Key).Append(": ").Append(word.Value);
                        writer.WriteLine(line.ToString());
                        line.Clear();
                    }
                }

                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Cannot open files.");
            }
        }

        static Dictionary<string, int> SortDictionaryDesc(Dictionary<string, int> dictionary)
        {
            Dictionary<string, int> sortedDictionary = (from entry in dictionary orderby entry.Value descending select entry)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            return sortedDictionary;
        }

        public static bool OpenFile(string fileName, out StreamReader streamReader)
        {
            try
            {
                streamReader = new StreamReader(fileName);
                return true;
            }
            catch (FileNotFoundException)
            {
                streamReader = null;
                return false;
            }
            catch (DirectoryNotFoundException)
            {
                streamReader = null;
                return false;
            }
            catch (IOException)
            {
                streamReader = null;
                return false;
            }
        }

        public static bool CreateFile(string fileName, out StreamWriter streamWriter)
        {
            try
            {
                streamWriter = new StreamWriter(fileName);
                return true;
            }
            catch (DirectoryNotFoundException)
            {
                streamWriter = null;
                return false;
            }
            catch (IOException)
            {
                streamWriter = null;
                return false;
            }
        }
    }
}
