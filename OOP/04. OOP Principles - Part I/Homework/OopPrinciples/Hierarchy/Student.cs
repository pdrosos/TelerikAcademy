namespace Hierarchy
{
    using System;

    /// <summary>
    /// Student
    /// </summary>
    public class Student: Human
    {
        private string grade;

        public Student(string firstName, string lastName, string grade): base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public Student()
        {
        }

        public string Grade
        {
            get 
            { 
                return grade; 
            }
            set 
            { 
                grade = value; 
            }
        }

        public override string ToString()
        {
            return String.Format("Student Name: {0, -10} {1, -10}, Grade: {2, -2}", this.FirstName, this.LastName, this.Grade);
        }
    }
}
