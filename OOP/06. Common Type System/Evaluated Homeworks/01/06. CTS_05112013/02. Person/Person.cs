/*Problem #4: Create a class Person with two fields – name and age.
 * Age can be left unspecified (may contain null value) 
 * Override ToString() to display the information of a person and if age is not specified – to say so. 
 * Write a program to test this functionality.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Person
{
    public string name { get; set; }
    public int? age { get; set; }

    public Person(string name, int? age = null)
    {
        this.name = name;
        this.age = age;
    }

    public override string ToString()
    {
        if (this.age == null)
        {
            return this.name + ", age is N/A";
        }
        else if (age < 0 || age > 150)
        {
            throw new ArgumentOutOfRangeException("WTF?!?");
        }
        else
        {
            return this.name + ", " + this.age.ToString();
        }
    }
}

