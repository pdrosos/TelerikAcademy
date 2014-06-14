using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DocumentSystem
{
    public interface IDocument
    {
        string Name { get; }

        string Content { get; }

        void LoadProperty(string key, string value);

        void SaveAllProperties(IList<KeyValuePair<string, object>> output);

        string ToString();
    }

    public interface IEditable
    {
        void ChangeContent(string newContent);
    }

    public interface IEncryptable
    {
        bool IsEncrypted { get; }

        void Encrypt();

        void Decrypt();
    }

    public class DocumentSystem
    {
        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<Document> documents = new List<Document>();

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static Dictionary<string, string> ParseProperties(string[] attributes, out string name)
        {
            name = null;
            Dictionary<string, string> properties = new Dictionary<string, string>();

            foreach (string attribute in attributes)
            {
                string[] keyValue = attribute.Split('=');

                if (keyValue[0] == "name")
                {
                    name = keyValue[1];
                }
                else
                {
                    properties.Add(keyValue[0], keyValue[1]);
                }
            }

            return properties;
        }

        private static void CreateDocument(string name, Dictionary<string, string> properties, string documentType)
        {
            if (!string.IsNullOrEmpty(name))
            {
                // dynamically create Document instance of type documentType
                // http://stackoverflow.com/questions/15449800/create-object-instance-of-a-class-having-its-name-in-string-variable
                string namespaceName = "DocumentSystem";
                Type docType = Type.GetType(namespaceName + "." + documentType);
                Document document = (Document)Activator.CreateInstance(docType, new object[] { name });
                documents.Add(document);

                foreach (KeyValuePair<string, string> property in properties)
                {
                    document.LoadProperty(property.Key, property.Value);
                }

                Console.WriteLine("Document added: {0}", name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "TextDocument");
        }

        private static void AddPdfDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "PDFDocument");
        }

        private static void AddWordDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "WordDocument");
        }

        private static void AddExcelDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "ExcelDocument");
        }

        private static void AddAudioDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "AudioDocument");
        }

        private static void AddVideoDocument(string[] attributes)
        {
            string name;
            Dictionary<string, string> properties = ParseProperties(attributes, out name);
            CreateDocument(name, properties, "VideoDocument");
        }

        private static void ListDocuments()
        {
            if (documents.Count == 0)
            {
                Console.WriteLine("No documents found");
            }

            foreach (Document document in documents)
            {
                Console.WriteLine(document);
            }
        }

        private static void EncryptDocument(string name)
        {
            bool notFound = true;

            foreach (Document document in documents)
            {
                if (document.Name == name)
                {
                    notFound = false;

                    if (document is IEncryptable)
                    {
                        IEncryptable doc = (IEncryptable)document;
                        doc.Encrypt();
                        Console.WriteLine("Document encrypted: {0}", document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: {0}", document.Name);
                    }
                }
            }

            if (notFound)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool notFound = true;

            foreach (Document document in documents)
            {
                if (document.Name == name)
                {
                    notFound = false;

                    if (document is IEncryptable)
                    {
                        IEncryptable doc = (IEncryptable)document;
                        doc.Decrypt();
                        Console.WriteLine("Document decrypted: {0}", document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: {0}", document.Name);
                    }
                }
            }

            if (notFound)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void EncryptAllDocuments()
        {
            bool notFound = true;

            foreach (Document document in documents)
            {
                if (document is IEncryptable)
                {
                    notFound = false;

                    IEncryptable doc = (IEncryptable)document;
                    doc.Encrypt();
                }
            }

            if (notFound)
            {
                Console.WriteLine("No encryptable documents found");
            }
            else
            {
                Console.WriteLine("All documents encrypted");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            bool notFound = true;

            foreach (Document document in documents)
            {
                if (document.Name == name)
                {
                    notFound = false;

                    if (document is IEditable)
                    {
                        IEditable doc = (IEditable)document;
                        doc.ChangeContent(content);
                        Console.WriteLine("Document content changed: {0}", document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: {0}", document.Name);
                    }
                }
            }

            if (notFound)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }
    }

    /// <summary>
    /// Abstract document class
    /// </summary>
    public abstract class Document : IDocument
    {
        public Document(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public void LoadProperty(string key, string value)
        {
            Type type = this.GetType();
            PropertyInfo property = type.GetProperty(this.FirstCharToUpper(key));
            property.SetValue(this, value);
        }

        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                output.Add(new KeyValuePair<string, object>(property.Name, property.GetValue(this)));
            }
        }

        protected string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Invalid string");
            }

            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }

        public override string ToString()
        {
            IList<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(properties);
            IOrderedEnumerable<KeyValuePair<string, object>> orderedProperties = properties.OrderBy(x => x.Key);

            bool isEncrypted = false;
            if (this is IEncryptable)
            {
                IEncryptable encryptableDocument = (IEncryptable)this;
                if (encryptableDocument.IsEncrypted == true)
                {
                    isEncrypted = true;
                }
            }

            StringBuilder info = new StringBuilder();
            info.Append(this.GetType().Name).Append("[");
            if (isEncrypted)
            {
                info.Append("encrypted");
            }
            else
            {
                foreach (KeyValuePair<string, object> property in orderedProperties)
                {
                    if (property.Value != null && property.Value.GetType() != typeof(bool))
                    {
                        info.AppendFormat("{0}={1};", property.Key.ToLower(), property.Value);
                    }
                }

                // remove the last ";"
                info.Length--;
            }
            info.Append("]");

            return info.ToString();
        }
    }

    /// <summary>
    /// Text document
    /// </summary>
    public class TextDocument : Document, IEditable
    {
        public TextDocument(string name) : base(name)
        {
        }

        public string Charset { get; set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }

    /// <summary>
    /// Abstract binary document
    /// </summary>
    public abstract class BinaryDocument : Document
    {
        public BinaryDocument(string name) : base(name)
        {
        }

        public string Size { get; set; }
    }

    /// <summary>
    /// Abstract office document
    /// </summary>
    public abstract class OfficeDocument : BinaryDocument, IEncryptable
    {
        public OfficeDocument(string name) : base(name)
        {
        }

        public string Version { get; set; }

        public bool IsEncrypted { get; protected set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }
    }

    /// <summary>
    /// Word document
    /// </summary>
    public class WordDocument : OfficeDocument, IEditable
    {
        public WordDocument(string name) : base(name)
        {
        }

        public string Chars { get; set; }

        public string Charset { get; set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }

    /// <summary>
    /// Excel document
    /// </summary>
    public class ExcelDocument : OfficeDocument
    {
        public ExcelDocument(string name) : base(name)
        {
        }

        public string Rows { get; set; }

        public string Cols { get; set; }
    }

    /// <summary>
    /// Abstract multimedia document
    /// </summary>
    public abstract class MultimediaDocument : BinaryDocument
    {
        public MultimediaDocument(string name) : base(name)
        {
        }

        public string Length { get; set; }
    }

    /// <summary>
    /// Audio document
    /// </summary>
    public class AudioDocument : MultimediaDocument
    {
        public AudioDocument(string name) : base(name)
        {
        }

        public string Samplerate { get; set; }
    }

    /// <summary>
    /// Video document
    /// </summary>
    public class VideoDocument : MultimediaDocument
    {
        public VideoDocument(string name) : base(name)
        {
        }

        public string Framerate { get; set; }
    }

    /// <summary>
    /// PDF document
    /// </summary>
    public class PDFDocument : BinaryDocument, IEncryptable
    {
        public PDFDocument(string name) : base(name)
        {
        }

        public string Pages { get; set; }

        public bool IsEncrypted { get; protected set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }
    }
}