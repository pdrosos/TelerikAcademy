using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.SetOfExtensions;

namespace _06.ArrayNumbersDivisible
{
    public static class DivisibleBy7And3
    {
        public static void DivideBy3And7<T>(this IEnumerable<T> array)
             where T : struct, IComparable<T>, IConvertible
        {
            //List<IEnumerable<T>> targetNums = new List<IEnumerable<T>>();

            foreach (T element in array)
            {
                 dynamic e = element;
                 if ((e % 7).Equals(0) && (e % 3).Equals(0))
                 {
                     //targetNums.Add(e);
                     Console.WriteLine(e);
                 }
            }            
        }

    }
}
