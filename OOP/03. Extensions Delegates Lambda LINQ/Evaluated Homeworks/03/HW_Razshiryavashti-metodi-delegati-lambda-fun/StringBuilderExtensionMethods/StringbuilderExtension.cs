using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class StringbuilderExtension
{
    //01.Implement an extension method Substring(int index, int length) for the class 
    //StringBuilder that returns new StringBuilder and has the same functionality
    //as Substring in the class String.

    public static StringBuilder Substring(this StringBuilder stringbuilder, int startIndex, int length)
    {
        if (startIndex < 0 || startIndex >= stringbuilder.Length)
        {
            throw new ArgumentException("The start index must be greater than 0 and less than the length of the input stringbuilder!");
        }
        else if (startIndex + length > stringbuilder.Length)
        {
            throw new ArgumentException("StartIndex and length must refer to a location within the stringbuilder!");
        }
        else if (length < 0)
        {
            throw new ArgumentException("The length should be positive!");
        }
        else
        {
            StringBuilder res = new StringBuilder(length);
            for (int i = startIndex; i < startIndex + length; i++)
            {
                res.Append(stringbuilder[i]);
            }
            return res;
        }
    }
}

