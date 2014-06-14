/*04.Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
 * and stores it the current directory. Find in Google how to download files in C#. 
 * Be sure to catch all exceptions and to free any used resources in the finally block.*/


using System;
using System.Net;
using System.Security;
using System.IO;

class DownloadFile
{
    static void Main(string[] args)
    {
        WebClient client = new WebClient();

        try
        {
            Console.Write("Enter the URL of the file: ");
            string url = Console.ReadLine();
            Uri fileUri = new Uri(url);
            string fileName = Path.GetFileName(fileUri.LocalPath);
            string localFilePath = Directory.GetCurrentDirectory() + '\\' + fileName;
            Console.WriteLine("The file was downloaded successfullt to: {0}", localFilePath);
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine("The url of the file is null!");
        }
        catch (UriFormatException ufe)
        {
            Console.WriteLine("Wrong url!");
        }
        catch (WebException we)
        {
            Console.WriteLine("An error occured while downloading the file!");
        }
        catch (SecurityException se)
        {
            Console.WriteLine("You cannot download the file due to security reasons!");
        }
        finally // releases all resources used
        {
            client.Dispose();
        }
    }
}

