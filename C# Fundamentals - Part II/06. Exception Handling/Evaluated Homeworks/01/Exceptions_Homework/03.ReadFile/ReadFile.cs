
// Condition: 3. Write a program that enters file name along with its full file path (e.g C:\Windows\win.ini),
//               reads its contents and prints it on the console. Be sure to catch all possible exceptions and print 
//               user-friendly error messages.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class ReadFile
{
    static void Main(string[] args)
    {
        // enter path to file
        Console.WriteLine("Enter the path of text file you want to read (Example : C:\\Windows\\win.ini): ");
        string path = Console.ReadLine();

        // read file and go throught all possible exceptions, and print suitable message.
        try
        {
            string value = File.ReadAllText(path);
            Console.WriteLine(value);
        }
        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("You entered nothing.");
        }
        catch (ArgumentException)
        {
            Console.Error.WriteLine("You entered a zero length string, only white space or invalid charecter.");
        }
        catch (PathTooLongException)
        {
            Console.Error.WriteLine("Your path, file name or both exceed the system definition of maximum length.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("The path you choose is invalid(unmapped drive).");
        }
        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine(" The file is read only or path specified a directory.");
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("The path for this file is not found.");
        }
        catch (NotSupportedException)
        {
            Console.Error.WriteLine("The path is an invalid format.");
        }
    }
}

