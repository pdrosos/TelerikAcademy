using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PersonInfo
{
    public class Person
    {
        public string Name { get; set; }
        public byte? Age { get; set; }

        public Person(string name) 
        {
            this.Name = name;
        }

        public Person(string name, byte? age) 
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(this.Name);
            str.Append(" ");
            if (this.Age != null)
            {
                str.Append(this.Age);
            }
            else
            {
                str.Append("Age not specified");
            }
            return str.ToString();
        }
    }
}