using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _03.BitArray64Task
{
    public class BitArray64 : IEnumerable<int>
    {
        private int[] bits = new int[64];
        private ulong number;

        public BitArray64(ulong number)
        {
            this.number = number;
            for (int i = 0; i < 64; i++)
            {
                bits[i] = (int)(number % 2);
                number /= 2;
            }
        }

        public ulong Number
        {
            get { return this.number; }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return this.bits[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object param)
        {
            BitArray64 bits = param as BitArray64;

            if ((object)bits == null)
            {
                return false;
            }
            if (!Object.Equals(this.number, bits.number))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override int GetHashCode()
        {
            return this.number.GetHashCode() ^ this.bits.GetHashCode();
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !(BitArray64.Equals(first, second));
        }

        public int this[int index] 
        {
            get 
            {
                return this.bits[index];
            }
        }
    }
}
    
