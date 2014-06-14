using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Test
{
    static void Main()
    {

        Person p1 = new Person("Todor");
        Console.WriteLine(p1.ToString());
        Person p2 = new Person("Misho", 20);
        Console.WriteLine(p2.ToString());
        Person p3 = new Person("Gosho", null);
        Console.WriteLine(p3.ToString());
    }
}

