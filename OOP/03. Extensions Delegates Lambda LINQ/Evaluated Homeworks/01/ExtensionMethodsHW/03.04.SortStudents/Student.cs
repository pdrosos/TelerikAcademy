using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._04.SortStudents
{
    interface IStudent
    {
        string Name { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
    }

    class Student : IStudent
    {
        private string name;
        private string lastName;
        private int age;

        public int Age 
        { 
            get{ return this.Age = age;}
            set { this.age = value;}
        }

        public string Name 
        { 
            get{ return this.Name = name;}
            set { this.name = value;}
        }

        public string LastName 
        { 
            get{ return this.LastName = lastName;}
            set { this.lastName = value;}
        }

        public Student()
        {
        }

        public Student(string name)
        {
            this.Name = name;
        }

        public Student(string name, string lastName)
            : this(name)
        {
            this.LastName = lastName;
        }

        public Student (string name, string lastName, int age) 
    : this( name, lastName)
    {
        this.LastName = lastName;
        this.Age = age;
    }
        //public Student(string name, string lastName, int age)
        //    : this(name, lastName, age)
        //{           
        //    this.Age = age;
        //}
    
        }
    }

