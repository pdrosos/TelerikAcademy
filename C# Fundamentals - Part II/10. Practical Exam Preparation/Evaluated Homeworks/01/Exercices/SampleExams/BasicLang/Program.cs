using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLang
{
    public class Program
    {
        private static StringBuilder output = new StringBuilder();
        private static List<string> allCommands = new List<string>();

        internal static void Main()
        {
            ReadInput();
            ConvertInputToCommands();
            ExecuteCommands();
            Console.WriteLine(output.ToString());
        }
  
        private static void ExecuteCommands()
        {
            bool hasExecuted = false;
            int commandNumber = 0;

            while (!hasExecuted)
            {
                string[] subCommands = allCommands[commandNumber].Split(')');
                commandNumber++;
                int loopCounter = 1;

                for (int i = 0; i < subCommands.Length; i++)
                {
                    string currentSubCommand = subCommands[i].TrimStart();

                    if (string.IsNullOrWhiteSpace(currentSubCommand) || currentSubCommand == ";")
                    {
                        continue;
                    }

                    if (currentSubCommand.StartsWith("EXIT"))
                    {
                        hasExecuted = true;
                        break;
                    }
                    else if (currentSubCommand.StartsWith("PRINT"))
                    {
                        int contetntStart = currentSubCommand.IndexOf('(') + 1;
                        string content = currentSubCommand.Substring(contetntStart);
                        if (content.Length > 0 && loopCounter > 0)
                        {
                            for (int j = 0; j < loopCounter; j++)
                            {
                                output.Append(content);
                            }
                        }
                    }
                    else if (currentSubCommand.StartsWith("FOR"))
                    {
                        int paramsStart = currentSubCommand.IndexOf('(') + 1;
                        string loopParams = currentSubCommand.Substring(paramsStart);
                        if (loopParams.Contains(','))
                        {
                            string[] rawParams = loopParams.Split(',');
                            int a = int.Parse(rawParams[0]);
                            int b = int.Parse(rawParams[1]);
                            loopCounter *= (b - a + 1);
                        }
                        else
                        {
                            int value = int.Parse(loopParams);
                            loopCounter *= value;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Ivalid command!");
                    }
                }
            }
        }

        private static void ConvertInputToCommands()
        {
            string wholeString = output.ToString();
            output.Clear();

            foreach (char token in wholeString)
            {
                output.Append(token);
                if (token == ';')
                {
                    allCommands.Add(output.ToString());
                    output.Clear();
                }
            }

            output.Clear();
        }

        private static void ReadInput()
        {
            while (true)
            {
                string line = Console.ReadLine();
                output.AppendLine(line);
                if (line.Contains("EXIT;"))
                {
                    break;
                }
            }
        }
    }
}
