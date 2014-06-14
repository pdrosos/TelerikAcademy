using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// UNFINISHED !!!
namespace FakeTextMarkupLanguage
{
    class FakeTextMarkupLanguage
    {
        static bool isInOpeningTag = false;
        static bool isInClosingTag = false;

        static StringBuilder currentTag = new StringBuilder();
        static List<string> currentOpenTags = new List<string>();
        static List<int> revTagContentStarts = new List<int>();

        static StringBuilder currentFtml = new StringBuilder();
        static StringBuilder formattedFtml = new StringBuilder();

        static void Main(string[] args)
        {
            int lineNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < lineNumbers; i++)
            {
                string line = Console.ReadLine().Trim();

                FormatLine(line);
            }

            Console.WriteLine(formattedFtml.ToString().Trim());
        }

        private static void FormatLine(string line)
        {
            for (int currentCharacterNumber = 0; currentCharacterNumber < line.Length; currentCharacterNumber++)
            {
                if (line[currentCharacterNumber] == '<' && line[currentCharacterNumber + 1] != '/') // start of opening tag
                {
                    isInOpeningTag = true;
                    currentFtml.Clear();
                }
                else if (line[currentCharacterNumber] == '>' && isInOpeningTag == true) // end of opening tag
                {
                    isInOpeningTag = false;

                    string currentTagStr = currentTag.ToString();
                    currentOpenTags.Add(currentTagStr);                    
                    currentTag.Clear();

                    if (currentTagStr == "rev")
                    {
                        revTagContentStarts.Add(formattedFtml.Length);
                    }
                }
                else if (line[currentCharacterNumber] == '<' && line[currentCharacterNumber + 1] == '/') // start of closing tag
                {
                    isInClosingTag = true;
                }
                else if (line[currentCharacterNumber] == '>' && isInClosingTag == true) // end of closing tag
                {
                    isInClosingTag = false;

                    // remove last opened tag
                    string lastOpenedTag = currentOpenTags[currentOpenTags.Count - 1];
                    
                    if (lastOpenedTag == "rev")
                    {
                        formattedFtml.Append(currentFtml);
                        currentFtml.Clear();

                        int stringToReverseStartIndex = revTagContentStarts[revTagContentStarts.Count - 1];
                        int stringToReverseLength = formattedFtml.Length - stringToReverseStartIndex;
                        string formatted = formattedFtml.ToString();
                        string stringToReverse = formatted.Substring(stringToReverseStartIndex, stringToReverseLength);
                        formattedFtml.Remove(stringToReverseStartIndex, stringToReverseLength);
                        formattedFtml.Append(Reverse(stringToReverse));
                        revTagContentStarts.RemoveAt(revTagContentStarts.Count - 1);
                    }

                    currentOpenTags.RemoveAt(currentOpenTags.Count - 1);

                    // append the formatted FTML
                    if (currentOpenTags.Count == 0 && currentFtml.Length > 0)
                    {
                        formattedFtml.Append(currentFtml);
                        currentFtml.Clear();
                    }
                }
                else if (isInOpeningTag == true)
                {
                    currentTag.Append(line[currentCharacterNumber]);
                }
                else if (isInOpeningTag == false && isInClosingTag == false) // in text
                {
                    if (currentOpenTags.Count > 0)
                    {
                        string formattedCharacter = FormatCharacter(line[currentCharacterNumber].ToString());
                        currentFtml.Append(formattedCharacter);
                    }
                    else
                    {
                        formattedFtml.Append(line[currentCharacterNumber]);
                    }
                }                
            }

            formattedFtml.AppendLine();
        }

        private static string FormatCharacter(string character)
        {
            for (int i = currentOpenTags.Count - 1; i >= 0; i--)
            {
                if (currentOpenTags[i] == "upper")
                {
                    character = character.ToUpper();
                }
                else if (currentOpenTags[i] == "lower")
                {
                    character = character.ToLower();
                }
                else if (currentOpenTags[i] == "toggle")
                {
                    if (char.IsUpper(character[0]))
                    {
                        character = character.ToLower();
                    }
                    else
                    {
                        character = character.ToUpper();
                    }
                }
                else if (currentOpenTags[i] == "del")
                {
                    return "";
                }
            }

            return character;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
