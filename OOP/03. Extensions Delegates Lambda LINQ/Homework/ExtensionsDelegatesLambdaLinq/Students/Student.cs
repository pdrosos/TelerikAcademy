namespace Students
{
    using System;
    using System.Text;
    
    public class Student
    {
        private string firstName;
        private string lastName;

        int age;

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age must be greater than zero");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append(this.FirstName).Append(" ").Append(this.LastName);
            info.Append(" (").Append(this.Age).Append(")");

            return info.ToString();
        }
    }
}
