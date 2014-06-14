namespace _05TagProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;

    class TagProcessor
    {
        static void Main(string[] args)
        {
            int startIndex = 0;
            string withUpper = null;
            string text = "We are living in a fff <upcase>yellow submarine</upcase>. We don't have  h <upcase>anything</upcase> else.";
            string openingTag = "<upcase>";
            string closingTag = "</upcase>";

            while (true)
            {
                startIndex = text.IndexOf(openingTag);

                if (startIndex == -1)
                    {
                        break;
                    }

                int endIndex = text.IndexOf(closingTag);
                string toUpper = text.Substring(startIndex + openingTag.Length, endIndex - startIndex - openingTag.Length).ToUpper();
                       withUpper = text.Replace(text.Substring(startIndex, (endIndex + closingTag.Length) - startIndex), toUpper);
                       text = withUpper;
            } 
            Console.WriteLine(withUpper);
        }
    }
}
/* You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:
We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
The expected result:
We are living in a YELLOW SUBMARINE. We don't have ANYTHING else. */

     
    

