namespace ToolsResearch
{
    using System;
    using System.IO;
    using System.Linq;
    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Core;
    using log4net.Layout;

    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger("all");

        private static void Main(string[] args)
        {
            // Logging using Log4Net library: http://logging.apache.org/log4net/

            /*If we need to specify some additional behavior (e.g. the log file max size) we can create our own FileAppender class 
            which implements the log4net IAppender interface.*/

            // In real situation the code below should be in the program configuration xml file.
            var fileAppender = new FileAppender();
            fileAppender.File = "log.txt";
            fileAppender.AppendToFile = true;
            fileAppender.Layout = new SimpleLayout();
            fileAppender.Threshold = Level.All;
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(fileAppender);

            var a = new DoSomething(Log);

            Log.Info("Info");
            Log.Error("Error");
            Log.Warn("warn");

            try
            {
                File.ReadAllLines(@"C:\NotExistingFile.txt");
            }
            catch (FileNotFoundException ex)
            {
                Log.Fatal(ex);
            }

            Console.WriteLine("Check the log file: {0}", fileAppender.File);
        }
    }
}
