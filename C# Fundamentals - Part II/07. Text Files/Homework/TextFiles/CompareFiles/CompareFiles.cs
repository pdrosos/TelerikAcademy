namespace CompareFiles
{
    using System;
    using System.IO;

    public class CompareFiles
    {
        /// <summary>
        /// Write a program that compares two text files line by line and prints the number of lines that are the same 
        /// and the number of lines that are different. Assume the files have equal number of lines.
        /// </summary>
        public static void Main(string[] args)
        {
            StreamReader fileOneReader;
            StreamReader fileTwoReader;

            OpenFile("../../file1.txt", out fileOneReader);
            OpenFile("../../file2.txt", out fileTwoReader);

            if (fileOneReader != null && fileTwoReader != null)
            {
                int equalLines = 0;
                int differentLines = 0;

                using (fileOneReader)
                {
                    using (fileTwoReader)
                    {
                        string fileOneLine = fileOneReader.ReadLine();
                        string fileTwoLine = fileTwoReader.ReadLine();

                        while (fileOneLine != null && fileTwoLine != null)
                        {
                            if (fileOneLine == fileTwoLine)
                            {
                                equalLines++;
                            }
                            else
                            {
                                differentLines++;
                            }

                            fileOneLine = fileOneReader.ReadLine();
                            fileTwoLine = fileTwoReader.ReadLine();
                        }
                    }
                }

                Console.WriteLine("Both files have {0} equal line(s) and {1} different line(s)", equalLines, differentLines);
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
    }
}
