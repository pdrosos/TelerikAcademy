namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string courseName) : this(courseName, null)
        {
        }

        public LocalCourse(string courseName, string teacherName) 
            : this(courseName, teacherName, new List<string>())
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students) 
            : this(courseName, teacherName, students, null) 
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Lab = lab;
        }

        internal string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                try
                {
                    this.lab = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Lab value type is incorrect or missing. Details: {0}", ex);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("LocalCourse {{ Name = {0}", this.Name);

            if (this.TeacherName != null)
            {
                result.AppendFormat("; Teacher = {0}", this.TeacherName);
            }

            result.AppendFormat("; Students = {0}", this.GetStudentsAsString());

            if (this.Lab != null)
            {
                result.AppendFormat("; Lab = {0}", this.Lab);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}