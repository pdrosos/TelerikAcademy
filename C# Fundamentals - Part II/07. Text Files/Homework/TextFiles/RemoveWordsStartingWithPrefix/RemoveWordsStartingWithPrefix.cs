namespace RemoveWordsStartingWithPrefix
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class RemoveWordsStartingWithPrefix
    {
        /// <summary>
        /// Write a program that deletes from a text file all words that start with the prefix "test". 
        /// Words contain only the symbols 0...9, a...z, A…Z, _.
        /// </summary>
        public static void Main(string[] args)
        {
            string fileName = "../../file.txt";
            string tempFileName = "../../temp.txt";
            string backupFileName = "../../backup.txt";

            StreamReader reader;
            StreamWriter writer;

            OpenFile(fileName, out reader);
            CreateFile(tempFileName, out writer);

            if (reader != null && writer != null)
            {
                using (reader)
                {
                    using (writer)
                    {
                        string pattern = @"\btest\w*\b";
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
