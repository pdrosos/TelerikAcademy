namespace T4Template
{
    using System;
    using System.Linq;
    using System.IO;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("This program will automatically generate html page with a table inside it");
            Console.Write("Specify number of rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Specify number of columns: ");
            int cols = int.Parse(Console.ReadLine());

            HtmlTable table = new HtmlTable(rows, cols);
            String tableContent = table.TransformText();
            File.WriteAllText("HTMLTable.html", tableContent);

            Console.WriteLine("The HTMLTable.html file has been saved to the Project Bin/Debug folder");
        }
    }
}
