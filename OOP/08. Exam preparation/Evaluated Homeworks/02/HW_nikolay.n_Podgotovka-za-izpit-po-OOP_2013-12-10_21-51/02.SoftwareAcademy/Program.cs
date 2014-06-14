using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        #region Constructors
        public LocalCourse(string name)
            : base(name)
        {
        }

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name)
        {
            this.Teacher = teacher;
            this.lab = lab;
        }

        public LocalCourse(string name, string lab)
            : this(name, null, lab)
        {

        }

        public LocalCourse(string name, ITeacher teacher)
            : this(name, teacher, null)
        {
        }
        #endregion

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Lab",value);
                }
                this.lab = value;
            }
        }

        public override void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }

        public override string ToString()
        {
            string buffer = base.ToString();
            var result = new StringBuilder();
            result.Append(buffer);
            if(this.lab != null)
            {
                result.AppendFormat("; Lab={0}", lab);
            }

            return result.ToString();
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        #region Constructors
        public OffsiteCourse(string name)
            : base(name)
        {
        }

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name)
        {
            this.Teacher = teacher;
            this.town = town;
        }

        public OffsiteCourse(string name, string lab)
            : this(name, null, lab)
        {
        }

        public OffsiteCourse(string name, ITeacher teacher)
            : this(name, teacher, null)
        {
        }
        #endregion
        private string town;
        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Town");
                }
                this.town = value;
            }
        }

        public override void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }

        public override string ToString()
        {
            string buffer = base.ToString();
            var result = new StringBuilder();
            result.Append(buffer);
            if(this.town != null)
            {
                result.AppendFormat("; Town={0}", town);
            }
            return result.ToString();
        }
    }

    public class Teacher : ITeacher
    {
        private string name;
        private ICollection<ICourse> courses;

        public Teacher(string name)
        {
            this.name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty", value);
                }
                this.name = value;
            }
        }

        public ICollection<ICourse> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Teacher: ");
            if (this.courses.Count == 0)
            {
                result.AppendFormat("Name={0}", this.Name);
            }
            else
            {
                result.AppendFormat("Name={0}; Courses=[", this.Name);
                int count = this.courses.Count;
                int temp = 0;
                foreach (var course in courses)
                {
                    temp++;
                    if(temp == count)
                    {
                        result.AppendFormat("{0}]", course.Name);
                        break;
                    }
                    result.AppendFormat("{0}, ", course.Name);
                }
            }

            return result.ToString();
        }
    }

    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private ICollection<string> topics;

        public Course(string name)
        {
            this.name = name;
            this.topics = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name",value);
                }
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;
            }
        }

        public ICollection<string> Topics
        {
            get { return this.topics; }
            set { this.topics = value; }
        }

        public abstract void AddTopic(string topic);

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendFormat("{0}: ", this.GetType().Name);

            if(this.topics.Count > 0 || this.teacher != null)
            {
                result.AppendFormat("Name={0}; ", this.name);
            }
            else
            {
                result.AppendFormat("Name={0}", this.name);
            }

            if(this.teacher != null && this.topics.Count == 0)
            {
                result.AppendFormat("Teacher={0}",this.teacher.Name);
            }

            if (this.teacher != null && this.topics.Count > 0)
            {
                result.AppendFormat("Teacher={0}; ", this.teacher.Name);
            }

            if(this.topics.Count > 0)
            {
                result.AppendFormat("Topics=[");
                int count = this.topics.Count;
                int temp = 0;
                foreach (var topic in this.topics)
                {
                    temp++;
                    if(temp == count)
                    {
                        result.AppendFormat("{0}]", topic);
                        break;
                    }

                    result.AppendFormat("{0}, ", topic);
                }
            }
            return result.ToString();
        }
    }
}
