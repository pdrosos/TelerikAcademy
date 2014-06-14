
// Condition: 4. Write a program that doawnload a file from internet
//               and store it the current drectory. Be sure to catch all
//               exceptions and to free any used resources in the finally block.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;


class DownloadFile
{
    static void Main(string[] args)
    {
        using (WebClient client = new WebClient())
        {
            // enter url of file and path to downloaded place. Go throught exceptions if necessary.
            try
            {
                Console.Write("Enter url of the file you want to download\n(example: http://www.devbg.org/img/Logo-BASD.jpg): ");
                string url = Console.ReadLine();
                Console.WriteLine("Enter the place you want to download file(example: C:\\logo-basd.jpg):");
                string place = Console.ReadLine();
                string path = Environment.ExpandEnvironmentVariables(@place);
                client.DownloadFile(url, path);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You entered an empty address.");
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
            }
            catch (NotSupportedException nse)
            {
                Console.WriteLine(nse.Message);
            }
            finally
            {
                Console.WriteLine("I used link: http://msdn.microsoft.com/en-us/library/ez801hhe.aspx \nto find solution for this exercise.");
            }
        }

    }
}

