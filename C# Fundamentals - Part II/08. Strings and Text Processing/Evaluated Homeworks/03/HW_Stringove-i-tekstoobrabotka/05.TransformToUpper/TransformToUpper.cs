/*You are given a text. Write a program that changes the text in all regions surrounded by the tags 
 * <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:
 * We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
 * The expected result:
We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
*/


using System;

class TransformToUpper
{
    static void Main(string[] args)
    {
        Console.WriteLine("Type a string:");
        string myStr = Console.ReadLine();

        int opentag = 0;
        int closetag = 0;
        string str = myStr;

        while (opentag != -1)
        {
            opentag = myStr.IndexOf("<upcase>", closetag);
            if (opentag != -1)
            {
                closetag = myStr.IndexOf("</upcase>", opentag);
                string mySubStr = myStr.Substring(opentag + 8, closetag - opentag - 8);
                string upper = mySubStr.ToUpper();

                str = str.Replace("<upcase>" + mySubStr + "</upcase>", upper);
            }
        }
        Console.WriteLine(str);
    }
}