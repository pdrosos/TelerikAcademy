using System;
using System.Collections.Generic;
using System.Text;

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

    private static List<IDocument> documents = new List<IDocument>();
    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

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

    private static void AddTextDocument(string[] attributes)
    {
        AddDocument(new TextDocument(), attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(new PDFDocument(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(new WordDocument(), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(new ExcelDocument(), attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(new AudioDocument(), attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(new VideoDocument(), attributes);
    }

    private static void AddDocument(IDocument doc, string[] atrributes)
    {
        foreach (var attr in atrributes)
        {
            var keyAndValue = attr.Split('=');
            var key = keyAndValue[0];
            var value = keyAndValue[1];
            doc.LoadProperty(key, value);
        }
        if(doc.Name != null)
        {
            documents.Add(doc);
            Console.WriteLine("Document added: {0}", doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void ListDocuments()
    {
        if (documents.Count > 0)
        {
            foreach (var doc in documents)
            {
                Console.WriteLine(doc);
            } 
        }
        else
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        bool docFound = false;
        foreach (var doc in documents)
        {
            if(doc.Name == name)
            {
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
                docFound = true;
            }
        }

        if(!docFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool docFound = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
                docFound = true;
            }
        }

        if (!docFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool docFount = false;
        foreach (var doc in documents)
        {
            if(doc is IEncryptable)
            {
                docFount = true;
                ((IEncryptable)doc).Encrypt();
            }
        }

        if(docFount)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }

    }

    private static void ChangeContent(string name, string content)
    {
        bool docFound = false;
        foreach (var doc in documents)
        {
            if(doc.Name == name)
            {
                if(doc is IEditable)
                {
                    ((IEditable)doc).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", doc.Name);
                }
                docFound = true;
            }
            
        }

        if(!docFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }
}


public class TextDocument : Document, IEditable
{
    private string charset;

    public string Charset
    {
        get { return this.charset; }
        set { this.charset = value; }
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "charset")
        {
            this.Charset = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("charset", this.Charset));
    }
}

public abstract class BinaryDocument : Document
{
    private int? size;

    public int? Size
    {
        get { return this.size; }
        set { this.size = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
        {
            this.Size = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("size", this.Size));
    }
}

public abstract class Office : BinaryDocument
{
    private string version;

    public string Version
    {
        get { return this.version; }
        set { this.version = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "version")
        {
            this.Version = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("version", this.Version));
    }
}

public abstract class MultimediaDocument : BinaryDocument
{
    private int? length;

    public int? Length
    {
        get { return this.length; }
        set { this.length = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if(key == "length")
        {
            this.Length = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {        
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("length", this.Length));
    }
}

public class WordDocument : Office, IEncryptable, IEditable
{
    private int? characters;
    private bool encrypted;

    public int? Characters
    {
        get { return this.characters; }
        set { this.characters = value; }
    }

    public bool IsEncrypted
    {
        get { return this.encrypted; }
    }

    public void Encrypt()
    {
        this.encrypted = true;
    }

    public void Decrypt()
    {
        this.encrypted = false;
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.Characters = int.Parse(value);
        }        
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("chars", this.Characters));
    }

    public override string ToString()
    {
        string res = this.GetType().Name +"[encrypted]";
        if (this.IsEncrypted)
        {
            return res;
        }
        else
        {
            return base.ToString();
        }
    }
    
}

public class ExcelDocument : Office, IEncryptable
{
    private int? rows;
    private int? cols;
    private bool encrypted;

    public int? Rows
    {
        get { return this.rows; }
        set { this.rows = value; }
    }

    public int? Cols
    {
        get { return this.cols; }
        set { this.cols = value; }
    }

    public bool IsEncrypted
    {
        get { return this.encrypted; }
    }

    public void Encrypt()
    {
        this.encrypted = true;
    }

    public void Decrypt()
    {
        this.encrypted = false;
    }

    public override void LoadProperty(string key, string value)
    {
       if(key == "rows")
       {
           this.Rows = int.Parse(value);
       }
       else if(key == "cols")
       {
           this.Cols = int.Parse(value);
       }
       else
       {
           base.LoadProperty(key,value);
       }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
        output.Add(new KeyValuePair<string, object>("cols", this.Cols));
    }

    public override string ToString()
    {
        string res = this.GetType().Name +"[encrypted]";
        if (this.IsEncrypted)
        {
            return res;
        }
        else
        {
            return base.ToString();
        }
    }
}

public class AudioDocument : MultimediaDocument
{
    private int? sampleRate;

    public int? SampleRate
    {
        get { return this.sampleRate; }
        set { this.sampleRate = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if(key == "samplerate")
        {
            this.SampleRate = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
    }
}

public class VideoDocument : MultimediaDocument
{
    private int? frameRate;

    public int? FrameRate
    {
        get { return this.frameRate; }
        set { this.frameRate = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if(key == "framerate")
        {
            this.FrameRate = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }        
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
    }
}

public class PDFDocument : BinaryDocument, IEncryptable
{
    private int? pages;
    private bool encrypted;

    public int? PagesQuantity
    {
        get { return this.pages; }
        set { this.pages = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if(key=="pages")
        {
            this.PagesQuantity = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("pages", this.PagesQuantity));
    }

    public bool IsEncrypted
    {
        get { return this.encrypted; }
        set { this.encrypted = value; }
    }

    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }

    public override string ToString()
    {
        string res = this.GetType().Name +"[encrypted]";
        if (this.IsEncrypted)
        {
            return res;
        }
        else
        {
            return base.ToString();
        }
    }
}

public abstract class Document : IDocument
{
    private string name;
    private string content;
    private IList<KeyValuePair<string, object>> allProps = new List<KeyValuePair<string,object>>();    

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Content
    {
        get { return this.content; }
        set { this.content = value; }
    }

    public IList<KeyValuePair<string,object>> AllProperties 
    {
        get { return this.allProps; }
    }

    public virtual void LoadProperty(string key, string value)
    {
        if(key == "name")
        {
            this.Name = value;;
        }
        else if(key == "content")
        {
            this.Content = value;
        }
        else
        {
            throw new ArgumentException("No such property");
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(properties);
        properties.Sort((a, b) => a.Key.CompareTo(b.Key));
        var result = new StringBuilder();
        result.AppendFormat("{0}[", this.GetType().Name);
        
        foreach (var prop in properties)
        {            
            if(prop.Value != null)
            {
                result.AppendFormat("{0}={1};", prop.Key, prop.Value);                
            }
        }
        result.Length--;
        result.Append("]");
        return result.ToString();
    }
}

