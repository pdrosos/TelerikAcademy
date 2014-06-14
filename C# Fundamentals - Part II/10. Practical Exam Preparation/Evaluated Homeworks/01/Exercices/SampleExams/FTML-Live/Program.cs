using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTML_Live
{
    public class Program
    {
        private const string RevTagOpen = "<rev>";
        private const string UpperTagOpen = "<upper>";
        private const string LowerTagOpen = "<lower>";
        private const string ToggleTagOpen = "<toggle>";
        private const string DelTagOpen = "<del>";

        private const string RevTagClose = "</rev>";
        private const string UpperTagClose = "</upper>";
        private const string LowerTagClose = "</lower>";
        private const string ToggleTagClose = "</toggle>";
        private const string DelTagClose = "</del>";
        private static int openedDelTags = 0;
        private static StringBuilder output = new StringBuilder();
        private static List<string> currentOpenTag = new List<string>();
        private static List<int> revTagStarts = new List<int>();

        internal static void Main()
        {
            //Console.WriteLine(char.IsUpper('2'));

            int numberOflines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOflines; i++)
            {
                string currentLine = Console.ReadLine();
                int currentSymbolIndex = 0;

                while (currentSymbolIndex < currentLine.Length)
                {
                    if (currentLine[currentSymbolIndex] == '<')
                    {
                        string tag = GetTag(currentLine, currentSymbolIndex);
                        ProcessTag(tag);

                        currentSymbolIndex += tag.Length - 1;
                    }
                    else
                    {
                        if (openedDelTags == 0)
                        {
                            char symbolToAdd = currentLine[currentSymbolIndex];

                            for (int j = currentOpenTag.Count - 1; j >= 0; j--)
                            {
                                symbolToAdd = ApplayEffects(symbolToAdd, currentOpenTag[j]);
                            }

                            output.Append(symbolToAdd);
                        }
                    }

                    currentSymbolIndex++;
                }

                output.Append('\n');
            }

            output.Replace("\n", Environment.NewLine);

            Console.WriteLine(output.ToString());
        }

        private static char ApplayEffects(char symbolToAdd, string currentOpenTag)
        {
            if (char.IsLetter(symbolToAdd))
            {
                if (currentOpenTag == UpperTagOpen)
                {
                    symbolToAdd = char.ToUpper(symbolToAdd);
                }
                else if (currentOpenTag == LowerTagOpen)
                {
                    symbolToAdd = char.ToLower(symbolToAdd);
                }
                else if (currentOpenTag == ToggleTagOpen)
                {
                    if (char.IsLower(symbolToAdd))
                    {
                        symbolToAdd = char.ToUpper(symbolToAdd);
                    }
                    else
                    {
                        symbolToAdd = char.ToLower(symbolToAdd);
                    }
                }
            }

            return symbolToAdd;
        }

        private static void ProcessTag(string tag)
        {
            if (tag == DelTagOpen)
            {
                openedDelTags++;
            }
            else if (tag == DelTagClose)
            {
                openedDelTags--;
            }
            else
            {
                if (openedDelTags == 0)
                {
                    if (tag == RevTagOpen)
                    {
                        revTagStarts.Add(output.Length);
                    }
                    else if (tag == RevTagClose)
                    {
                        int currentRevStart = revTagStarts[revTagStarts.Count - 1];
                        int revEnd = output.Length - 1;
                        Reverse(currentRevStart, revEnd);
                        revTagStarts.RemoveAt(revTagStarts.Count - 1);
                    }
                    else if (tag[1] == '/')
                    {
                        currentOpenTag.RemoveAt(currentOpenTag.Count - 1);
                    }
                    else
                    {
                        currentOpenTag.Add(tag);
                    }
                }
            }
        }

        private static void Reverse(int currentRevStart, int revEnd)
        {
            int start = currentRevStart;
            int end = revEnd;

            while (start < end)
            {
                char bufferChar = output[start];
                output[start] = output[end];
                output[end] = bufferChar;

                end--;
                start++;
            }
        }

        private static string GetTag(string currentLine, int symbolIndex)
        {
            int tagsStart = symbolIndex;
            int tagEnd = currentLine.IndexOf('>', tagsStart + 1);

            string tag = currentLine.Substring(tagsStart, tagEnd - tagsStart + 1);

            return tag;
        }
    }
}
