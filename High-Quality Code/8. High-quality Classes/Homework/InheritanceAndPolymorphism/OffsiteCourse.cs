namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string courseName)
            : this(courseName, null)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students) 
            : this(courseName, teacherName, students, null) 
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Town = town;
        }

        internal string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                try
                {
                    this.town = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Town value type is incorrect or missing. Details: {0}", ex);
                }  
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("OffsiteCourse {{ Name = {0}", this.Name);

            if (this.TeacherName != null)
            {
                result.AppendFormat("; Teacher = {0}", this.TeacherName);
            }

            result.AppendFormat("; Students = {0}", this.GetStudentsAsString());

            if (this.Town != null)
            {
                result.AppendFormat("; Town = {0}", this.Town);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}