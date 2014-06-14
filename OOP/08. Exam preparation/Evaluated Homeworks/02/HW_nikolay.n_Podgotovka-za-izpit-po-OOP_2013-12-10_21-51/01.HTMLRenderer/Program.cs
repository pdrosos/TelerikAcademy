using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Collections.Generic;
using System.Reflection;

namespace HTMLRenderer
{
    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new HTMLElement(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new HTMLElement(name,content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new HTMLTable(rows, cols);
        }
    }

    public class HTMLRendererCommandExecutor
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

    public class HTMLElement : HTMLObject
    {
        public HTMLElement(string name):base(name)
        {
        }

        public HTMLElement(string name, string content): base(name,content)
        {
        }

        public override void AddElement(IElement element)
        {
            this.childElements.Add((IElement)element);
        }

        public override void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.AppendFormat("<{0}>", this.Name); 
            }
            if (this.TextContent != null)
            {
                output.AppendFormat("{0}", GetEncodedText(this.TextContent));
            }
            foreach (var child in this.childElements)
            {
                child.Render(output);
            }
            if (this.Name != null)
            {
                output.AppendFormat("</{0}>", this.Name); 
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            this.Render(result);
            return result.ToString();
        }

        protected string GetEncodedText(string text)
        {
            var res = new StringBuilder();
            foreach (var cha in text)
            {
                if (cha == '<')
                {
                    res.Append("&lt;");
                }
                else if (cha == '>')
                {
                    res.Append("&gt;");
                }
                else if (cha == '&')
                {
                    res.Append("&amp;");
                }
                else
                {
                    res.Append(cha);
                }
            }
            return res.ToString();

        }
    }

    public class HTMLTable: HTMLObject
    {
        private const string TableName = "table";
        private IElement[,] table;
        public HTMLTable(int rows, int cols)
            : base(rows, cols)
        {
            this.Name = TableName;
            this.table = new IElement[rows, cols];
        }

        public override void AddElement(IElement element)
        {
            throw new InvalidOperationException("Tables cannot add child elements!");
        }

        public override void Render(StringBuilder output)
        {
            output.Append("<table>");
            for (int rowz = 0; rowz < this.Rows; rowz++)
            {
                output.Append("<tr>");
                for (int colz = 0; colz < this.Cols; colz++)
                {
                    
                    output.Append("<td>");
                    this.table[rowz, colz].Render(output);
                    output.Append("</td>");
                    
                }
                output.Append("</tr>");
            }
            output.Append("</table>");
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            this.Render(result);
            return result.ToString();
        }

        public override IElement this[int row, int col]
        {
            get
            {
                return this.table[this.Rows, this.Cols];
            }
            set
            {
                this.table[row,col] = value;
            }
        }
    }

    public abstract class HTMLObject: ITable, IElement
    {
        private string name;
        private int rows;
        private int cols;
        private string textContent;
        protected List<IElement> childElements;

        public HTMLObject(string name)
        {
            this.name = name;
            this.childElements = new List<IElement>();
        }

        public HTMLObject(string name, string content): this(name)
        {
            this.textContent = content;
        }

        public HTMLObject(int rows,int cols)
        {            
            this.rows = rows;
            this.cols = cols;
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
        }

        public int Cols
        {
            get { return this.cols; }
        }

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public string TextContent
        {
            get
            {
                return this.textContent;
            }
            set
            {
                this.textContent = value;
            }
        }

        public IEnumerable<IElement> ChildElements
        {
            get { return this.childElements; }
        }

        public abstract void AddElement(IElement element);

        public abstract void Render(StringBuilder output);


        public virtual IElement this[int row, int col]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
