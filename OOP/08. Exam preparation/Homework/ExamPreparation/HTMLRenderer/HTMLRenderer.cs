using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

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

    /// <summary>
    /// HTML element
    /// </summary>
    public class HtmlElement : IElement
    {
        protected string name;
        protected string textContent;
        protected ICollection<IElement> childElements;

        public HtmlElement(string name)
        {
            this.Name = name;
            this.childElements = new List<IElement>();
        }

        public HtmlElement(string name, string textContent)
            : this(name)
        {
            this.TextContent = textContent;
        }

        public string Name 
        {
            get 
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public virtual string TextContent 
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

        public virtual IEnumerable<IElement> ChildElements
        {
            get 
            { 
                return this.childElements; 
            }
        }

        public virtual void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (! string.IsNullOrWhiteSpace(this.Name))
            {
                output.AppendFormat("<{0}>", this.Name);
            }

            if (! string.IsNullOrWhiteSpace(this.TextContent))
            {
                for (int i = 0; i < this.TextContent.Length; i++)
                {
                    char symbol = this.TextContent[i];

                    switch (symbol)
                    {
                        case '<':
                            output.Append("&lt;");
                            break;
                        case '>':
                            output.Append("&gt;");
                            break;
                        case '&':
                            output.Append("&amp;");
                            break;
                        default:
                            output.Append(symbol);
                            break;
                    }
                }
            }

            foreach (var childElement in this.ChildElements)
            {
                output.Append(childElement.ToString());
            }

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                output.AppendFormat("</{0}>", this.Name);
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            this.Render(info);

            return info.ToString();
        }
    }

    /// <summary>
    /// HTML table
    /// </summary>
    public class HtmlTable : HtmlElement, ITable
    {
        protected const string TableName = "table";
        protected const string TableRowOpenTag = "<tr>";
        protected const string TableRowCloseTag = "</tr>";
        protected const string TableCellOpenTag = "<td>";
        protected const string TableCellCloseTag = "</td>";

        protected int rows;
        protected int cols;
        protected IElement[,] cells;

        public HtmlTable(int rows, int cols)
            : base(TableName)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.cells = new IElement[this.Rows, this.Cols];
        }

        public int Rows
        {
            get 
            { 
                return this.rows; 
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "HTML table rows must be greater than zero");
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get 
            { 
                return this.cols; 
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "HTML table columns must be greater than zero");
                }

                this.cols = value;
            }
        }

        public IElement this[int row, int col]
        {
            get
            {
                this.ValidateIndexes(row, col);

                return this.cells[row, col];
            }
            set
            {
                this.ValidateIndexes(row, col);

                if (value == null)
                {
                    throw new ArgumentNullException("value", "HTML element can not be null");
                }

                this.cells[row, col] = value;
            }
        }

        public override IEnumerable<IElement> ChildElements
        {
            get
            {
                throw new InvalidOperationException("HTML tables do not have child elements");
            }
        }

        public override string TextContent
        {
            get
            {
                throw new InvalidOperationException("HTML table do not have text content");
            }
            set
            {
                throw new InvalidOperationException("HTML table do not have text content");
            }
        }

        public override void AddElement(IElement element)
        {
            throw new InvalidOperationException("HTML table do not have child elements");
        }

        public override void Render(StringBuilder output)
        {
            output.AppendFormat("<{0}>", this.Name);

            for (int row = 0; row < this.Rows; row++)
            {
                output.Append(TableRowOpenTag);

                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append(TableCellOpenTag);

                    output.Append(this.cells[row, col].ToString());

                    output.Append(TableCellCloseTag);
                }

                output.Append(TableRowCloseTag);
            }

            output.AppendFormat("</{0}>", this.Name);
        }

        private void ValidateIndexes(int row, int col)
        {
            if (row < 0 || row >= this.Rows)
            {
                throw new IndexOutOfRangeException("Row is out of the boundaries of the HTML table");
            }

            if (col < 0 || col >= this.Cols)
            {
                throw new IndexOutOfRangeException("Column is out of the boundaries of the HTML table");
            }
        }
    }

    /// <summary>
    /// HTML element factory
    /// </summary>
    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new HtmlElement(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new HtmlElement(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new HtmlTable(rows, cols);
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
                  using HTMLRenderer;

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
}
