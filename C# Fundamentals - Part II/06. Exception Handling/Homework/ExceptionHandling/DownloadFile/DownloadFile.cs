namespace DownloadFile
{
    using System;
    using System.Net;

    public class DownloadFile
    {
        /// <summary>
        /// Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
        /// and stores it the current directory. Find in Google how to download files in C#.
        /// Be sure to catch all exceptions and to free any used resources in the finally block.
        /// </summary>
        public static void Main(string[] args)
        {
            Download("http://www.devbg.org/img/Logo-BASD.jpg", "../../logo.jpg");
            Console.WriteLine("File download completed.");
        }

        public static void Download(string url, string fileName)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    webClient.DownloadFile(url, fileName);
                }
                catch (WebException)
                {
                    Console.Error.WriteLine("Wrong url or network error.");
                }
                catch (NotSupportedException)
                {
                    Console.Error.WriteLine("The method has been called from multiple threads.");
                }
                catch (Exception exception)
                {
                    Console.Error.WriteLine(exception.Message);
                }
            }
        }
    }
}
