namespace ConcatenateFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ConcatenateFiles
    {
        /// <summary>
        /// Write a program that concatenates two text files into another text file.
        /// </summary>
        public static void Main(string[] args)
        {
            List<string> filePaths = new List<string>()
            {
                {@"..\..\file1.txt"},
                {@"..\..\file2.txt"}
            };
            
            string resultFilePath = @"..\..\result.txt";
            StringBuilder text = new StringBuilder();

            StreamReader reader;
            StreamWriter writer;

            foreach (string path in filePaths)
            {
                OpenFile(path, out reader);
                if (reader != null)
                {
                    using (reader)
                    {
                        text.Append(reader.ReadToEnd());
                    }
                }
            }

            CreateFile(resultFilePath, out writer);
            if (writer != null)
            {
                using (writer)
                {
                    writer.Write(text.ToString());
                }

                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Cannot open file.");
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
