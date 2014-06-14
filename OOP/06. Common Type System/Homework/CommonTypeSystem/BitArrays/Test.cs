namespace BitArrays
{
    using System;

    class Test
    {
        static void Main(string[] args)
        {
            BitArray64 array = new BitArray64(255);
            foreach (int item in array)
            {
                Console.Write("{0} - ", item);
            }
        }
    }
}
