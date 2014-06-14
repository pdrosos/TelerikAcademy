using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SubstringExtension
{
    public static class Substring //: System.Text.StringBuilder
    {
        public static StringBuilder SubString(this StringBuilder input, int index, int length)
        {
            StringBuilder subString = new StringBuilder();
            if (index + length > input.Length - 1 )
            {
                throw new IndexOutOfRangeException("Out of range!");
            }

            int endIndex = index + length;

            for (int i = index; i < endIndex; i++)
            {
                subString.Append(input[i]);
            }

            return subString;
        }
    }
}
