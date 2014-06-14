namespace ExtractTextFromXml
{
    using System;
    using System.IO;
    using System.Text;

    public class ExtractTextFromXml
    {
        /// <summary>
        /// Write a program that extracts from given XML file all the text without the tags.
        /// </summary>
        public static void Main(string[] args)
        {
            StreamReader reader;

            OpenFile("../../students.xml", out reader);
            
            if (reader != null)
            {
                using (reader)
                {
                    // read file char by char
                    int currentChar = reader.Read();
                    StringBuilder currentText = new StringBuilder();

                    while (currentChar != -1)
                    {
                        // we enter a new text between the tags
                        if (currentChar == '>')
                        {
                            currentText.Clear();
                            currentChar = reader.Read();
                            while (currentChar != '<' && currentChar != -1)
                            {
                                currentText.Append((char)currentChar);
                                currentChar = reader.Read();
                            }
                            // strip white spaces and empty lines
                            if (!String.IsNullOrWhiteSpace(currentText.ToString()))
                            {
                                Console.WriteLine(currentText.ToString().Trim());
                            }
                        }

                        currentChar = reader.Read();
                    }
                }     
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
    }
}
