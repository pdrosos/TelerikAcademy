namespace RemoveWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class RemoveWords
    {
        /// <summary>
        /// Write a program that removes from a text file all words listed in given another text file. 
        /// Handle all possible exceptions in your methods.
        /// </summary>
        public static void Main(string[] args)
        {
            string fileName = "../../file.txt";
            string tempFileName = "../../temp.txt";
            string backupFileName = "../../backup.txt";

            List<string> words = new List<string>();

            StreamReader wordsReader;
            StreamReader reader;
            StreamWriter writer;

            OpenFile("../../words.txt", out wordsReader);
            OpenFile(fileName, out reader);
            CreateFile(tempFileName, out writer);

            if (wordsReader != null && reader != null && writer != null)
            {
                // Read words. We assume that each word is on separate line
                using (wordsReader)
                {
                    string line = wordsReader.ReadLine();
                    while (line != null)
                    {
                        words.Add(line.Trim().ToLower());
                        line = wordsReader.ReadLine();
                    }
                }

                using (reader)
                {
                    using (writer)
                    {
                        string pattern = @"\b" + String.Join("|", words) +  "\b";
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            writer.WriteLine(Regex.Replace(line.ToLower(), pattern, string.Empty));
                            line = reader.ReadLine();
                        }
                    }
                }

                //replace file's content with temp file's content and delete the created backup file
                File.Replace(tempFileName, fileName, backupFileName);
                File.Delete(backupFileName);

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
