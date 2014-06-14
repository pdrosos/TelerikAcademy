using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SetOfExtensions
{
    class MainProg
    {
        static void Main()
        {
            int [] arr = new int[]{3, 4, 1, 7, 10};
            Console.WriteLine( IEnumerableExtensions.Sum(arr) );
            Console.WriteLine( IEnumerableExtensions.Average(arr) );
            Console.WriteLine( IEnumerableExtensions.Max(arr) );
            Console.WriteLine( IEnumerableExtensions.Min(arr) );
            Console.WriteLine( IEnumerableExtensions.Product(arr) );
        }
    }
}
