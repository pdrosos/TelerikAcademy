namespace ExtractTextFromHtml
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ExtractTextFromHtml
    {
        /// <summary>
        /// Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
        /// </summary>
        public static void Main(string[] args)
        {
            Extract("../../page.html");
        }

        /// http://en.wikipedia.org/wiki/Finite-state_machine
        /// Сканирайте текста побуквено и във всеки един момент пазете в една променлива дали към момента има отворен таг, 
        /// който не е бил затворен или не. 
        /// Ако срещнете "<", влизайте в режим "отворен таг". Ако срещнете ">", излизайте от режим "отворен таг". 
        /// Ако срещнете буква, я добавяйте към резултата, само ако програмата не е в режим "отворен таг". 
        /// След затваряне на таг може да добавяте по един интервал, за да не се слепва текст преди и след тага. 
        public static void Extract(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                // states
                bool isInBody = false;
                bool isInTag = false;

                StringBuilder currentTag = new StringBuilder();
                
                StringBuilder text = new StringBuilder();
                string clearedText = string.Empty;

                string line = reader.ReadLine();
                while (line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '<') // start of tag
                        {
                            isInTag = true;

                            // print text
                            clearedText = ClearWhiteSpaces(text.ToString());
                            if (clearedText != string.Empty)
                            {
                                PrintText(clearedText, currentTag.ToString().ToLower().StartsWith("title"));
                            }

                            text.Clear();
                            currentTag.Clear();
                        }
                        else if (line[i] == '>') //end of tag
                        {
                            isInTag = false;

                            if (currentTag.ToString().ToLower().StartsWith("body"))
                            {
                                isInBody = true;
                            }
                        }
                        else
                        {
                            if (isInTag)
                            {
                                currentTag.Append(line[i]);
                            }
                            else if (isInBody || currentTag.ToString().ToLower().StartsWith("title"))
                            {
                                // this is text between html tags in the body of the document
                                text.Append(line[i]);
                            }
                        }
                    }

                    line = reader.ReadLine();
                }
            }
        }

        public static string ClearWhiteSpaces(string text)
        {
            return Regex.Replace(text.Trim(), @"\s+", " ");
        }

        public static void PrintText(string text, bool isTitle = false)
        {
            Console.WriteLine((isTitle ? "Title: " : string.Empty) + text);
            Console.WriteLine();
        }
    }
}
