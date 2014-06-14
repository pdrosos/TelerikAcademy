/*Define a class BitArray64 to hold 64 bit values inside an ulong value. 
 * Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BitArray64 : IEnumerable<int>
{
    public ulong number { get; set; }

    public BitArray64(ulong ulongnb)
    {
        this.number = ulongnb;
    }

    private int[] Ulong2binary(ulong nb64)
    {
        int[] bits = new int[64];
        int i = 63;
        ulong number = nb64;
        ulong reminder;
        while (number > 0 && i >= 0)
        {
            reminder = number % 2;
            number = number / 2;
            bits[i] = (int)reminder;
            i--;
        }
        return bits;
    }

    public void Print64()
    {
        ulong nb64 = this.number;
        int[] printable = Ulong2binary(nb64);
        foreach (var item in printable)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }


    public IEnumerator<int> GetEnumerator()
    {
        int[] numberBits = Ulong2binary(this.number);
        foreach (int bit in numberBits)
        {
            yield return bit;
        }
        Console.WriteLine();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object obj)
    {
        // If parameter is null return false.
        if (obj == null)
        {
            return false;
        }
        // If parameter cannot be cast to Point return false.
        BitArray64 num64 = obj as BitArray64;
        if ((Object)num64 == null)
        {
            return false;
        }
        // Return true if the fields match:
        return (number == num64.number);
    }

    public override int GetHashCode()
    {
        Random rnd = new Random();
        int rndInt = Convert.ToInt32(rnd);
        return rndInt;
    }


    public int this[int key]
    {

        get
        {
            ulong nb64 = this.number;
            int[] temp = Ulong2binary(nb64);
            return temp[key];
        }
        set
        {
            ulong nb64 = this.number;
            int[] temp = Ulong2binary(nb64);
            if (value == 0 || value == 1)
            {
                temp[key] = value;
                ulong newNumber = 0;
                int k = 63;
                for (int i = 0; i < 64; i++)
                {
                    newNumber = newNumber + (ulong)temp[i] * (ulong)Math.Pow(2, k);
                    k--;
                }
                number = newNumber;
            }
            else
            {
                throw new System.ArgumentException("Value cannot be 1 or 0!");
            }
        }
    }

    public static bool operator ==(BitArray64 nb1, BitArray64 nb2)
    {
        return BitArray64.Equals(nb1, nb2);
    }
    public static bool operator !=(BitArray64 nb1, BitArray64 nb2)
    {
        return !BitArray64.Equals(nb1, nb2);
    }
}

