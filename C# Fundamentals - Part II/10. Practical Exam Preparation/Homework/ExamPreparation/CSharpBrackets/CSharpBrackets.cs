using System;
//using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpBrackets
{
    class CSharpBrackets
    {
        static int identationStringsCount = 0;

        static void Main(string[] args)
        {
            //Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

            int numberOfLines = int.Parse(Console.ReadLine());
            string identationStr = Console.ReadLine();

            StringBuilder formattedCode = new StringBuilder();

            for (int i = 0; i < numberOfLines; i++)
            {
                string line = Console.ReadLine().Trim();

                FormatLine(line, identationStr, formattedCode);
            }

            Console.WriteLine(formattedCode.ToString().Trim());
        }

        private static void FormatLine(string line, string identationString, StringBuilder formattedCode)
        {
            line = Regex.Replace(line, @"\s+", " ").Trim();
            bool addedNewLine = false;

            for (int currentCharacterNumber = 0; currentCharacterNumber < line.Length; currentCharacterNumber++)
            {
                char currentCharacter = line[currentCharacterNumber];

                if (currentCharacter == '{')
                {
                    if (currentCharacterNumber > 0 && formattedCode[formattedCode.Length - 1] != '\n')
                    {
                        formattedCode.AppendLine();
                    }
                    AppendIdentation(formattedCode, identationString, identationStringsCount);
                    formattedCode.Append(currentCharacter);
                    if (currentCharacterNumber < line.Length - 1)
                    {
                        formattedCode.AppendLine();
                    }
                    
                    identationStringsCount++;
                    addedNewLine = true;
                }
                else if (currentCharacter == '}')
                {
                    identationStringsCount--;

                    if (formattedCode[formattedCode.Length - 1] != '\n')
                    {
                        formattedCode.AppendLine();
                    }
                    AppendIdentation(formattedCode, identationString, identationStringsCount);
                    formattedCode.Append(currentCharacter);
                    if (currentCharacterNumber < line.Length - 1)
                    {
                        formattedCode.AppendLine();
                    }
                    addedNewLine = true;
                }
                else
                {
                    if (addedNewLine == true)
                    {
                        if (char.IsWhiteSpace(currentCharacter) == false)
                        {
                            addedNewLine = false;
                            AppendIdentation(formattedCode, identationString, identationStringsCount);
                            formattedCode.Append(currentCharacter);
                        }
                    }
                    else
                    {
                        if (currentCharacterNumber == 0)
                        {
                            AppendIdentation(formattedCode, identationString, identationStringsCount);
                        }
                        formattedCode.Append(currentCharacter);
                    }
                }
            }

            if (line.Length > 0)
            {
                formattedCode.AppendLine();
            }            
        }

        private static void AppendIdentation(StringBuilder formattedCode, string identationString, int identationStringsCount)
        {
            for (int i = 0; i < identationStringsCount; i++)
            {
                formattedCode.Append(identationString);
            }
        }
    }
}
