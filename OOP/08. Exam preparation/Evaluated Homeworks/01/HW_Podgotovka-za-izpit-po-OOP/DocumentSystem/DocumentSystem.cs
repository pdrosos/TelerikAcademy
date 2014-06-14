using System;
using System.Collections.Generic;

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
    private static IList<IDocument> documents = new List<IDocument>();

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
        TextDocument doc = new TextDocument();
        AddDocument(attributes, doc);
    }

    private static void AddDocument(string[] attributes, IDocument doc)
    {
        foreach (var attrib in attributes)
        {
            string[] tokens = attrib.Split('=');
            string propName = tokens[0];
            string propValue = tokens[1];
            doc.LoadProperty(propName, propValue);
        }
        if (doc.Name != null)
        {
            documents.Add(doc);
            Console.WriteLine("Document added: {0}", doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddPdfDocument(string[] attributes)
    {
        PDFDocument doc = new PDFDocument();
        AddDocument(attributes, doc);
    }

    private static void AddWordDocument(string[] attributes)
    {
        WordDocument doc = new WordDocument();
        AddDocument(attributes, doc);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        ExcelDocument doc = new ExcelDocument();
        AddDocument(attributes, doc);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AudioDocument doc = new AudioDocument();
        AddDocument(attributes, doc);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        VideoDocument doc = new VideoDocument();
        AddDocument(attributes, doc);
    }

    private static void ListDocuments()
    {
        if (documents.Count == 0)
        {
            Console.WriteLine("No documents found");
        }
        else
        {
            foreach (var doc in documents)
            {
                Console.WriteLine(doc);
            }
        }
    }

    private static void EncryptDocument(string name)
    {
        bool found = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                found = true;
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Encrypt();
                    Console.WriteLine("Document encrypted: " + doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + doc.Name);
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool found = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                found = true;
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Decrypt();
                    Console.WriteLine("Document decrypted: " + doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + doc.Name);
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool foundEncryptable = false;
        foreach (var doc in documents)
        {
            if (doc is IEncryptable)
            {
                foundEncryptable = true;
                ((IEncryptable)doc).Decrypt();
            }
        }
        if (!foundEncryptable)
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
        bool found = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                found = true;
                if (doc is IEditable)
                {
                    ((IEditable)doc).ChangeContent(content);
                    Console.WriteLine("Document content changed: " + doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + doc.Name);
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }
}
