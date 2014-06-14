namespace ReplaceWordInFile
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class ReplaceWordInFile
    {
        /// <summary>
        /// Modify the solution of the previous problem to replace only whole words (not substrings).
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
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            line = line.ToLower();
                            writer.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
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
