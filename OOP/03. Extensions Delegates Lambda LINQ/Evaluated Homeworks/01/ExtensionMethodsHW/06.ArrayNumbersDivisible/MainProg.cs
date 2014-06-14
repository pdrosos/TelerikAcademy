using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.SetOfExtensions;

namespace _06.ArrayNumbersDivisible
{
    class MainProg
    {
        static void Main()
        {
            int[] arr = new int[] { 3, 7, 9, 12, 21, 43};

            DivisibleBy7And3.DivideBy3And7(arr);           
        }
    }
}
