using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class TEST
{
    static void Main()
    {
        Console.WriteLine("Create students. Test string:");
        Student student01 = new Student("Boiko", "Cvetanov", 1001, University.SofiaUni);
        Student student02 = new Student("BoikoFake", "CvetanovFake", 1001, University.PlovdivUni);
        Console.WriteLine(student01.Equals(student02));
        Console.WriteLine(student01.ToString());
        Console.WriteLine(student01 == student02);
        Console.WriteLine();

        Console.WriteLine("Clone students:");
        Student cloned01 = student01.Clone();
        student01.firstName = "testen";
        Console.WriteLine(student01.firstName);
        Console.WriteLine(cloned01.firstName);
        Console.WriteLine();

        Console.WriteLine("Compare 2 students:");//1st student is after 2nd student
        Student student31 = new Student("A", "C", 3001, University.SofiaUni);
        Student student32 = new Student("A", "B", 3001, University.SofiaUni);
        Console.WriteLine(student31.CompareTo(student32));//1st student is before 2nd student
        Student student33 = new Student("A", "B", 3001, University.SofiaUni);
        Student student34 = new Student("A", "B", 3002, University.SofiaUni);
        Console.WriteLine(student33.CompareTo(student34));



    }
}

