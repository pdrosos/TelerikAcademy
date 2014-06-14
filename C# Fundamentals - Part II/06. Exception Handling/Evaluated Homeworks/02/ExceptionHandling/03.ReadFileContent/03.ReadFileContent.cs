/*03.Write a program that enters file name along with its full file path 
 * (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
 * Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions 
 * and print user-friendly error messages.*/


using System;
using System.IO;
using System.Security;


class ReadFileContent
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Entet the full file path: ");
            string path = Console.ReadLine();

            string content = File.ReadAllText(path);
            Console.WriteLine("Content: ");
            Console.WriteLine(content);
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine("The file path is empty!");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine("The file path contains invalid characters!");
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine("The directory of the file was not found!");
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine("The file was not found!");
        }
        catch (IOException ie)
        {
            Console.WriteLine("Some error occured while opening the file!");
        }
        catch (SecurityException pe)
        {
            Console.WriteLine("A security error is detected!");
        }
        catch (UnauthorizedAccessException ue)
        {
            Console.WriteLine("You don't have access to the file!");
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine("Invalid format of the path!");
        }

    }
}

