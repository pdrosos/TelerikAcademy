namespace ReadFile
{
    using System;
    using System.IO;

    class ReadFile
    {
        /// <summary>
        /// Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), 
        /// reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). 
        /// Be sure to catch all possible exceptions and print user-friendly error messages.
        /// </summary>
        static void Main(string[] args)
        {
            string filePath = @"C:\WINDOWS\win.ini";
            string fileText = "";

            try
            {
                fileText = File.ReadAllText(filePath);
            }
            /*
             * All possible exceptions for File.ReadAllText are listed here: http://msdn.microsoft.com/en-us/library/ms143368.aspx 
             * Below are specified the most common exceptions for this method.
             */
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The file could not be found. Please check the path and try again.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Error: The specified path, file name, or both are too long. " +
                    "The file name must be less than 260 characters, and the directory name must be less than 248 characters.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error: Empty string entered. Please type the path to the file.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error: The specified path is invalid (for example, it is on an unmapped drive).");
            }

            Console.WriteLine(fileText);
        }
    }
}
