namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        internal string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                try
                {
                    this.name = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Course name value type is incorrect or missing: {0}", ex);
                }
            }
        }

        internal string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                try
                {
                    this.teacherName = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Teacher name value type is incorrect or missing. Details: {0}", ex);
                }
            }
        }

        internal IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                try
                {
                    this.students = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Students list type is incorrect or missing. Details: {0}", ex);
                }
            }
        }

        public abstract override string ToString();

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}