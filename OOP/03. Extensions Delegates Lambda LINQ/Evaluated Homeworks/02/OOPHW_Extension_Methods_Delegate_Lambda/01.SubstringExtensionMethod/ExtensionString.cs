///01.Implement an extension method Substring(int index, int length) for the class StringBuilder
///that returns new StringBuilder and has the same functionality as Substring in the class String.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SubstringExtensionMethod
{
    public static class ExtensionString
    {
        //Extension method substring
        public static StringBuilder Substring(this StringBuilder list, int index, int length)
        {
            StringBuilder newList = new StringBuilder();
            if (index + length <= list.Length)
            {
                for (int i = index; i < length + index; i++)
                {
                    newList.Append(list[i]);
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

            return newList;
        }
        
    }
}
