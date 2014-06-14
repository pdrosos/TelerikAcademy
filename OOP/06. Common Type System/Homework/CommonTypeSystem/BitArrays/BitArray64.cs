namespace BitArrays
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Bit array 64
    /// </summary>
    public class BitArray64 : IEnumerable<int>, IEquatable<BitArray64>
    {
        private readonly ulong number;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="number"></param>
        public BitArray64(ulong number = 0)
        {
            this.number = number;
        }

        /// <summary>
        /// Bit transform
        /// </summary>
        public int[] Bits
        {
            get
            {
                return this.GetBits();
            }
        }

        /// <summary>
        /// Indexator
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[int index]
        {
            get
            {
                if (!this.IndexCheck(index))
                {
                    throw new ArgumentOutOfRangeException();
                }

                int[] bits = this.GetBits();
                return bits[index];
            }
        }

        /// <summary>
        /// Implements operator ==
        /// </summary>
        /// <param name="firstArray"></param>
        /// <param name="secondArray"></param>
        /// <returns></returns>
        public static bool operator ==(BitArray64 firstArray, BitArray64 secondArray)
        {
            return BitArray64.Equals(firstArray, secondArray);
        }

        /// <summary>
        /// Implements operator !=
        /// </summary>
        /// <param name="firstArray"></param>
        /// <param name="secondArray"></param>
        /// <returns></returns>
        public static bool operator !=(BitArray64 firstArray, BitArray64 secondArray)
        {
            return !BitArray64.Equals(firstArray, secondArray);
        }

        /// <summary>
        /// Implements IEnumerable interface
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] bits = this.GetBits();

            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];
            }
        }

        /// <summary>
        /// Implements IEquatable interface
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Equals(BitArray64 value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }

            if (ReferenceEquals(this, value))
            {
                return true;
            }

            return this.number == value.number;
        }

        public override bool Equals(object obj)
        {
            BitArray64 temp = obj as BitArray64;
            if (temp == null)
            {
                return false;
            }
            else
            {
                return this.Equals(temp);
            }
        }

        /// <summary>
        /// Get hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = (result * 23) + this.number.GetHashCode();
                return result;
            }
        }

        /// <summary>
        /// Index checker
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool IndexCheck(int index)
        {
            if (index < 0 || index > 63)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Bit getter
        /// </summary>
        /// <returns></returns>
        private int[] GetBits()
        {
            ulong number = this.number;

            int[] bits = new int[64];
            int counter = 63;

            while (number > 0)
            {
                bits[counter] = (int)number % 2;
                number = number / 2;
                counter--;
            }

            do
            {
                bits[counter] = 0;
                counter--;
            }
            while (counter >= 0);

            return bits;
        }
    }
}