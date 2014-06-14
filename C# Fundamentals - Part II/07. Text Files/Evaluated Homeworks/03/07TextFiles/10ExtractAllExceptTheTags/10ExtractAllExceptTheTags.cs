using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Write a program that extracts from given XML file all the text without the tags. Example:
<?xml version="1.0"><student><name>Pesho</name>
<age>21</age><interests count="3"><interest> Games</instrest><interest>C#</instrest><interest> 
Java</instrest></interests></student>
->
Pesho
21
Games
Java
*/
namespace _10ExtractAllExceptTheTags
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\input.xml");
            using (reader)
            {
                char symbol = (char)reader.Read();
                bool whetherPrint = false;
                while (reader.Peek() >= 0)
                {
                    if (symbol == '<')
                    {
                        whetherPrint = false;
                        Console.Write(" ");
                    }
                    if (symbol == '>')
                    {
                        whetherPrint = true;
                    }
                    symbol = (char)reader.Read();
                    if (whetherPrint && symbol != '<')
                    {
                        Console.Write(symbol);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
