//Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement IEnumerable<int> and Equals(…),
//GetHashCode(), [], == and !=.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BitArray64Task
{
    class BitArray64Task
    {
        static void Main(string[] args)
        {
            BitArray64 number = new BitArray64(10);

            foreach (var bit in number)
            {
                Console.Write(bit);
            }
            Console.WriteLine();

            BitArray64 otherNumber = new BitArray64(20);

            Console.WriteLine(number.Equals(otherNumber));

            BitArray64 anotherNumber = new BitArray64(10);

            Console.WriteLine(number == anotherNumber);

            Console.WriteLine(number[3]);
        }
    }
}
