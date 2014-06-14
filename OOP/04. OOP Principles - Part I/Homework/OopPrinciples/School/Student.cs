namespace School
{
    using System;

    /// <summary>
    /// Student
    /// </summary>
    public class Student: Human, ICommentable
    {
        private int? classNumber;        

        public Student(string name, int? classNumber, string comment): base(name, comment)
        {
            this.ClassNumber = classNumber;
        }

        public Student(string name, int? classNumber): this(name, classNumber, null)
        {            
        }
        
        public Student(): this(null, null, null)
        {
        }

        public int? ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            set
            {
                this.classNumber = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Class ID: {0, -2:00}, Student Name: {1}, Comment: {2}", this.ClassNumber, this.Name, this.Comment);
        }
    }
}
