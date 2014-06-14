using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringExtensionMethod
{
    public class Student
    {
        //Properties for Names of the student
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        //Constructot
        public Student(string firstname, string lastname,int age)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Age = age;
        }

    }
}
