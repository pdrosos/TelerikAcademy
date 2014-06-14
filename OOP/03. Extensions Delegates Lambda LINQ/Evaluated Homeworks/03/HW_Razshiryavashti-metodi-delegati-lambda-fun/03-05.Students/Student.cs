using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_05.Students
{
    class Student
    {
        //a simple class to hold information about students
        //properties with hidden fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        //constructor to easily create student instances
        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        //override ToString to easily check results (being as simple as it is, so I use "+" instead of StringBuilder)
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.Age;
        }
    }
}
