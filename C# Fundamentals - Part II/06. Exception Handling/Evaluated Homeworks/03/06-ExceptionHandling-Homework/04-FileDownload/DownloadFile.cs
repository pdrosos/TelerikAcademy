using System;
using System.Net;

class DownloadFile
{
    static void Main(string[] args)
    {
        string remoteUri = "http://www.devbg.org/img/";
        string fileName = "Logo-BASD.jpg";
        string myStringWebResource = null;

        // Create a new WebClient instance.
        using (WebClient myWebClient = new WebClient())
        {
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri + fileName;
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n", fileName, myStringWebResource);
            try
            {
                // Download the Web resource and save it into the current filesystem folder.
                myWebClient.DownloadFile(myStringWebResource, fileName);
                Console.WriteLine("Successfully Downloaded File");
            }
            catch (WebException e)
            {
                Console.WriteLine("Address is invalid, filename not exists, or it is null or Empty.");
                throw new WebException(e.Message);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The path is null");
                throw new ArgumentNullException();
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("The path is in an invalid format");
                throw new NotSupportedException(e.Message);
            }
        }
    }
}

