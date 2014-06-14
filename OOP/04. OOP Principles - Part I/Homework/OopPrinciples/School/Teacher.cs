namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    /// <summary>
    /// Teacher
    /// </summary>
    public class Teacher : Human, ICommentable
    {
        private List<Subject> subjectsSet;

        public Teacher(string name, List<Subject> subjectsSet, string comment): base(name, comment)
        {
            this.SubjectsSet = subjectsSet;
        }

        public Teacher(string name, List<Subject> subjectsSet): this(name, subjectsSet, null)
        {
            this.SubjectsSet = subjectsSet;
        }

        public Teacher(): this(null, null, null)
        {
        }
        
        public List<Subject> SubjectsSet
        {
            get
            {
                return this.subjectsSet;
            }
            set
            {
                this.subjectsSet = value;
            }
        }
       
        public override string ToString()
        {
            string teacherString;

            StringBuilder sb = new StringBuilder();
            
            sb.Append("Teacher's Name: ").AppendFormat("{0, -20}", this.Name).Append(", Subjects: ").
                Append(string.Join(", ", this.SubjectsSet.Select(x => x.Name).ToList()));

            sb.Append(", Comment: ").Append(this.Comment);           
            
            teacherString = sb.ToString();
            return teacherString;
        }

    }
}
