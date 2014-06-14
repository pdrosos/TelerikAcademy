namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class
    /// </summary>
    public class SchoolClass: ICommentable
    {
        private List<Student> students;
        private List<Teacher> teachers;
        private string textId;
        private string comment;

        public SchoolClass(List<Student> students, List<Teacher> teachers, string textId, string comment)
        {
            this.Students = students;
            this.Teachers = teachers;
            this.TextId = textId;
            this.Comment = comment;
        }

        public SchoolClass(List<Student> students, List<Teacher> teachers, string textId): this(students, teachers, textId, null)
        {
        }

        public SchoolClass(): this(null, null, null, null)
        {
        }
                       
        public List<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
            set
            {
                this.teachers = value;
            }
        }

        public string TextId
        {
            get
            {
                return this.textId;
            }
            set
            {
                this.textId = value;
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        public override string ToString()
        {
            string classString;

            StringBuilder sb = new StringBuilder();
            sb.Append("Class Text ID: ").Append(this.TextId).Append(", Comment(optional): ").AppendLine(this.Comment);
            sb.AppendLine("Students List:");

            foreach (var student in this.Students)
            {
                sb.AppendLine(student.ToString());
            }

            sb.AppendLine("Teachers List:");

            foreach (var teacher in this.Teachers)
            {
                sb.AppendLine(teacher.ToString());
            }
            
            classString = sb.ToString();
            return classString;
        }

    }
}
