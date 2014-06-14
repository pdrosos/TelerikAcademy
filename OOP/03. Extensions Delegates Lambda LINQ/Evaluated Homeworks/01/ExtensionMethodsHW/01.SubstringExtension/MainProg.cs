using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SubstringExtension
{
    class MainProg
    {
        static void Main()
        {
            StringBuilder text = new StringBuilder();
            text.Append("some line to add");
            Console.WriteLine(text.SubString(2,5).ToString());
        }
    }
}
