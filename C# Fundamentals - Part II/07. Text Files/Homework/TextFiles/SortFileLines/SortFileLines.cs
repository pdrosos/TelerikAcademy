namespace SortFileLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SortFileLines
    {
        /// <summary>
        /// Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
        /// </summary>
        public static void Main(string[] args)
        {
            StreamReader reader;
            StreamWriter writer;

            OpenFile("../../file.txt", out reader);
            CreateFile("../../result.txt", out writer);

            List<string> strings = new List<string>();

            if (reader != null && writer != null)
            {
                using (reader)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        strings.Add(line);

                        line = reader.ReadLine();
                    }
                }

                strings.Sort();

                using (writer)
                {
                    foreach (string text in strings)
                    {
                        writer.WriteLine(text);
                    }
                }

                Console.WriteLine("Done. Please, check the text file.");
            }
            else
            {
                Console.WriteLine("Cannot open files.");
            }
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
