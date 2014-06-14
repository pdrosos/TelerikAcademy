using System;
using System.IO;
using System.Text;

class ConcatenateFiles
{
    static void Main()
    {
        try
        {
            using (StreamReader readerOne = new StreamReader("textfile1.txt"), readerTwo = new StreamReader("textfile2.txt"))
            {
                using (StreamWriter writer = new StreamWriter("result.txt"))
                {
                    string line;
                    while ((line = readerOne.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }

                    while ((line = readerTwo.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("I/O error!");
        }
    }
}