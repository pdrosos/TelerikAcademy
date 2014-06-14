using System;
using System.IO;
using System.Security;
using System.Text;

class ReadFile
{
    public static void Main()
    {
        string path = @"c:\Windows\win.ini";
        try
        {
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine("Directory not found");
            throw new DirectoryNotFoundException(e.Message);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found");
            throw new FileNotFoundException(e.Message);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The path is null");
            throw new ArgumentNullException();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("The path is a zero-length string, contains only white space, or contains one or more invalid characters");
            throw new ArgumentException(e.Message);
        }
        catch (PathTooLongException e)
        {
            Console.WriteLine("The specified path, file name, or both exceed the system-defined maximum length");
            throw new PathTooLongException(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine("An I/O error occurred while opening the file");
            throw new IOException(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("You do not have the required permission or path specified a directory");
            throw new UnauthorizedAccessException(e.Message);
        }
        catch (SecurityException e)
        {
            Console.WriteLine("You do not have the required permission");
            throw new SecurityException(e.Message);
        }
        catch (NotSupportedException e)
        {
            Console.WriteLine("The path is in an invalid format");
            throw new NotSupportedException(e.Message);
        }
    }
}