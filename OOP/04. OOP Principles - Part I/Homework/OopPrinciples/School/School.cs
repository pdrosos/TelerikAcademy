namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// School
    /// </summary>
    public class School
    {
        private List<SchoolClass> classes;

        public School(List<SchoolClass> classes)
        {
            this.Classes = classes;
        }

        public School(): this(null)
        {
        }

        public List<SchoolClass> Classes
        {
            get
            {
                return this.classes;
            }
            set
            {
                this.classes = value;
            }
        }

        public override string ToString()
        {
            string schoolString;

            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("School Details:");

            foreach (var schoolClass in this.Classes)
            {
                sb.AppendLine(schoolClass.ToString());
            }
           
            schoolString = sb.ToString();
            return schoolString;
        }
    }
}
