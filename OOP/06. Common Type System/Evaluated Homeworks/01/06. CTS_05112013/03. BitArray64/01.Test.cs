using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Test
{
    static void Main()
    {
        Console.WriteLine("BASIC TEST THAT INTENTS TO SHOW A 64 BIT NUMBER CAN BE STRED IN THE BitArray64 CLASS.");
        BitArray64 test = new BitArray64(10000000000);
        Console.WriteLine("PRINT THE BINARY REPRESENTATION OF THE NUMBER VIA INBUILD METHOD:");
        test.Print64();//methd that prints the bits of the letter
        Console.WriteLine();
        Console.WriteLine("PRINT THE SAME VIA FOREACH, TO PROOVE IEnumerable<int> HAS BEEN IMPEMENTED:");
        foreach (var item in test)//do the same via loopting direclty through the object
        {
            Console.Write(item);
        }
        Console.WriteLine();
        Console.WriteLine("TEST GET AND SET TESTS:");
        Console.WriteLine("Test1: print the binary number via get [] operator:");
        BitArray64 test2 = new BitArray64(5);
        for (int i = 0; i < 64; i++)
        {
            Console.Write(test2[i]);
        }
        Console.WriteLine();
        Console.WriteLine("Test2:Get the last bit of the number: " + test2[63]);
        Console.WriteLine("Test3: Change the last bit of the number");
        test2[63] = 0;
        Console.WriteLine("Pritnt the modified bit: " + test2[63]);
        Console.WriteLine("Print the modified number in bitwise:");
        test2.Print64();
        Console.WriteLine("Print the mdified number in decimal:" + test2.number);
        Console.WriteLine();

        Console.WriteLine("TEST == AND != OPERATORS:");
        BitArray64 test3 = new BitArray64(10120313213);
        BitArray64 test4 = new BitArray64(10120313213);
        BitArray64 test5 = new BitArray64(42);
        Console.WriteLine("BitArray64 numbers {0} and {1} are equal: {2}", test3.number, test4.number, test3 == test4);
        Console.WriteLine("BitArray64 numbers {0} and {1} are not equal: {2}", test3.number, test4.number, test3 != test4);
        Console.WriteLine("BitArray64 numbers {0} and {1} are equal: {2}", test3.number, test5.number, test3 == test5);
        Console.WriteLine(test3 == test5);
    }

}

