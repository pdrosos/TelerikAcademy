namespace ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmails
    {
        /// <summary>
        /// Write a program for extracting all email addresses from given text. 
        /// All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.
        /// </summary>
        public static void Main(string[] args)
        {
            string text = "My e-mail is asd@fgh.com. Your e-mail is \"name.family@mail.co.uk\". His e-mail is hello-world@server.co.uk.";

            string[] emails = GetEmails(text);

            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }
        }

        public static string[] GetEmails(string text)
        {
            string pattern = @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}";

            // Find matches
            MatchCollection matches = Regex.Matches(text, pattern);

            string[] emails = new string[matches.Count];

            // add each match
            int i = 0;
            foreach (Match match in matches)
            {
                emails[i] = match.ToString();
                i++;
            }

            return emails;
        }
    }
}
