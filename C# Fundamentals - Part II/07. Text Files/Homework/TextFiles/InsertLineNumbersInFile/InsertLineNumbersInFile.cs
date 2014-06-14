namespace InsertLineNumbersInFile
{
    using System;
    using System.IO;
    using System.Text;

    public class InsertLineNumbersInFile
    {
        /// <summary>
        /// Write a program that reads a text file and inserts line numbers in front of each of its lines. 
        /// The result should be written to another text file.
        /// </summary>
        public static void Main(string[] args)
        {
            StreamReader reader;
            StreamWriter writer;

            OpenFile("../../file.txt", out reader);
            CreateFile("../../result.txt", out writer);

            if (reader != null && writer != null)
            {
                using (reader)
                {
                    using (writer)
                    {
                        int lineNumber = 0;
                        StringBuilder line = new StringBuilder();
                        line.Append(reader.ReadLine());
                        while (line.ToString() != string.Empty)
                        {
                            lineNumber++;
                            writer.WriteLine(lineNumber + ". " + line.ToString());

                            line.Clear();
                            line.Append(reader.ReadLine());
                        }
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
